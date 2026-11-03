# Reference
## Account
<details><summary><code>client.Account.<a href="/src/Affinity/Account/AccountClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;Account&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Read the organization and Test or Live mode selected by the API key.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Account.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Feedback
<details><summary><code>client.Feedback.<a href="/src/Affinity/Feedback/FeedbackClient.cs">CreateAsync</a>(CreateFeedbackRequest { ... }) -> WithRawResponseTask&lt;CreateFeedbackResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Send feedback without credentials, or with an API key to include its organization and mode. Do not include patient information. API-key callers are limited to 10 submissions per hour per key. Anonymous callers are limited to 10 submissions per hour per IP address. A 429 response includes Retry-After in seconds.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Feedback.CreateAsync(
    new CreateFeedbackRequest
    {
        IdempotencyKey = "Idempotency-Key",
        Message = "The error does not explain which field is invalid.",
        PageUrl = "https://docs.affinityrx.com/errors/",
        RequestId = "6e562761-eff3-4626-a8b9-25ce7c670ccd",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateFeedbackRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Medications
<details><summary><code>client.Medications.<a href="/src/Affinity/Medications/MedicationsClient.cs">ListAsync</a>(ListMedicationsRequest { ... }) -> Pager&lt;Medication&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Every medication you can order in the current mode, A to Z by name, then by ID. The list has no text search: read every page and choose by name, strength, form and pharmacy. Send practiceId to list what that practice can order, at its prices; without it, the caller's organization is used. Prices are in cents. `requirements` names the optional prescription fields this pharmacy requires; `compoundingReasons` and `quantities` list the accepted values when the pharmacy limits them, counted in `quantityUnit`. With a `fill`, `price` is per fill and each quantity counts `quantityUnit`, not fills: it is a whole number of fills in units. For a fill of 30 tablets, quantity 60 is two fills. For vials, quantity 1 is one vial and quantity 2 is two vials. A 2 mL vial lists quantities 1–10; its volume is separate from its quantity.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Medications.ListAsync(
    new ListMedicationsRequest { PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListMedicationsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Medications.<a href="/src/Affinity/Medications/MedicationsClient.cs">GetAsync</a>(GetMedicationsRequest { ... }) -> WithRawResponseTask&lt;GetMedicationsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Read one available medication, its pricing, and pharmacy details for the current organization and mode. Pass expand=variants to include its other strengths, forms and pharmacies.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Medications.GetAsync(
    new GetMedicationsRequest
    {
        MedicationId = "med_01j2y8m6jcc9tt24af5pw9x1bc",
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetMedicationsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Orders
<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">ListAsync</a>(ListOrdersRequest { ... }) -> Pager&lt;Order&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List accessible orders in the current mode, newest first. `externalOrderId` matches exactly, including case. `updatedAfter` accepts an ISO 8601 timestamp with a timezone and returns strictly later updates. Keep filters fixed while paging. `sort` takes `patient` (lowercase firstName + space + lastName A to Z, then order ID) or `created` (oldest first); a `_desc` suffix reverses. Creation time or patient name and the order ID determine cursor order, even when updatedAt changes.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Orders.ListAsync(
    new ListOrdersRequest
    {
        PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListOrdersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">CreateAsync</a>(OrderInput { ... }) -> WithRawResponseTask&lt;Order&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

One request creates the order, signs it and sends it to the pharmacy. Platforms must send practiceId; practice callers can omit it to use their own practice. With an API key, name the prescriber and send signatureAttestation. Optional prescriber phone and address each default to the practice; no account is looked up by NPI. In the app, the signed-in member signs with the NPI in their settings, or names the prescriber with the same attestation. With patient.externalId, the order reuses that patient of the practice and mode and updates the saved record; without it, each order creates a new patient. When the pharmacy already holds the patient's name, a different firstName or lastName returns 422 invalid_order. Live orders require Live access on the practice and its platform. No payment method is required.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Orders.CreateAsync(
    new OrderInput
    {
        IdempotencyKey = "Idempotency-Key",
        Patient = new PatientInput
        {
            Address = new AddressInput
            {
                Line1 = "line1",
                City = "city",
                State = "state",
                PostalCode = "postalCode",
            },
            Allergies = new List<PatientInputAllergiesItem>()
            {
                new PatientInputAllergiesItem
                {
                    Category = PatientInputAllergiesItemCategory.Drug,
                    Display = "display",
                },
            },
            DateOfBirth = "dateOfBirth",
            Email = "email",
            FirstName = "firstName",
            Sex = PatientInputSex.Female,
            LastName = "lastName",
            Phone = "phone",
        },
        Prescriptions = new List<PrescriptionInput>()
        {
            new PrescriptionInput
            {
                Directions = "directions",
                MedicationId = "med_01j2y8m6jcc9tt24af5pw9x1bc",
                Quantity = 1,
                Refills = 1,
            },
        },
        Shipping = new OrderInputShipping { OptionId = "shp_01j2y8m6jcc9tt24af5pw9x1bc" },
        SignatureAttestation = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `OrderInput` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">GetAsync</a>(GetOrdersRequest { ... }) -> WithRawResponseTask&lt;Order&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Read one order and its prescriptions in the API key's organization and mode.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Orders.GetAsync(new GetOrdersRequest { OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetOrdersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">CancelAsync</a>(CancelOrdersRequest { ... }) -> WithRawResponseTask&lt;Order&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

200 with status cancelled when the cancel is confirmed. 202 with cancelRequestedAt when the pharmacy has not confirmed yet: you get order.cancelled when it confirms, or, when it refuses, cancelRequestedAt becomes null and you get order.updated. If an earlier ask may have reached the pharmacy, a refusal keeps cancelRequestedAt and sends no event until the pharmacy ends the order (order.cancelled or order.shipped). 409 cannot_cancel when the order is shipped, delivered or failed. 409 cancel_refused when the pharmacy refused the cancel, or when Affinity could not reach the pharmacy; only the second says to retry with a new Idempotency-Key.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Orders.CancelAsync(
    new CancelOrdersRequest
    {
        OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CancelOrdersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Practices
<details><summary><code>client.Practices.<a href="/src/Affinity/Practices/PracticesClient.cs">ListAsync</a>(ListPracticesRequest { ... }) -> Pager&lt;Practice&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List the platform's practices, newest first. Available to platforms only. `sort` takes `name` or `location` (A to Z, practices without a location last), `mode` (without Live access, then with it) or `created` (oldest first); a `_desc` suffix reverses.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Practices.ListAsync(new ListPracticesRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListPracticesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Practices.<a href="/src/Affinity/Practices/PracticesClient.cs">CreateAsync</a>(CreatePracticesRequest { ... }) -> WithRawResponseTask&lt;Practice&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Platforms only. Name, phone and address are required. The practice starts in Test; `liveEnabled: true` also allows new Live orders, which needs a platform with Live access and a Live caller: a Live key, or a session in Live mode. Turning Live off later preserves access to existing records. A retry with the same key and body returns the stored first response, even if the practice has changed. Use GET /v1/practices/{practiceId} to read the current practice.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Practices.CreateAsync(
    new CreatePracticesRequest
    {
        IdempotencyKey = "Idempotency-Key",
        Address = new PracticeAddressInput
        {
            Line1 = "line1",
            City = "city",
            State = "state",
            PostalCode = "postalCode",
        },
        Name = "name",
        Phone = "phone",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreatePracticesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Practices.<a href="/src/Affinity/Practices/PracticesClient.cs">GetAsync</a>(GetPracticesRequest { ... }) -> WithRawResponseTask&lt;Practice&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Read one practice accessible to the API key. A platform can read its own practices.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Practices.GetAsync(
    new GetPracticesRequest { PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetPracticesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Practices.<a href="/src/Affinity/Practices/PracticesClient.cs">UpdateAsync</a>(UpdatePracticesRequest { ... }) -> WithRawResponseTask&lt;Practice&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

`liveEnabled` allows or refuses new Live orders. Existing records, cancellation, webhooks and billing keep working. Only its platform changes it; enabling requires platform Live access, and either change needs a Live caller: a Live key (403 live_key_required otherwise) or a session in Live mode (403 live_mode_required otherwise). Live orders send `name`, `phone` and `address` to the pharmacy, so a practice with Live access changes them only in Live mode, with a Live key or a session in Live mode (403 live_mode_required otherwise). A retry with the same key and body returns the stored first response, even if the practice has changed. Use GET /v1/practices/{practiceId} to read the current practice.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Practices.UpdateAsync(
    new UpdatePracticesRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdatePracticesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Webhooks
<details><summary><code>client.Webhooks.<a href="/src/Affinity/Webhooks/WebhooksClient.cs">ListAsync</a>(ListWebhooksRequest { ... }) -> Pager&lt;WebhookEndpoint&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List webhook endpoints owned by the API key's organization in its current mode. Signing secrets are not returned.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Webhooks.ListAsync(new ListWebhooksRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListWebhooksRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Affinity/Webhooks/WebhooksClient.cs">CreateAsync</a>(CreateWebhooksRequest { ... }) -> WithRawResponseTask&lt;CreateWebhooksResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Platforms and independent practices can register up to 16 public HTTPS endpoints per mode. An API key acts only for its own organization and mode. Every event goes to every endpoint. The signing secret is returned by creation and its idempotent replay for 24 hours.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Webhooks.CreateAsync(
    new CreateWebhooksRequest { IdempotencyKey = "Idempotency-Key", Url = "url" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateWebhooksRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Affinity/Webhooks/WebhooksClient.cs">RemoveAsync</a>(RemoveWebhooksRequest { ... }) -> WithRawResponseTask&lt;RemoveWebhooksResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Events not delivered to it yet are dropped.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Webhooks.RemoveAsync(
    new RemoveWebhooksRequest { WebhookEndpointId = "whe_01j2y8m6jcc9tt24af5pw9x1bc" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RemoveWebhooksRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Affinity/Webhooks/WebhooksClient.cs">UpdateAsync</a>(UpdateWebhooksRequest { ... }) -> WithRawResponseTask&lt;WebhookEndpoint&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

The signing secret stays the same.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Webhooks.UpdateAsync(
    new UpdateWebhooksRequest
    {
        WebhookEndpointId = "whe_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        Url = "url",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateWebhooksRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Affinity/Webhooks/WebhooksClient.cs">ResendFailedAsync</a>(ResendFailedWebhooksRequest { ... }) -> WithRawResponseTask&lt;ResendFailedWebhooksResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Queue failed order event deliveries from the last 30 days for this endpoint. Only the current organization and mode apply. Each failed delivery gets up to 12 new attempts. Also make pending deliveries waiting on a later retry due now, without resetting their attempt counts. Keep the same event IDs, payloads, and per-order delivery sequence. The queued count includes both kinds. Pending deliveries already due, delivered events, and one-time test events stay unchanged. Send a unique Idempotency-Key for each request. Reuse that key after an uncertain response to return the original count. A request with a new key returns 0 when no eligible failures or pending deliveries waiting on a later retry remain.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Webhooks.ResendFailedAsync(
    new ResendFailedWebhooksRequest
    {
        WebhookEndpointId = "whe_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ResendFailedWebhooksRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

