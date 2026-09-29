# C# SDK proposal

> **Proposed interface.**
  These examples describe the SDK we plan to build. They are for review and do not run against the
  current release. Package versions and migration steps will follow approval.


.NET server applications. Cancellation tokens remain available on asynchronous methods. [Source repository](https://github.com/affinity-health/affinity-csharp) · [All SDKs](https://docs.joinaffinityai.com/guides/reference/sdks/) · [Shared conventions](https://docs.joinaffinityai.com/guides/reference/sdks/methods/)

## Connect

Set `AFFINITY_API_KEY` to a Test API key on your server. The key selects Test or Live mode. Keep it out of browser and mobile code.

```csharp
using Affinity;

var api = new AffinityClient(Environment.GetEnvironmentVariable("AFFINITY_API_KEY")!);
```

## With a practice key

The key identifies the practice. No practice ID or scoped client is needed.
The resource IDs below come from records in that practice.
Each section is a separate usage example, not one script to concatenate.

```csharp
var patients = await api.Patients.ListAsync(new PatientListParams { Limit = 20 });
var patient = await api.Patients.GetAsync(patientId);
var items = await api.Catalog.Items.ListAsync(new CatalogItemListParams { Limit = 20 });
```

## With a platform key

Pass the target practice with each practice-scoped request. Keep record data separate from request context and idempotency options.

```csharp
var options = new RequestOptions { PracticeId = practiceId };
var patients = await api.Patients.ListAsync(new PatientListParams { Limit = 20 }, options);
var patient = await api.Patients.GetAsync(patientId, options);

await api.Patients.UpdateAsync(
    patientId,
    new PatientUpdateParams { Email = "alex@example.com" },
    new RequestOptions {
        PracticeId = practiceId,
    }
);
```

## Scope a workflow once

A scoped client remembers the practice for subsequent requests. It is immutable; the original client and other scoped clients stay independent.
A conflicting practice ID produces an error. Scoping never grants access to another practice.

```csharp
var practice = api.ForPractice(practiceId);

var patients = await practice.Patients.ListAsync(new PatientListParams { Limit = 20 });
var items = await practice.Catalog.Items.ListAsync(new CatalogItemListParams { Limit = 20 });
```

The following examples use this scoped client. A practice-key client supports the same calls without the scoping step.

## Create, get, and update a patient

Use synthetic Test data. Routine writes generate a fresh idempotency key per call and preserve it during internal retries.
Supply your own persisted key when retrying across calls or process restarts.

```csharp
var patient = await practice.Patients.CreateAsync(new PatientCreateParams {
    Name = new PatientName { First = "Alex", Last = "Example" },
    DateOfBirth = "1990-01-01",
});

var saved = await practice.Patients.GetAsync(patient.Id);
await practice.Patients.UpdateAsync(patient.Id, new PatientUpdateParams {
    Email = "alex@example.com",
});

await practice.Patients.UpdateAsync(patient.Id, new PatientUpdateParams {
    Status = "archived",
});
```

Archive patients whose records you need to retain. Permanent deletion is available only for patients without order history. No explicit idempotency key is needed.

```csharp
await practice.Patients.DeleteAsync(patientId);
```

## Create an order draft

`draft` is your application's prepared prescription data, using catalog and prescribing options from this practice.
An order contains 1–20 complete prescriptions for one patient. This example creates an unsigned draft.
It shows a platform call without a scoped client: practice context and the persisted key belong together in request options.

`job` is your persisted workflow record. Generate and save a unique key for each action before making its first request.

```csharp
var order = await api.Orders.CreateAsync(
    new OrderCreateParams { PatientId = patientId, Prescriptions = draft.Prescriptions },
    new RequestOptions { PracticeId = practiceId, IdempotencyKey = job.CreateOrderKey }
);
```

## Sign and submit

`review` is your saved clinician review and signing consent for this exact order.
Store the reviewed revision, authorized prescriber ID, and explicit attestation together.
Your API key needs `orders:sign`. Never infer consent or automatically replace a stale revision.

```csharp
await practice.Orders.SignAsync(
    orderId,
    new OrderSignParams {
        Prescriber = new PrescriberSelector { Id = review.PrescriberId },
        ExpectedRevision = review.OrderRevision,
        SignatureAttestation = review.SignatureAttestation,
    },
    new RequestOptions { IdempotencyKey = job.SignOrderKey }
);

var submission = await practice.Orders.SubmitAsync(orderId,
    new RequestOptions { IdempotencyKey = job.SubmitOrderKey });
```

Use separate keys for creating, signing, and submitting. After an uncertain response, retry the same action with the same key and unchanged data.
A revision conflict requires renewed clinician review before another signing attempt.

Submission means queued, not accepted by the pharmacy. Inspect the result and track order events or webhooks.
After a reported partial submission failure, retry only the unconfirmed send with a new submission key.

## Read more than one page

The list method returns one page. Pass the last record's ID to request the next page.
The iterator fetches pages as you consume records; it does not load the full collection into memory.
`syncPatient` or its language equivalent represents your application's record handler.

```csharp
var page = await practice.Patients.ListAsync(new PatientListParams { Limit = 20 });
if (page.HasMore && page.Data.Any()) {
    var next = await practice.Patients.ListAsync(new PatientListParams {
        Limit = 20, StartingAfter = page.Data.Last().Id,
    });
}

await foreach (var patient in practice.Patients.IterateAsync(new PatientListParams { Limit = 100 })) {
    await SyncPatientAsync(patient);
}
```

## Handle errors

API failures expose status, code, request ID, retryability, and an optional retry delay in seconds.
Log those fields without logging patient data or credentials. Transport failures remain distinguishable from API responses.

```csharp
try {
    await practice.Patients.GetAsync(patientId);
} catch (AffinityException error) {
    Console.Error.WriteLine(
        $"status={error.Status} code={error.Code} request={error.RequestId} " +
        $"retryable={error.Retryable} retryAfter={error.RetryAfter}");
}
```

Retryability is a transport hint, not permission to repeat a clinical action with a new key.
Keep the same key and body for an uncertain write. Validation and authorization errors require a corrected request.
See [API errors](https://docs.joinaffinityai.com/errors/) for recovery guidance.

## Platform directory and webhooks

Use the root platform client to list its practices and webhook endpoints. These calls do not need a target practice or an idempotency key.
The webhook list belongs to the platform itself. Access to another organization's endpoints still requires an explicit grant.

```csharp
var practices = await api.Practices.ListAsync(new PracticeListParams { Limit = 20 });
var selected = await api.Practices.GetAsync(practiceId);
var endpoints = await api.Webhooks.Endpoints.ListAsync(new WebhookEndpointListParams { Limit = 20 });
```

## More resources

Use the same conventions for addresses, allergies, locations, team members, and nested order resources.
[Resource directory](https://docs.joinaffinityai.com/guides/reference/sdks/methods/) · [API reference](https://docs.joinaffinityai.com/api/) · [Webhooks](https://docs.joinaffinityai.com/guides/webhooks/)
