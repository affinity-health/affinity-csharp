// Written by hand. Calls every SDK operation against a real Affinity API in Test mode:
//
//   AFFINITY_API_KEY=sk_test_... [AFFINITY_BASE_URL=https://...] [AFFINITY_SMOKE_WEBHOOK_URL=https://...] \
//     dotnet run --project tests/Affinity.Smoke
//
// `dotnet run --project tests/Affinity.Smoke -- webhook` runs only the offline webhook signature
// checks; it needs no key. The smoke test refuses a Live key. Use a platform Test key: it creates a
// practice and a Test order (sent to the API's test pharmacy) and cancels the order. With
// AFFINITY_SMOKE_WEBHOOK_URL it also creates, updates and removes a webhook endpoint. Feedback is
// sent only as an invalid request, so no one is notified. The API cannot remove a practice, so the
// Test practice stays. Exit code 1 when any check fails.
using System.Text;
using Affinity;

var results = new List<(string Name, bool Ok, string Note)>();

void Record(string name, bool ok, string note = "") => results.Add((name, ok, note));

string Describe(Exception error) =>
    error is AffinityClientApiException api
        ? $"{error.GetType().Name} {api.StatusCode} {(api.Body as Problem)?.Code ?? (api.Body as Problem429)?.Code}"
            + (error is TooManyRequestsError limited ? $" ({limited.Body.Detail}; Retry-After {RetryAfter(limited)})" : "")
        : $"{error.GetType().Name}: {error.Message}"[..Math.Min(300, $"{error.GetType().Name}: {error.Message}".Length)];

string RetryAfter(AffinityClientApiException error) =>
    error.RawResponse is { } raw && raw.Headers.TryGetValue("Retry-After", out var value) ? value ?? "" : "none";

async Task<T?> Check<T>(string name, Func<Task<T>> work, Func<T, string>? note = null)
{
    try
    {
        var value = await work();
        Record(name, true, note?.Invoke(value) ?? "");
        return value;
    }
    catch (Exception error)
    {
        Record(name, false, Describe(error));
        return default;
    }
}

/// A call that must throw TError; inspect returns a problem, or null.
async Task Refused<TError>(string name, Func<Task> work, Func<TError, string?>? inspect = null)
    where TError : Exception
{
    try
    {
        await work();
        Record(name, false, "succeeded");
    }
    catch (TError error)
    {
        var problem = inspect?.Invoke(error);
        Record(name, problem is null, problem ?? Describe(error));
    }
    catch (Exception error)
    {
        Record(name, false, $"got {Describe(error)}");
    }
}

void WebhookChecks()
{
    // Computed independently: printf '%s' '1767225600.{"id":"evt_test","type":"order.updated"}' \
    //   | openssl dgst -sha256 -hmac whsec_test_secret
    const string secret = "whsec_test_secret";
    const string expected = "b735943c0393f96ac832d5ab81c410decd3046762b15e7087e81fba1bc5083c8";
    var body = Encoding.UTF8.GetBytes("{\"id\":\"evt_test\",\"type\":\"order.updated\"}");
    var at = DateTimeOffset.FromUnixTimeSeconds(1767225600);
    var header = $"t=1767225600,v1={expected}";
    Record("webhook signature verifies (openssl)", AffinityWebhook.Verify(header, body, secret, at));
    Record("webhook signature verifies with a second v1",
        AffinityWebhook.Verify($"t=1767225600,v1={new string('0', 64)},v1={expected}", body, secret, at));
    var tampered = Encoding.UTF8.GetBytes("{\"id\":\"evt_test\",\"type\":\"order.updatee\"}");
    Record("webhook tampered body is refused", !AffinityWebhook.Verify(header, tampered, secret, at));
    Record("webhook wrong secret is refused", !AffinityWebhook.Verify(header, body, "whsec_other", at));
    Record("webhook old timestamp is refused", !AffinityWebhook.Verify(header, body, secret, at.AddSeconds(301)));
    Record("webhook timestamp within 300 s verifies", AffinityWebhook.Verify(header, body, secret, at.AddSeconds(-300)));
    Record("webhook missing header is refused", !AffinityWebhook.Verify(null, body, secret, at));
}

