# Affinity C# SDK

Typed server-side .NET client for the Affinity API. It targets API version `2026-10-28` and sends it in `Affinity-Version` on every request. The package `Affinity` builds for .NET 8 and later, .NET Standard 2.0 and .NET Framework 4.6.2.

Keep API keys on the server. Never put them in browser, desktop or mobile applications.

## Install

The package is not on NuGet. Install it from GitHub at tag `v0.4.0`:

```sh
git clone --branch v0.4.0 https://github.com/affinity-health/affinity-csharp.git
dotnet pack affinity-csharp/src/Affinity/Affinity.csproj -c Release -o ./packages
dotnet add package Affinity --version 0.4.0 --source ./packages
```

You can also reference `affinity-csharp/src/Affinity/Affinity.csproj` from your project with `<ProjectReference>`.

## Use

```csharp
using Affinity;

var affinity = new AffinityClient(Environment.GetEnvironmentVariable("AFFINITY_API_KEY"));
var account = await affinity.Account.GetAsync();
if (account.Mode != AccountMode.Test) throw new InvalidOperationException("Use a Test key for this example");

await foreach (var medication in await affinity.Medications.ListAsync(new ListMedicationsRequest()))
    Console.WriteLine($"{medication.Name} {medication.Pharmacy.Name}");
```

The key sets the organization and the Test or Live mode. Test keys start with `sk_test_`; Test orders go to a test pharmacy.

The client has one property per resource: `Account`, `Feedback`, `Medications`, `Orders`, `Practices` and `Webhooks`. Each method takes one request object, for example `Orders.GetAsync(new GetOrdersRequest { OrderId = "ord_..." })`. Pass `ClientOptions` as the second constructor argument to change the defaults, and `RequestOptions` to a method to change one call.

### Idempotency keys

Every write (`CreateAsync`, `UpdateAsync`, `CancelAsync`, `ResendFailedAsync`) requires `IdempotencyKey`, sent as the `Idempotency-Key` header. The SDK does not make one for you.

- Make the key when the clinician reviews the order, and save it with the reviewed order before the first request.
- To retry, send the same key with the same body. The API returns the first result; it does not create a second order.
- The client's automatic retries (for 408, 429 and 5xx responses) send the same request, with the same key.

```csharp
var order = await affinity.Orders.CreateAsync(new OrderInput
{
    IdempotencyKey = savedOrder.IdempotencyKey, // saved with the reviewed order
    PracticeId = "prac_...",
    Patient = patient,
    Prescriber = new PrescriberInput { Npi = "1234567893", FirstName = "Sam", LastName = "Lee" },
    Prescriptions = prescriptions,
    Shipping = new OrderInputShipping { OptionId = medication.ShippingOptions.First().Id },
    SignatureAttestation = true,
});
```

### Pagination

`ListAsync` returns a `Pager<T>`. `await foreach` reads every page; `pager.CurrentPage.Items` is the first page, `pager.HasNextPage` tells if there are more, and `pager.AsPagesAsync()` reads page by page. Set `Limit` in the request to change the page size.

`ListOrdersRequest.UpdatedAfter` is a `DateTime` and is sent with millisecond precision. To send a timestamp with more digits, pass it as a query parameter: `new RequestOptions { AdditionalQueryParameters = new[] { new KeyValuePair<string, string>("updatedAfter", "2026-01-01T00:00:00.123456789Z") } }`.

### Errors

A response with an error status throws a typed exception: `BadRequestError` (400), `UnauthorizedError` (401), `ForbiddenError` (403), `NotFoundError` (404), `ConflictError` (409), `UnprocessableEntityError` (422), `TooManyRequestsError` (429), `InternalServerError` (500), `ServiceUnavailableError` (503) and others. All extend `AffinityClientApiException`, which has `StatusCode`, `Body` and `RawResponse`. A network failure throws `HttpRequestException`, and a timeout throws `TaskCanceledException`; neither is retried. If you see one on a write, you do not know if the API received it: retry with the same idempotency key.

Most `Body` values are a `Problem` with `Code`, `Detail` and `RequestId`. A 422 lists each refused field in `Issues`:

```csharp
try
{
    await affinity.Orders.CreateAsync(input);
}
catch (UnprocessableEntityError error)
{
    foreach (var issue in error.Body.Issues ?? Enumerable.Empty<ProblemIssuesItem>())
        Console.WriteLine($"{issue.Field}: {issue.Message}"); // prescriptions[0].quantity: ...
    Console.WriteLine(error.Body.RequestId);
}
```

To read response headers on success, call `.WithRawResponse()`: `var result = await affinity.Account.GetAsync().WithRawResponse();` gives `result.Data` and `result.RawResponse.Headers`.

### Defaults