int Report()
{
    foreach (var (name, ok, note) in results)
        Console.WriteLine($"{(ok ? "PASS" : "FAIL")} {name}{(note.Length > 0 ? $" — {note}" : "")}");
    var failed = results.Count(r => !r.Ok);
    Console.WriteLine($"{results.Count - failed} of {results.Count} checks passed.");
    return failed > 0 ? 1 : 0;
}

WebhookChecks();
if (args.Contains("webhook")) return Report();

var key = Environment.GetEnvironmentVariable("AFFINITY_API_KEY") ?? "";
if (!key.StartsWith("sk_test_"))
{
    Console.Error.WriteLine("Set AFFINITY_API_KEY to a Test key (sk_test_...).");
    return 2;
}
var baseUrl = Environment.GetEnvironmentVariable("AFFINITY_BASE_URL");
var webhookUrl = Environment.GetEnvironmentVariable("AFFINITY_SMOKE_WEBHOOK_URL");

ClientOptions Options() => string.IsNullOrEmpty(baseUrl)
    ? new ClientOptions { MaxRetries = 0 }
    : new ClientOptions { MaxRetries = 0, BaseUrl = baseUrl };

var client = new AffinityClient(key, Options());
var label = $"SDK smoke {DateTime.UtcNow:O}";
var orderIds = new List<string>();
var endpointIds = new List<string>();
string NewKey() => Guid.NewGuid().ToString();
string Short() => Guid.NewGuid().ToString()[..8];