| Setting | Default | Change with |
| --- | --- | --- |
| Base URL | `https://api.affinityrx.com` | `ClientOptions.BaseUrl` |
| API version | `2026-10-28` (`Affinity-Version` header) | fixed for this SDK version |
| Retries | 2, for 408, 429 and 5xx responses, with exponential backoff that respects `Retry-After` | `ClientOptions.MaxRetries`, `RequestOptions.MaxRetries` |
| Timeout | 30 seconds per attempt | `ClientOptions.Timeout`, `RequestOptions.Timeout` |

## Verify webhooks

Affinity signs each webhook delivery with the endpoint's secret (`whsec_...`, returned once by `Webhooks.CreateAsync`). The `Affinity-Signature` header is `t=<unix seconds>,v1=<hex>`; it can have more than one `v1`. The SDK does not include a verifier. Use this code (.NET Core 2.1 or later). Pass the raw request body bytes, not parsed and serialized JSON.

```csharp
using System.Security.Cryptography;
using System.Text;

public static class AffinityWebhook
{
    /// <summary>
    /// Returns true when the Affinity-Signature header (t=unix,v1=hex[,v1=hex]) signs rawBody with
    /// secret (whsec_...) and t is within 300 seconds of now.
    /// </summary>
    public static bool Verify(string? signatureHeader, byte[] rawBody, string secret, DateTimeOffset? now = null)
    {
        if (string.IsNullOrEmpty(signatureHeader)) return false;
        long? timestamp = null;
        var signatures = new List<string>();
        foreach (var part in signatureHeader.Split(','))
        {
            var pair = part.Trim().Split(new[] { '=' }, 2);
            if (pair.Length != 2) continue;
            if (pair[0] == "t" && long.TryParse(pair[1], out var t)) timestamp = t;
            else if (pair[0] == "v1") signatures.Add(pair[1]);
        }
        if (timestamp is null || signatures.Count == 0) return false;
        var current = (now ?? DateTimeOffset.UtcNow).ToUnixTimeSeconds();
        if (Math.Abs(current - timestamp.Value) > 300) return false;

        var prefix = Encoding.UTF8.GetBytes(timestamp.Value + ".");
        var signed = new byte[prefix.Length + rawBody.Length];
        prefix.CopyTo(signed, 0);
        rawBody.CopyTo(signed, prefix.Length);
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
        var expected = Encoding.ASCII.GetBytes(
            BitConverter.ToString(hmac.ComputeHash(signed)).Replace("-", "").ToLowerInvariant());
        foreach (var signature in signatures)
        {
            var actual = Encoding.ASCII.GetBytes(signature);
            if (CryptographicOperations.FixedTimeEquals(actual, expected)) return true;
        }
        return false;
    }
}
```

In ASP.NET Core, read the body with `using var buffer = new MemoryStream(); await Request.Body.CopyToAsync(buffer);` and call `AffinityWebhook.Verify(Request.Headers["Affinity-Signature"], buffer.ToArray(), secret)`. Reply with 400 when it returns false. The same code is in `tests/Affinity.Smoke/AffinityWebhook.cs`, which checks it against a signature made with `openssl dgst -sha256 -hmac` and against a changed body.

## Documentation

- [docs/reference.md](docs/reference.md): every method, generated by Fern.
- [docs.affinityrx.com](https://docs.affinityrx.com): API guides and reference.

## Build and verify

[Fern](https://buildwithfern.com) generates `src/Affinity` and `src/Affinity.Test` locally, in Docker, from `spec/affinity.openapi.json`, the committed Affinity API contract. It needs no Fern account. [generation.json](generation.json) records the contract hash and the Fern and generator versions.

The commands use the official .NET 8 SDK image:

```sh
docker run --rm -v "$PWD":/src -w /src mcr.microsoft.com/dotnet/sdk:8.0 sh -c '
  dotnet build src/Affinity/Affinity.csproj -c Release &&
  dotnet test src/Affinity.Test/Affinity.Test.csproj &&
  dotnet run --project tests/Affinity.Smoke -- webhook &&
  dotnet pack src/Affinity/Affinity.csproj -c Release -o artifacts'

scripts/generate.sh         # regenerate after the contract changes (needs Docker, Node and jq)
scripts/generate-check.sh   # regenerate and fail on any difference
```

`dotnet test` runs Fern's generated tests against a local mock server; they need no key.

The smoke test calls every operation against a real API in Test mode. It refuses a key that does not start with `sk_test_`. Use a platform Test key: it creates a Test practice and a Test order, then cancels the order. Set `AFFINITY_BASE_URL` to call another API, and `AFFINITY_SMOKE_WEBHOOK_URL` to include webhook endpoints:

```sh
docker run --rm --env-file smoke.env -v "$PWD":/src -w /src mcr.microsoft.com/dotnet/sdk:8.0 \
  dotnet run --project tests/Affinity.Smoke
```