try
{
    var account = await Check("account.get", async () => await client.Account.GetAsync(),
        a => $"{a.Type} {a.Mode}");
    if (account is null || account.Mode != AccountMode.Test)
        throw new InvalidOperationException("This smoke test runs only with a Test key.");
    if (account.Type != AccountType.Platform)
        throw new InvalidOperationException("Use a platform Test key: it creates a practice.");

    await Refused<UnauthorizedError>("a bad key raises UnauthorizedError",
        async () => await new AffinityClient("sk_test_not_a_key", Options()).Account.GetAsync());
    await Refused<BadRequestError>("feedback.create without a message raises BadRequestError",
        async () => await client.Feedback.CreateAsync(new CreateFeedbackRequest { IdempotencyKey = NewKey(), Message = "" }));

    var practice = await Check("practices.create", async () => await client.Practices.CreateAsync(
        new CreatePracticesRequest
        {
            IdempotencyKey = NewKey(),
            Name = label,
            Phone = "+15125550100",
            Address = new AddressInput { Line1 = "100 Congress Ave", City = "Austin", State = "TX", PostalCode = "78701" },
        }), p => p.Id);
    if (practice is null) throw new InvalidOperationException("No practice; stopping.");
    await Check("practices.get", async () => await client.Practices.GetAsync(new GetPracticesRequest { PracticeId = practice.Id }),
        p => p.Name);
    await Check("practices.update", async () =>
    {
        var updated = await client.Practices.UpdateAsync(new UpdatePracticesRequest
        {
            PracticeId = practice.Id,
            IdempotencyKey = NewKey(),
            Name = $"{label} renamed",
        });
        if (updated.Name != $"{label} renamed") throw new Exception($"name is {updated.Name}");
        return updated;
    }, p => p.Name);
    await Check("practices.list (every page, 1 per page)", async () =>
    {
        var ids = new List<string>();
        await foreach (var p in await client.Practices.ListAsync(new ListPracticesRequest { Limit = 1 })) ids.Add(p.Id);
        if (!ids.Contains(practice.Id)) throw new Exception("the new practice is not listed");
        return ids.Count;
    }, n => $"{n} practices");

    await Check("medications.list (one page)", async () =>
        (await client.Medications.ListAsync(new ListMedicationsRequest { Limit = 5 })),
        p => $"{p.CurrentPage.Items.Count}, more: {p.HasNextPage}");
    var medications = await Check("medications.list (every page, 25 per page)", async () =>
    {
        var all = new List<Medication>();
        await foreach (var m in await client.Medications.ListAsync(new ListMedicationsRequest { Limit = 25 })) all.Add(m);
        if (all.Select(m => m.Id).Distinct().Count() != all.Count) throw new Exception("a medication repeats across pages");
        return all;
    }, all => $"{all.Count} medications");
    var medication =
        medications?.FirstOrDefault(m => !m.ColdChainRequired && m.ShippingOptions.Any() && !m.Requirements.Any())
        ?? medications?.FirstOrDefault(m => m.ShippingOptions.Any());
    if (medication is null) throw new InvalidOperationException("No orderable medication in Test mode; stopping.");
    await Check("medications.get", async () => await client.Medications.GetAsync(new GetMedicationsRequest { MedicationId = medication.Id }),
        m => $"{m.Name} ({m.Pharmacy.Name})");
    await Check("medications.get expand=variants", async () =>
    {
        var m = await client.Medications.GetAsync(new GetMedicationsRequest
        {
            MedicationId = medication.Id,
            Expand = new[] { GetMedicationsRequestExpandItem.Variants },
        });
        if (m.Variants is null) throw new Exception("no variants returned");
        return m;
    }, m => $"{m.Variants!.Count()} variants");
    await Check("medications.list for a practice", async () =>
        await client.Medications.ListAsync(new ListMedicationsRequest { Limit = 5, PracticeId = practice.Id }),
        p => $"{p.CurrentPage.Items.Count}");

    OrderInput OrderInput(int quantity) => new()
    {
        IdempotencyKey = NewKey(),
        ExternalOrderId = $"sdk-smoke-{Short()}",
        Patient = new PatientInput
        {
            ExternalId = $"sdk-smoke-{Guid.NewGuid()}",
            FirstName = "Test",
            LastName = "Smoke",
            DateOfBirth = "1988-04-02",
            Sex = PatientInputSex.Female,
            Email = $"sdk-smoke-{Short()}@example.test",
            Phone = "+15125550101",
            Allergies = new List<PatientInputAllergiesItem>(),
            Address = new AddressInput { Line1 = "200 Congress Ave", City = "Austin", State = "TX", PostalCode = "78701" },
        },
        PracticeId = practice.Id,
        Prescriber = new PrescriberInput { Npi = "1234567893", FirstName = "Sam", LastName = "Lee" },
        Prescriptions = new List<PrescriptionInput>
        {
            new()
            {
                MedicationId = medication.Id,
                Quantity = quantity,
                Refills = 0,
                Directions = "SDK smoke test. TEST ONLY. DO NOT FILL.",
                CompoundingReason = medication.Requirements.Contains("compoundingReason")
                    ? medication.CompoundingReasons.FirstOrDefault()
                    : null,
            },
        },
        Shipping = new OrderInputShipping { OptionId = medication.ShippingOptions.First().Id },
        SignatureAttestation = true,
    };
    async Task<Order> Created(OrderInput input)
    {
        var created = await client.Orders.CreateAsync(input);
        orderIds.Add(created.Id);
        return created;
    }

    var quantity = medication.Quantities.FirstOrDefault(1);
    var input = OrderInput(quantity);
    var order = await Check("orders.create", () => Created(input), o => $"{o.Id} {o.Status}");
    await Check("orders.create again with the same key returns the same order", async () =>
    {
        var again = await client.Orders.CreateAsync(input);
        if (again.Id != order?.Id)
        {
            orderIds.Add(again.Id);
            throw new Exception($"created a second order {again.Id}");
        }
        return again;
    }, o => o.Id);
    await Refused<UnprocessableEntityError>("an unaccepted quantity raises UnprocessableEntityError with the field",
        () => Created(OrderInput(medication.Quantities.DefaultIfEmpty(0).Max() + 1)),
        e => (e.Body.Issues ?? Enumerable.Empty<ProblemIssuesItem>()).Any(i => i.Field == "prescriptions[0].quantity")
            ? null
            : $"issues {string.Join("; ", (e.Body.Issues ?? Enumerable.Empty<ProblemIssuesItem>()).Select(i => i.Field))}");
    if (order is not null)
    {
        await Check("orders.get", async () => await client.Orders.GetAsync(new GetOrdersRequest { OrderId = order.Id }),
            o => $"{o.Status}, {o.Prescriptions.Count()} prescription");
        await Check("orders.list by externalOrderId", async () =>
        {
            var page = (await client.Orders.ListAsync(new ListOrdersRequest { ExternalOrderId = input.ExternalOrderId })).CurrentPage;
            if (string.Join(",", page.Items.Select(o => o.Id)) != order.Id) throw new Exception($"found {page.Items.Count}");
            return page.Items.Count;
        }, n => $"{n}");
        await Check("orders.list updatedAfter (milliseconds)", async () =>
            (await client.Orders.ListAsync(new ListOrdersRequest { UpdatedAfter = DateTime.UtcNow.AddHours(-1), Limit = 5 })).CurrentPage,
            p => $"{p.Items.Count}");
        // DateTime holds 100 ns ticks, so a nanosecond timestamp is sent as a raw query parameter.
        await Check("orders.list updatedAfter (nanoseconds)", async () =>
            (await client.Orders.ListAsync(new ListOrdersRequest { Limit = 5 }, new RequestOptions
            {
                AdditionalQueryParameters = new[] { new KeyValuePair<string, string>("updatedAfter", "2026-01-01T00:00:00.123456789Z") },
            })).CurrentPage,
            p => $"{p.Items.Count}");
        await Check("orders.list (every page, 1 per page)", async () =>
        {
            var n = 0;
            await foreach (var _ in await client.Orders.ListAsync(new ListOrdersRequest { Limit = 1, PracticeId = practice.Id })) n++;
            if (n != 1) throw new Exception($"{n} orders for a practice with 1");
            return n;
        }, n => $"{n}");
        await Check("orders.cancel", async () =>
            await client.Orders.CancelAsync(new CancelOrdersRequest { OrderId = order.Id, IdempotencyKey = NewKey() }),
            o => $"{o.Status}{(o.CancelRequestedAt is null ? "" : ", waiting for the pharmacy")}");
    }
    await Refused<NotFoundError>("orders.get for an unknown order raises NotFoundError",
        async () => await client.Orders.GetAsync(new GetOrdersRequest { OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc" }));

    if (!string.IsNullOrEmpty(webhookUrl))
    {
        string EndpointUrl() => $"{webhookUrl.TrimEnd('/')}/{Guid.NewGuid()}";
        var endpoint = await Check("webhooks.create", async () =>
            await client.Webhooks.CreateAsync(new CreateWebhooksRequest { IdempotencyKey = NewKey(), Url = EndpointUrl() }),
            e => e.Id);
        if (endpoint is not null)
        {
            endpointIds.Add(endpoint.Id);
            await Check("webhooks.list (every page)", async () =>
            {
                var ids = new List<string>();
                await foreach (var e in await client.Webhooks.ListAsync(new ListWebhooksRequest())) ids.Add(e.Id);
                if (!ids.Contains(endpoint.Id)) throw new Exception("the new endpoint is not listed");
                return ids.Count;
            }, n => $"{n}");
            await Check("webhooks.update", async () =>
                await client.Webhooks.UpdateAsync(new UpdateWebhooksRequest
                {
                    WebhookEndpointId = endpoint.Id,
                    IdempotencyKey = NewKey(),
                    Url = EndpointUrl(),
                }), e => e.Id);
            await Check("webhooks.resendFailed", async () =>
                await client.Webhooks.ResendFailedAsync(new ResendFailedWebhooksRequest
                {
                    WebhookEndpointId = endpoint.Id,
                    IdempotencyKey = NewKey(),
                }), r => $"queued {r.Queued}");
            await Check("webhooks.remove", async () =>
            {
                var removed = await client.Webhooks.RemoveAsync(new RemoveWebhooksRequest { WebhookEndpointId = endpoint.Id });
                if (!removed.Deleted) throw new Exception("not deleted");
                endpointIds.Remove(endpoint.Id);
                return removed;
            }, _ => "removed");
        }
    }
    else Record("webhooks (AFFINITY_SMOKE_WEBHOOK_URL is not set)", false);

    await Check("WithRawResponse gives the request ID", async () =>
    {
        var raw = await client.Account.GetAsync().WithRawResponse();
        if (!raw.RawResponse.Headers.TryGetValue("x-request-id", out var requestId) || string.IsNullOrEmpty(requestId))
            throw new Exception("no X-Request-Id header");
        return requestId;
    }, id => id);
}
catch (Exception error)
{
    Record("stopped", false, Describe(error));
}
finally
{
    foreach (var orderId in orderIds.Distinct())
    {
        try { await client.Orders.CancelAsync(new CancelOrdersRequest { OrderId = orderId, IdempotencyKey = NewKey() }); }
        catch (Exception) { }
    }
    foreach (var endpointId in endpointIds)
    {
        try { await client.Webhooks.RemoveAsync(new RemoveWebhooksRequest { WebhookEndpointId = endpointId }); }
        catch (Exception) { }
    }
}

return Report();
