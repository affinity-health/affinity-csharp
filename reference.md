# Reference
## Locations
<details><summary><code>client.Locations.<a href="/src/Affinity/Locations/LocationsClient.cs">ListPracticeLocationsAsync</a>(ListPracticeLocationsRequest { ... }) -> WithRawResponseTask&lt;ListPracticeLocationsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires locations:read on a practice key or an authorized platform key. Lists active and archived locations by name, with cursor pagination. Use status to filter. Location records are shared between Test and Live for the same practice.
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
await client.Locations.ListPracticeLocationsAsync(
    new ListPracticeLocationsRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        StartingAfter = "loc_01j2y8m6jcc9tt24af5pw9x1bc",
        EndingBefore = "loc_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `ListPracticeLocationsRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.<a href="/src/Affinity/Locations/LocationsClient.cs">CreatePracticeLocationAsync</a>(CreatePracticeLocationRequest { ... }) -> WithRawResponseTask&lt;CreatePracticeLocationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires locations:write and Idempotency-Key for API keys. Creates an active location with a unique name in this practice. Locations are shared between Test and Live. Use the returned ID for Team location access.
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
await client.Locations.CreatePracticeLocationAsync(
    new CreatePracticeLocationRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        Name = "name",
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

**request:** `CreatePracticeLocationRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.<a href="/src/Affinity/Locations/LocationsClient.cs">GetPracticeLocationAsync</a>(GetPracticeLocationRequest { ... }) -> WithRawResponseTask&lt;GetPracticeLocationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires locations:read. Returns one active or archived location in the authorized practice.
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
await client.Locations.GetPracticeLocationAsync(
    new GetPracticeLocationRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        LocationId = "loc_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `GetPracticeLocationRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.<a href="/src/Affinity/Locations/LocationsClient.cs">UpdatePracticeLocationAsync</a>(UpdatePracticeLocationRequest { ... }) -> WithRawResponseTask&lt;UpdatePracticeLocationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires locations:write and Idempotency-Key for API keys. Updates only supplied fields; null clears optional contact and address fields. Archived locations cannot be updated. Changes apply to both Test and Live.
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
await client.Locations.UpdatePracticeLocationAsync(
    new UpdatePracticeLocationRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        LocationId = "loc_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `UpdatePracticeLocationRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.<a href="/src/Affinity/Locations/LocationsClient.cs">ArchivePracticeLocationAsync</a>(ArchivePracticeLocationRequest { ... }) -> WithRawResponseTask&lt;ArchivePracticeLocationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires locations:write and Idempotency-Key for API keys. Retains the location and historical associations. Archived locations cannot receive new Team assignments. Repeating archive returns the archived location. Changes apply to both Test and Live.
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
await client.Locations.ArchivePracticeLocationAsync(
    new ArchivePracticeLocationRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        LocationId = "loc_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `ArchivePracticeLocationRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## API Keys
<details><summary><code>client.ApiKeys.<a href="/src/Affinity/ApiKeys/ApiKeysClient.cs">CreatePlatformPracticeApiKeyAsync</a>(CreatePlatformPracticeApiKeyRequest { ... }) -> WithRawResponseTask&lt;CreatePlatformPracticeApiKeyResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a practice API key for a connected practice. Requires a platform key with service_keys:write and every requested scope. The practice key uses the platform key's Test or Live mode and cannot outlive it. Requires Idempotency-Key for safe retries; the secret is returned in the encrypted replay response for 24 hours.
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
await client.ApiKeys.CreatePlatformPracticeApiKeyAsync(
    new CreatePlatformPracticeApiKeyRequest
    {
        PracticeId = "practiceId",
        IdempotencyKey = "Idempotency-Key",
        Name = "name",
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

**request:** `CreatePlatformPracticeApiKeyRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ApiKeys.<a href="/src/Affinity/ApiKeys/ApiKeysClient.cs">GetApiAccessAsync</a>() -> WithRawResponseTask&lt;GetApiAccessResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the subject, mode, and scopes for the API key.
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
await client.ApiKeys.GetApiAccessAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Account
<details><summary><code>client.Account.<a href="/src/Affinity/Account/AccountClient.cs">GetAccountAsync</a>(GetAccountRequest { ... }) -> WithRawResponseTask&lt;GetAccountResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the platform organization, request livemode, and effective access. API keys report scopes and the service_key role; dashboard sessions report membership permissions. operatingMode describes organization Live access, not the credential's Test/Live mode.
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
await client.Account.GetAccountAsync(
    new GetAccountRequest { OrgId = "acct_01j2y8m6jcc9tt24af5pw9x1bc" }
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

**request:** `GetAccountRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Catalog
<details><summary><code>client.Catalog.<a href="/src/Affinity/Catalog/CatalogClient.cs">ListCatalogItemsAsync</a>(ListCatalogItemsRequest { ... }) -> WithRawResponseTask&lt;ListCatalogItemsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists catalog items for the authenticated account and mode. Use view=medications for priced prescription groups with offer counts, pharmacy counts, and strengths; the default view=offers returns individual offers. Use relatedToCatalogItemId to find offers for the same medication and route. When practiceId is supplied, a practice price overrides the platform price and missing overrides inherit the platform price.
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
await client.Catalog.ListCatalogItemsAsync(
    new ListCatalogItemsRequest
    {
        RelatedToCatalogItemId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
        CatalogItemId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
        PharmacyIds = "pharm_01j2y8m6jcc9tt24af5pw9x1bc",
        EndingBefore = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
        OrgId = "acct_01j2y8m6jcc9tt24af5pw9x1bc",
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        StartingAfter = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `ListCatalogItemsRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Catalog.<a href="/src/Affinity/Catalog/CatalogClient.cs">ListPharmaciesAsync</a>(ListPharmaciesRequest { ... }) -> WithRawResponseTask&lt;ListPharmaciesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists pharmacies available to the authenticated account, including approved invite-only relationships.
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
await client.Catalog.ListPharmaciesAsync(
    new ListPharmaciesRequest
    {
        EndingBefore = "pharm_01j2y8m6jcc9tt24af5pw9x1bc",
        OrgId = "acct_01j2y8m6jcc9tt24af5pw9x1bc",
        PharmacyId = "pharm_01j2y8m6jcc9tt24af5pw9x1bc",
        StartingAfter = "pharm_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `ListPharmaciesRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Catalog.<a href="/src/Affinity/Catalog/CatalogClient.cs">ListShippingOptionsAsync</a>(ListShippingOptionsRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;ListShippingOptionsResponseItem&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns an array of at most 50 reviewed shipping services eligible for a catalog item, destination, and API mode. destinationState must be a USPS state or territory code. Each option has one temperature; pharmacy catalog summaries list all supported temperatures.
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
await client.Catalog.ListShippingOptionsAsync(
    new ListShippingOptionsRequest
    {
        CatalogItemId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
        DestinationState = "destinationState",
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

**request:** `ListShippingOptionsRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Catalog.<a href="/src/Affinity/Catalog/CatalogClient.cs">RetrievePrescribingOptionsAsync</a>(RetrievePrescribingOptionsRequest { ... }) -> WithRawResponseTask&lt;RetrievePrescribingOptionsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires catalog:read. Returns reviewed SIG presets, guided patterns, quantity constraints and product requirements for a practice and mode. Revisions identify changed defaults. No patient-specific rationale or diagnosis is inferred.
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
await client.Catalog.RetrievePrescribingOptionsAsync(
    new RetrievePrescribingOptionsRequest
    {
        CatalogItemId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `RetrievePrescribingOptionsRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Orders
<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">ListOrdersAsync</a>(ListOrdersRequest { ... }) -> WithRawResponseTask&lt;ListOrdersResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Orders.ListOrdersAsync(
    new ListOrdersRequest
    {
        EndingBefore = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
        OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
        PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        StartingAfter = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
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

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">CreateOrderAsync</a>(CreateOrderRequest { ... }) -> WithRawResponseTask&lt;CreateOrderResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates one unsigned order with 1–20 prescriptions for one patient in one practice. Supply patientId or patient; inline patient creation requires patients:write. Prescriber is optional: select by npi, provider id, or integration-scoped externalId, or leave the draft unassigned until signing. First-use prescriber registration requires team:write. Legacy userId is supported but cannot be combined with prescriber. Idempotency-Key is required.
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
await client.Orders.CreateOrderAsync(
    new CreateOrderRequest
    {
        IdempotencyKey = "Idempotency-Key",
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        Prescriptions = new List<CreateOrderRequestPrescriptionsItem>()
        {
            new CreateOrderRequestPrescriptionsItem
            {
                DaysSupply = 1,
                Dispensing = new CreateOrderRequestPrescriptionsItemDispensing(),
                Directions = "directions",
                MedicationId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
                Quantity = CreateOrderRequestPrescriptionsItemQuantityOne.Infinity,
                QuantityUnit = "quantityUnit",
                Refills = 1,
            },
        },
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

**request:** `CreateOrderRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">GetOrderAsync</a>(GetOrderRequest { ... }) -> WithRawResponseTask&lt;GetOrderResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Orders.GetOrderAsync(
    new GetOrderRequest { OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc" }
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

**request:** `GetOrderRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">CancelOrderAsync</a>(CancelOrderRequest { ... }) -> WithRawResponseTask&lt;CancelOrderResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requests cancellation. HTTP 200 means the request was handled; check cancellation.status for confirmed, pending, partial, or failed. Only confirmed means the entire order is cancelled. Shipment possession makes a fulfillment cancellation too late.
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
await client.Orders.CancelOrderAsync(
    new CancelOrderRequest
    {
        OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        Reason = "reason",
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

**request:** `CancelOrderRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">ActOnOrderExceptionAsync</a>(ActOnOrderExceptionRequest { ... }) -> WithRawResponseTask&lt;ActOnOrderExceptionResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Acknowledge, retry, contact, or resolve an order exception in the credential's Test/Live mode. assign_to_me requires a signed-in dashboard user; API keys receive 400 and may use acknowledge instead. Actor headers do not create a dashboard assignee.
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
await client.Orders.ActOnOrderExceptionAsync(
    new ActOnOrderExceptionRequest
    {
        OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
        ExceptionId = "fex_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        Action = ActOnOrderExceptionRequestAction.Acknowledge,
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

**request:** `ActOnOrderExceptionRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">ListOrderEventsAsync</a>(ListOrderEventsRequest { ... }) -> WithRawResponseTask&lt;ListOrderEventsResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Orders.ListOrderEventsAsync(
    new ListOrderEventsRequest
    {
        OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
        EndingBefore = "evt_01j2y8m6jcc9tt24af5pw9x1bc",
        StartingAfter = "evt_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `ListOrderEventsRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">GetOrderTestSimulationAsync</a>(GetOrderTestSimulationRequest { ... }) -> WithRawResponseTask&lt;GetOrderTestSimulationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires orders:write. Available only in Test mode.
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
await client.Orders.GetOrderTestSimulationAsync(
    new GetOrderTestSimulationRequest { OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc" }
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

**request:** `GetOrderTestSimulationRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">UpdateOrderTestSimulationAsync</a>(UpdateOrderTestSimulationRequest { ... }) -> WithRawResponseTask&lt;UpdateOrderTestSimulationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires orders:write and Idempotency-Key. Configure before submission or queue a valid pharmacy event in manual mode. Events use normal order history and Test webhooks. Live requests are rejected.
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
await client.Orders.UpdateOrderTestSimulationAsync(
    new UpdateOrderTestSimulationRequest
    {
        OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        Mode = UpdateOrderTestSimulationRequestMode.Automatic,
        Scenario = UpdateOrderTestSimulationRequestScenario.Successful,
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

**request:** `UpdateOrderTestSimulationRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">PreviewOrderAsync</a>(PreviewOrderRequest { ... }) -> WithRawResponseTask&lt;PreviewOrderResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires orders:write and catalog:read. Supply exactly one of patientId, patientExternalId, or inline patient details. External-ID lookup additionally requires patients:read; inline details require patients:write. Resolves defaults and explicit edits for 1–20 prescriptions. Reuses stored patient details when identifiers match; otherwise previews inline details without creating a patient. Complete previews contain an orders.create input. Does not create records, reserve prices, sign, charge or transmit. No idempotency key is required. Creation and signing recheck current requirements.
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
await client.Orders.PreviewOrderAsync(
    new PreviewOrderRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        Prescriptions = new List<PreviewOrderRequestPrescriptionsItem>()
        {
            new PreviewOrderRequestPrescriptionsItem
            {
                MedicationId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
            },
        },
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

**request:** `PreviewOrderRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">SignOrderAsync</a>(SignOrderRequest { ... }) -> WithRawResponseTask&lt;SignOrderResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires orders:sign, Idempotency-Key, signatureAttestation, and expectedRevision from the reviewed order. Existing integrations may send expectedVersions instead; supply exactly one. A stale revision returns 409 and requires renewed clinician review. Select prescriber by npi, provider id, or integration-scoped externalId, or inherit the draft's prescriber. First-use registration requires team:write. Actor headers are optional audit metadata with prescriber; legacy userId requires matching clinician actor headers. Signing does not submit to a pharmacy.
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
await client.Orders.SignOrderAsync(
    new SignOrderRequest
    {
        OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `SignOrderRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">SignAndSubmitOrderAsync</a>(SignAndSubmitOrderRequest { ... }) -> WithRawResponseTask&lt;SignAndSubmitOrderResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires orders:sign, Idempotency-Key, signatureAttestation, and expectedRevision from the reviewed order. Existing integrations may send expectedVersions instead; supply exactly one. A stale revision returns 409 and requires renewed clinician review. Select prescriber by npi, provider id, or externalId, or inherit the draft's prescriber. First-use registration requires team:write. Actor headers are optional with prescriber; legacy userId requires matching clinician actor headers. Signs the complete order, then attempts each submission. Signing remains committed if submission fails. Replay the same key after an uncertain response; retry reported submission failures through Submit order with a new key. Submitted means queued, not pharmacy acceptance.
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
await client.Orders.SignAndSubmitOrderAsync(
    new SignAndSubmitOrderRequest
    {
        OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `SignAndSubmitOrderRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">SubmitOrderAsync</a>(SubmitOrderRequest { ... }) -> WithRawResponseTask&lt;SubmitOrderResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires orders:sign and Idempotency-Key. Queues signed prescriptions after rechecking authorization, signature integrity, billing, and fulfillment eligibility. Track pharmacy acceptance through order reads and webhooks. After a partial failure, retry submission with a new idempotency key; already queued prescriptions are not duplicated.
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
await client.Orders.SubmitOrderAsync(
    new SubmitOrderRequest
    {
        OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
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

**request:** `SubmitOrderRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">RejectOrderAsync</a>(RejectOrderRequest { ... }) -> WithRawResponseTask&lt;RejectOrderResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires orders:sign and Idempotency-Key. Select a prescriber or inherit the draft's prescriber. Legacy userId requires matching clinician actor headers. Supply expectedRevision from the reviewed order, or expectedVersions for existing integrations. Permanently rejects the complete unsigned order after checking its revision.
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
await client.Orders.RejectOrderAsync(
    new RejectOrderRequest
    {
        OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        Reason = "reason",
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

**request:** `RejectOrderRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">AddOrderPrescriptionAsync</a>(AddOrderPrescriptionRequest { ... }) -> WithRawResponseTask&lt;AddOrderPrescriptionResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires orders:write, Idempotency-Key and expectedRevision from the order being edited. Existing integrations may send expectedVersions instead; supply exactly one. Adds a complete prescription to an unsigned Order and returns all new versions. Omitted actor context defaults to the authenticated service account as a system actor. Patient and prescriber attribution stay fixed. Signed orders cannot be amended through this endpoint. Signing and submission require orders:sign through their separate endpoints.
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
await client.Orders.AddOrderPrescriptionAsync(
    new AddOrderPrescriptionRequest
    {
        OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        Prescription = new AddOrderPrescriptionRequestPrescription
        {
            DaysSupply = 1,
            Dispensing = new AddOrderPrescriptionRequestPrescriptionDispensing(),
            Directions = "directions",
            MedicationId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
            Quantity = AddOrderPrescriptionRequestPrescriptionQuantityOne.Infinity,
            QuantityUnit = "quantityUnit",
            Refills = 1,
        },
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

**request:** `AddOrderPrescriptionRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">UpdateOrderPrescriptionAsync</a>(UpdateOrderPrescriptionRequest { ... }) -> WithRawResponseTask&lt;UpdateOrderPrescriptionResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires orders:write, Idempotency-Key and expectedRevision from the order being edited. Existing integrations may send expectedVersions instead; supply exactly one. Replaces one prescription with complete medication instructions and returns all new versions. Omitted actor context defaults to the authenticated service account as a system actor. Patient and prescriber attribution stay fixed. Signed orders cannot be amended through this endpoint. Signing and submission require orders:sign through their separate endpoints.
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
await client.Orders.UpdateOrderPrescriptionAsync(
    new UpdateOrderPrescriptionRequest
    {
        OrderId = "ord_01j2y8m6jcc9tt24af5pw9x1bc",
        PrescriptionId = "rx_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        Prescription = new UpdateOrderPrescriptionRequestPrescription
        {
            DaysSupply = 1,
            Dispensing = new UpdateOrderPrescriptionRequestPrescriptionDispensing(),
            Directions = "directions",
            MedicationId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
            Quantity = UpdateOrderPrescriptionRequestPrescriptionQuantityOne.Infinity,
            QuantityUnit = "quantityUnit",
            Refills = 1,
        },
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

**request:** `UpdateOrderPrescriptionRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Affinity/Orders/OrdersClient.cs">CreateOrderBatchAsync</a>(CreateOrderBatchRequest { ... }) -> WithRawResponseTask&lt;CreateOrderBatchResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates 1–20 orders for distinct patients in one practice, each with 1–20 prescriptions. Each accepts patientId or inline patient details. Orders and newly created patients commit atomically; any failure saves none. Requires orders:write and Idempotency-Key; inline patients also require patients:write. Omitted actor context defaults to the authenticated service account as a system actor. Sign and submit each resulting order separately using orders:sign.
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
await client.Orders.CreateOrderBatchAsync(
    new CreateOrderBatchRequest
    {
        IdempotencyKey = "Idempotency-Key",
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        Orders = new List<CreateOrderBatchRequestOrdersItem>()
        {
            new CreateOrderBatchRequestOrdersItem
            {
                Prescriptions = new List<CreateOrderBatchRequestOrdersItemPrescriptionsItem>()
                {
                    new CreateOrderBatchRequestOrdersItemPrescriptionsItem
                    {
                        DaysSupply = 1,
                        Dispensing =
                            new CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensing(),
                        Directions = "directions",
                        MedicationId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
                        Quantity =
                            CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne.Infinity,
                        QuantityUnit = "quantityUnit",
                        Refills = 1,
                    },
                },
            },
        },
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

**request:** `CreateOrderBatchRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Webhooks
<details><summary><code>client.Webhooks.<a href="/src/Affinity/Webhooks/WebhooksClient.cs">ListWebhookEndpointsAsync</a>(ListWebhookEndpointsRequest { ... }) -> WithRawResponseTask&lt;ListWebhookEndpointsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires webhooks:read. Returns endpoints owned by the key organization, or the organization selected with X-Affinity-Organization-Id. Platform delegation requires a webhook grant in the key's mode.
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
await client.Webhooks.ListWebhookEndpointsAsync(
    new ListWebhookEndpointsRequest
    {
        EndingBefore = "whe_01j2y8m6jcc9tt24af5pw9x1bc",
        StartingAfter = "whe_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `ListWebhookEndpointsRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Affinity/Webhooks/WebhooksClient.cs">CreateWebhookEndpointAsync</a>(CreateWebhookEndpointRequest { ... }) -> WithRawResponseTask&lt;CreateWebhookEndpointResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires webhooks:write and Idempotency-Key. Defaults to the API key organization. A platform can select a practice or pharmacy owner with X-Affinity-Organization-Id and an explicit webhook grant. For platform-owned endpoints, practiceIds narrows delivery to selected connected practices. An empty filter receives all otherwise-authorized events.
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
await client.Webhooks.CreateWebhookEndpointAsync(
    new CreateWebhookEndpointRequest { IdempotencyKey = "Idempotency-Key", Url = "url" }
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

**request:** `CreateWebhookEndpointRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Affinity/Webhooks/WebhooksClient.cs">DeleteWebhookEndpointAsync</a>(DeleteWebhookEndpointRequest { ... }) -> WithRawResponseTask&lt;DeleteWebhookEndpointResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Webhooks.DeleteWebhookEndpointAsync(
    new DeleteWebhookEndpointRequest
    {
        EndpointId = "whe_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `DeleteWebhookEndpointRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Affinity/Webhooks/WebhooksClient.cs">UpdateWebhookEndpointAsync</a>(UpdateWebhookEndpointRequest { ... }) -> WithRawResponseTask&lt;UpdateWebhookEndpointResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires webhooks:write and Idempotency-Key. Updates an endpoint in the selected organization and mode. Omitted practiceIds preserves the filter; an empty array removes the practice filter. Subscription changes apply to newly generated events.
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
await client.Webhooks.UpdateWebhookEndpointAsync(
    new UpdateWebhookEndpointRequest
    {
        EndpointId = "whe_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `UpdateWebhookEndpointRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Affinity/Webhooks/WebhooksClient.cs">RotateWebhookEndpointSecretAsync</a>(RotateWebhookEndpointSecretRequest { ... }) -> WithRawResponseTask&lt;RotateWebhookEndpointSecretResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Webhooks.RotateWebhookEndpointSecretAsync(
    new RotateWebhookEndpointSecretRequest
    {
        EndpointId = "whe_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `RotateWebhookEndpointSecretRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Affinity/Webhooks/WebhooksClient.cs">TestWebhookEndpointAsync</a>(TestWebhookEndpointRequest { ... }) -> WithRawResponseTask&lt;TestWebhookEndpointResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Webhooks.TestWebhookEndpointAsync(
    new TestWebhookEndpointRequest
    {
        EndpointId = "whe_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `TestWebhookEndpointRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Affinity/Webhooks/WebhooksClient.cs">ListWebhookEventsAsync</a>(ListWebhookEventsRequest { ... }) -> WithRawResponseTask&lt;ListWebhookEventsResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Webhooks.ListWebhookEventsAsync(
    new ListWebhookEventsRequest
    {
        EndingBefore = "evt_01j2y8m6jcc9tt24af5pw9x1bc",
        StartingAfter = "evt_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `ListWebhookEventsRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Affinity/Webhooks/WebhooksClient.cs">GetWebhookEventAsync</a>(GetWebhookEventRequest { ... }) -> WithRawResponseTask&lt;GetWebhookEventResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Webhooks.GetWebhookEventAsync(
    new GetWebhookEventRequest { EventId = "evt_01j2y8m6jcc9tt24af5pw9x1bc" }
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

**request:** `GetWebhookEventRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Affinity/Webhooks/WebhooksClient.cs">ReplayWebhookEventAsync</a>(ReplayWebhookEventRequest { ... }) -> WithRawResponseTask&lt;ReplayWebhookEventResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Webhooks.ReplayWebhookEventAsync(
    new ReplayWebhookEventRequest
    {
        EventId = "evt_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `ReplayWebhookEventRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Affinity/Webhooks/WebhooksClient.cs">ListWebhookGrantsAsync</a>(ListWebhookGrantsRequest { ... }) -> WithRawResponseTask&lt;ListWebhookGrantsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires webhooks:read on the owning practice or pharmacy key. Lists platform webhook grants in the key's mode. Platforms cannot list or grant themselves delegated access.
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
await client.Webhooks.ListWebhookGrantsAsync(
    new ListWebhookGrantsRequest
    {
        StartingAfter = "acct_01j2y8m6jcc9tt24af5pw9x1bc",
        EndingBefore = "acct_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `ListWebhookGrantsRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Affinity/Webhooks/WebhooksClient.cs">SaveWebhookGrantAsync</a>(SaveWebhookGrantRequest { ... }) -> WithRawResponseTask&lt;SaveWebhookGrantResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires webhooks:write on the owning practice or pharmacy key and Idempotency-Key. Grants or replaces a platform's webhook permissions in this mode. A practice must already be connected to that platform. The grant does not give the platform access to other API resources.
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
await client.Webhooks.SaveWebhookGrantAsync(
    new SaveWebhookGrantRequest
    {
        PlatformId = "acct_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        Scopes = new List<SaveWebhookGrantRequestScopesItem>()
        {
            SaveWebhookGrantRequestScopesItem.WebhooksRead,
        },
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

**request:** `SaveWebhookGrantRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Affinity/Webhooks/WebhooksClient.cs">RevokeWebhookGrantAsync</a>(RevokeWebhookGrantRequest { ... }) -> WithRawResponseTask&lt;RevokeWebhookGrantResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires webhooks:write on the owning practice or pharmacy key and Idempotency-Key. Removes platform webhook access in this mode. Existing endpoints remain owned by the practice or pharmacy and continue operating.
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
await client.Webhooks.RevokeWebhookGrantAsync(
    new RevokeWebhookGrantRequest
    {
        PlatformId = "acct_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `RevokeWebhookGrantRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Team
<details><summary><code>client.Team.<a href="/src/Affinity/Team/TeamClient.cs">RegisterUserAsync</a>(RegisterUserRequest { ... }) -> WithRawResponseTask&lt;RegisterUserResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires team:write and Idempotency-Key. Registers a practice member without an invitation. Test requires synthetic .test emails and Affinity Test NPIs. Live requires approved integration and practice access. Identity attestation records the integration's assertion; it does not verify login email or clinical credentials. Existing memberships and verified provider records are preserved. Use the returned user ID for orders and signing.
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
await client.Team.RegisterUserAsync(
    new RegisterUserRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        ExternalId = "externalId",
        Email = "email",
        Name = "name",
        Role = RegisterUserRequestRole.Administrator,
        IdentityAttestation = true,
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

**request:** `RegisterUserRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Team.<a href="/src/Affinity/Team/TeamClient.cs">ListPracticeTeamInvitationsAsync</a>(ListPracticeTeamInvitationsRequest { ... }) -> WithRawResponseTask&lt;ListPracticeTeamInvitationsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires team:read. Lists practice invitations, including invitations sent in Clinic. Filter by pending, expired, accepted, declined, or revoked status, exact email, or your integration externalId. Only your integration and API key mode can see its external identity and onboarding state. Follow person.nextActions after invitation acceptance.
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
await client.Team.ListPracticeTeamInvitationsAsync(
    new ListPracticeTeamInvitationsRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        StartingAfter = "invite_01j2y8m6jcc9tt24af5pw9x1bc",
        EndingBefore = "invite_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `ListPracticeTeamInvitationsRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Team.<a href="/src/Affinity/Team/TeamClient.cs">InvitePracticeTeamPersonAsync</a>(InvitePracticeTeamPersonRequest { ... }) -> WithRawResponseTask&lt;InvitePracticeTeamPersonResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires team:write on the practice key or its platform key. Use roles to combine administrator, prescriber, clinical_staff, billing, or developer presets. Ownership uses the protected owner designation. The singular role field remains available for single-role assignments. Creates a real organization invitation and optional prescriber setup. The recipient must accept with their Affinity account. Repeating the same external identity retries pending invitation delivery. Accepted invitations do not change existing access. Team membership is shared between Test and Live; the external identity is mode-scoped. Keys cannot accept invitations. Headless registration and signing use separate endpoints.
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
await client.Team.InvitePracticeTeamPersonAsync(
    new InvitePracticeTeamPersonRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        ExternalId = "externalId",
        Email = "email",
        Name = "name",
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

**request:** `InvitePracticeTeamPersonRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Team.<a href="/src/Affinity/Team/TeamClient.cs">GetPracticeTeamAsync</a>(GetPracticeTeamRequest { ... }) -> WithRawResponseTask&lt;GetPracticeTeamResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires team:read. Returns counts of members, invitations, and prescribers. Use the paginated members, prescribers, and invitations collections for individual records. Team access and clinician credentials are shared between Test and Live.
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
await client.Team.GetPracticeTeamAsync(
    new GetPracticeTeamRequest { PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc" }
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

**request:** `GetPracticeTeamRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Team.<a href="/src/Affinity/Team/TeamClient.cs">ListPracticeTeamMembersAsync</a>(ListPracticeTeamMembersRequest { ... }) -> WithRawResponseTask&lt;ListPracticeTeamMembersResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires team:read. Search the roster by name or email, and filter by role or membership status. Includes members invited in Clinic, location access, and account-specific prescriber connections. Memberships are shared between Test and Live.
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
await client.Team.ListPracticeTeamMembersAsync(
    new ListPracticeTeamMembersRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        StartingAfter = "mbr_01j2y8m6jcc9tt24af5pw9x1bc",
        EndingBefore = "mbr_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `ListPracticeTeamMembersRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Team.<a href="/src/Affinity/Team/TeamClient.cs">ListPracticeTeamPrescribersAsync</a>(ListPracticeTeamPrescribersRequest { ... }) -> WithRawResponseTask&lt;ListPracticeTeamPrescribersResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires team:read. Filter practice prescribers by name, NPI, state, and practice status. Records include submitted licenses and their IDs. Signing authority also requires an active account connection, Live practice access, and prescription eligibility.
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
await client.Team.ListPracticeTeamPrescribersAsync(
    new ListPracticeTeamPrescribersRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        StartingAfter = "prov_01j2y8m6jcc9tt24af5pw9x1bc",
        EndingBefore = "prov_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `ListPracticeTeamPrescribersRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Team.<a href="/src/Affinity/Team/TeamClient.cs">GetPracticeTeamMemberAsync</a>(GetPracticeTeamMemberRequest { ... }) -> WithRawResponseTask&lt;GetPracticeTeamMemberResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires team:read. Returns current account membership, roles, location access, and prescriber connection. The member ID identifies practice access; it is not the integration user ID used by orders.
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
await client.Team.GetPracticeTeamMemberAsync(
    new GetPracticeTeamMemberRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        MemberId = "mbr_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `GetPracticeTeamMemberRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Team.<a href="/src/Affinity/Team/TeamClient.cs">UpdatePracticeTeamMemberAsync</a>(UpdatePracticeTeamMemberRequest { ... }) -> WithRawResponseTask&lt;UpdatePracticeTeamMemberResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires team:write. Supply role, status, or locationIds; omitted values stay unchanged. A role replaces existing roles. Disable access with status disabled. An empty locationIds array grants all practice locations. Ownership changes require an active practice owner using a personal API key; service keys manage non-owner memberships. The final active owner cannot be removed. Changes apply to both Test and Live. Sign-in email and account security remain account settings.
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
await client.Team.UpdatePracticeTeamMemberAsync(
    new UpdatePracticeTeamMemberRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        MemberId = "mbr_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `UpdatePracticeTeamMemberRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Team.<a href="/src/Affinity/Team/TeamClient.cs">GetPracticeTeamPrescriberAsync</a>(GetPracticeTeamPrescriberRequest { ... }) -> WithRawResponseTask&lt;GetPracticeTeamPrescriberResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires team:read. Returns the clinical profile and submitted licenses, including license IDs. This is setup information, not a signing authorization.
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
await client.Team.GetPracticeTeamPrescriberAsync(
    new GetPracticeTeamPrescriberRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        PrescriberId = "prov_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `GetPracticeTeamPrescriberRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Team.<a href="/src/Affinity/Team/TeamClient.cs">UpdatePracticeTeamPrescriberAsync</a>(UpdatePracticeTeamPrescriberRequest { ... }) -> WithRawResponseTask&lt;UpdatePracticeTeamPrescriberResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires team:write. Set practiceStatus to inactive to remove prescribing access in this practice, or active to restore an existing association. This does not create membership or signing authority. Practice status applies to Test and Live. Shared identity and license edits require Affinity support.
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
await client.Team.UpdatePracticeTeamPrescriberAsync(
    new UpdatePracticeTeamPrescriberRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        PrescriberId = "prov_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `UpdatePracticeTeamPrescriberRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Team.<a href="/src/Affinity/Team/TeamClient.cs">CreatePracticeTeamLicenseAsync</a>(CreatePracticeTeamLicenseRequest { ... }) -> WithRawResponseTask&lt;CreatePracticeTeamLicenseResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires team:write and an active accepted prescriber account connection in this practice. Adds a license. Expiration is optional, but must be in the future when supplied. An exact repeat returns the existing license; update an existing license with PATCH and its license ID. Licenses are shared across practices and Test/Live. Other licenses stay unchanged.
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
await client.Team.CreatePracticeTeamLicenseAsync(
    new CreatePracticeTeamLicenseRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        PrescriberId = "prov_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        State = "state",
        LicenseNumber = "licenseNumber",
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

**request:** `CreatePracticeTeamLicenseRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Team.<a href="/src/Affinity/Team/TeamClient.cs">UpdatePracticeTeamLicenseAsync</a>(UpdatePracticeTeamLicenseRequest { ... }) -> WithRawResponseTask&lt;UpdatePracticeTeamLicenseResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires team:write and an active accepted prescriber account connection in this practice. Correct the state or license number, or set or clear the optional expiresAt value. A supplied expiration must be in the future. Other licenses stay unchanged. Changes apply across practices and Test/Live.
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
await client.Team.UpdatePracticeTeamLicenseAsync(
    new UpdatePracticeTeamLicenseRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        PrescriberId = "prov_01j2y8m6jcc9tt24af5pw9x1bc",
        LicenseId = "lic_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `UpdatePracticeTeamLicenseRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Team.<a href="/src/Affinity/Team/TeamClient.cs">GetPracticeTeamInvitationAsync</a>(GetPracticeTeamInvitationRequest { ... }) -> WithRawResponseTask&lt;GetPracticeTeamInvitationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires team:read. Returns invitation status and current onboarding state for your integration. An accepted invitation can still have disabled membership or pending clinical review. Invitation tokens are never returned.
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
await client.Team.GetPracticeTeamInvitationAsync(
    new GetPracticeTeamInvitationRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        InvitationId = "invite_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `GetPracticeTeamInvitationRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Team.<a href="/src/Affinity/Team/TeamClient.cs">RevokePracticeTeamInvitationAsync</a>(RevokePracticeTeamInvitationRequest { ... }) -> WithRawResponseTask&lt;RevokePracticeTeamInvitationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires team:write. Revokes a pending or expired invitation and its pending prescriber account connection. Repeating the revoke returns the revoked invitation. Accepted invitations return 409; disable the member instead. Retains invitation history.
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
await client.Team.RevokePracticeTeamInvitationAsync(
    new RevokePracticeTeamInvitationRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        InvitationId = "invite_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `RevokePracticeTeamInvitationRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Team.<a href="/src/Affinity/Team/TeamClient.cs">ResendPracticeTeamInvitationAsync</a>(ResendPracticeTeamInvitationRequest { ... }) -> WithRawResponseTask&lt;ResendPracticeTeamInvitationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires team:write. Resends a pending or expired invitation with the same ID, recipient, roles, and locations. The previous link stops working and the new link expires in seven days. Accepted and revoked invitations return 409. A 502 means the invitation was saved but email delivery could not be confirmed; retry this operation.
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
await client.Team.ResendPracticeTeamInvitationAsync(
    new ResendPracticeTeamInvitationRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        InvitationId = "invite_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `ResendPracticeTeamInvitationRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Patients
<details><summary><code>client.Patients.<a href="/src/Affinity/Patients/PatientsClient.cs">ListPatientAddressesAsync</a>(ListPatientAddressesRequest { ... }) -> WithRawResponseTask&lt;ListPatientAddressesResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Patients.ListPatientAddressesAsync(
    new ListPatientAddressesRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
        StartingAfter = "addr_01j2y8m6jcc9tt24af5pw9x1bc",
        EndingBefore = "addr_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `ListPatientAddressesRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Patients.<a href="/src/Affinity/Patients/PatientsClient.cs">CreatePatientAddressAsync</a>(CreatePatientAddressRequest { ... }) -> WithRawResponseTask&lt;CreatePatientAddressResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the existing active address for a normalized duplicate. The first address becomes the default. API keys require Idempotency-Key.
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
await client.Patients.CreatePatientAddressAsync(
    new CreatePatientAddressRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        Address = new CreatePatientAddressRequestAddress
        {
            City = "city",
            Line1 = "line1",
            PostalCode = "postalCode",
            State = "state",
        },
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

**request:** `CreatePatientAddressRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Patients.<a href="/src/Affinity/Patients/PatientsClient.cs">ArchivePatientAddressAsync</a>(ArchivePatientAddressRequest { ... }) -> WithRawResponseTask&lt;ArchivePatientAddressResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Preserves the address ID and history. Archiving the default selects the oldest remaining active address. Existing orders remain unchanged.
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
await client.Patients.ArchivePatientAddressAsync(
    new ArchivePatientAddressRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
        AddressId = "addr_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `ArchivePatientAddressRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Patients.<a href="/src/Affinity/Patients/PatientsClient.cs">UpdatePatientAddressAsync</a>(UpdatePatientAddressRequest { ... }) -> WithRawResponseTask&lt;UpdatePatientAddressResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Patients.UpdatePatientAddressAsync(
    new UpdatePatientAddressRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
        AddressId = "addr_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `UpdatePatientAddressRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Patients.<a href="/src/Affinity/Patients/PatientsClient.cs">SetDefaultPatientAddressAsync</a>(SetDefaultPatientAddressRequest { ... }) -> WithRawResponseTask&lt;SetDefaultPatientAddressResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Changes delivery selection for future drafts, without changing patient clinical location or existing signed orders.
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
await client.Patients.SetDefaultPatientAddressAsync(
    new SetDefaultPatientAddressRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
        AddressId = "addr_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `SetDefaultPatientAddressRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Patients.<a href="/src/Affinity/Patients/PatientsClient.cs">ListPatientsAsync</a>(ListPatientsRequest { ... }) -> WithRawResponseTask&lt;ListPatientsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists patients in one practice and mode. Use externalId for an exact match in the calling integration's namespace. Use externalIdentitySource with externalIdentityValue to search an explicit alias. Identity matching is case-sensitive after trimming whitespace. Other filters also apply.
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
await client.Patients.ListPatientsAsync(
    new ListPatientsRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        EndingBefore = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
        StartingAfter = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `ListPatientsRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Patients.<a href="/src/Affinity/Patients/PatientsClient.cs">CreatePatientAsync</a>(CreatePatientRequest { ... }) -> WithRawResponseTask&lt;CreatePatientResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a patient or resolves a matching externalId or external identity within this practice and mode. externalId belongs to the calling integration; externalIdentities holds aliases from other systems. Resolution preserves existing demographics; use PATCH to update them. Conflicting identifiers return 409. Email never merges patients. API keys require Idempotency-Key.
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
await client.Patients.CreatePatientAsync(
    new CreatePatientRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        DateOfBirth = "dateOfBirth",
        Name = new CreatePatientRequestName { First = "first", Last = "last" },
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

**request:** `CreatePatientRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Patients.<a href="/src/Affinity/Patients/PatientsClient.cs">GetPatientAsync</a>(GetPatientRequest { ... }) -> WithRawResponseTask&lt;GetPatientResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one patient in the authorized practice and mode.
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
await client.Patients.GetPatientAsync(
    new GetPatientRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `GetPatientRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Patients.<a href="/src/Affinity/Patients/PatientsClient.cs">DeletePatientAsync</a>(DeletePatientRequest { ... }) -> WithRawResponseTask&lt;DeletePatientResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires patients:write and Idempotency-Key for API keys. Permanently deletes a patient with no order history. Any order history returns 409; use Update patient with status archived instead. Available to practice keys and authorized platform keys. Reusing the same idempotency key returns the original deletion result.
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
await client.Patients.DeletePatientAsync(
    new DeletePatientRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `DeletePatientRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Patients.<a href="/src/Affinity/Patients/PatientsClient.cs">UpdatePatientAsync</a>(UpdatePatientRequest { ... }) -> WithRawResponseTask&lt;UpdatePatientResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a patient in the current practice and mode. Omitted fields remain unchanged; null clears an optional field. externalId updates the calling integration's identifier. externalIdentities replaces its explicit aliases. Identifiers cannot be reassigned from another patient. API keys require Idempotency-Key.
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
await client.Patients.UpdatePatientAsync(
    new UpdatePatientRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `UpdatePatientRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Patients.<a href="/src/Affinity/Patients/PatientsClient.cs">GetPatientAllergiesAsync</a>(GetPatientAllergiesRequest { ... }) -> WithRawResponseTask&lt;GetPatientAllergiesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the patient's structured allergy entries and review status. A not_reviewed status is not a no-known-allergies assertion and blocks clinical review and signing.
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
await client.Patients.GetPatientAllergiesAsync(
    new GetPatientAllergiesRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `GetPatientAllergiesRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Patients.<a href="/src/Affinity/Patients/PatientsClient.cs">ReplacePatientAllergiesAsync</a>(ReplacePatientAllergiesRequest { ... }) -> WithRawResponseTask&lt;ReplacePatientAllergiesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Replaces the patient's structured allergy record. Sending no_known is the explicit no-known-allergies acknowledgement; recorded requires at least one entry. Idempotency-Key is required.
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
await client.Patients.ReplacePatientAllergiesAsync(
    new ReplacePatientAllergiesRequest
    {
        PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        PatientId = "pat_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        Allergies = new List<ReplacePatientAllergiesRequestAllergiesItem>()
        {
            new ReplacePatientAllergiesRequestAllergiesItem
            {
                Category = ReplacePatientAllergiesRequestAllergiesItemCategory.Drug,
                Reactions = new List<ReplacePatientAllergiesRequestAllergiesItemReactionsItem>()
                {
                    new ReplacePatientAllergiesRequestAllergiesItemReactionsItem
                    {
                        Display = "display",
                    },
                },
                Source = ReplacePatientAllergiesRequestAllergiesItemSource.Doctor,
                Substance = "substance",
                VerificationStatus =
                    ReplacePatientAllergiesRequestAllergiesItemVerificationStatus.Unconfirmed,
            },
        },
        ReviewStatus = ReplacePatientAllergiesRequestReviewStatus.NotReviewed,
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

**request:** `ReplacePatientAllergiesRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Practices
<details><summary><code>client.Practices.<a href="/src/Affinity/Practices/PracticesClient.cs">ListPracticesAsync</a>(ListPracticesRequest { ... }) -> WithRawResponseTask&lt;ListPracticesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the practices that belong to the platform. The default Affinity-Version is 2026-09-28.
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
await client.Practices.ListPracticesAsync(
    new ListPracticesRequest
    {
        EndingBefore = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
        StartingAfter = "prac_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `ListPracticesRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Practices.<a href="/src/Affinity/Practices/PracticesClient.cs">CreatePracticeAsync</a>(CreatePracticeRequest { ... }) -> WithRawResponseTask&lt;CreatePracticeResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a practice owned by the platform. Set liveEnabled to true to enable Live access at creation with an approved platform and a Live request. Defaults to false. Requires practices:write. Send Idempotency-Key when you retry the same request.
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
await client.Practices.CreatePracticeAsync(
    new CreatePracticeRequest
    {
        Address = new CreatePracticeRequestAddress
        {
            City = "Los Angeles",
            Country = "US",
            Line1 = "100 Practice Way",
            PostalCode = "90001",
            State = "CA",
        },
        Attestations = new CreatePracticeRequestAttestations
        {
            AuthorizedPracticeRelationship = true,
            AuthorizedPhiTransfer = true,
            MinimumNecessaryPhi = true,
            ProviderDataAccuracy = true,
        },
        ExternalId = "practice_123",
        LegalName = "Example Medical Group PLLC",
        Metadata = new Dictionary<string, object?>() { { "key", "value" } },
        Name = "Example Medical Group",
        Prescribers = new List<CreatePracticeRequestPrescribersItem>()
        {
            new CreatePracticeRequestPrescribersItem
            {
                Credentials = "MD",
                LicenseStates = new List<string>() { "CA" },
                Name = "Alex Morgan",
                Npi = "1234567893",
            },
        },
        PrimaryContact = new CreatePracticeRequestPrimaryContact
        {
            Email = "operations@example-practice.com",
            Name = "Jordan Lee",
        },
        SupportEmail = "support@example-practice.com",
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

**request:** `CreatePracticeRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Practices.<a href="/src/Affinity/Practices/PracticesClient.cs">GetPracticeAsync</a>(GetPracticeRequest { ... }) -> WithRawResponseTask&lt;GetPracticeResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one practice that belongs to the platform.
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
await client.Practices.GetPracticeAsync(
    new GetPracticeRequest { PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc" }
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

**request:** `GetPracticeRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Practices.<a href="/src/Affinity/Practices/PracticesClient.cs">UpdatePracticeAsync</a>(UpdatePracticeRequest { ... }) -> WithRawResponseTask&lt;UpdatePracticeResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates one practice owned by the platform. Set liveEnabled to true or false to control Live access with an approved platform and a Live request. Affinity Admin decisions take precedence. Requires practices:write. Send Idempotency-Key when you retry the same request.
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
await client.Practices.UpdatePracticeAsync(
    new UpdatePracticeRequest { PracticeId = "prac_01j2y8m6jcc9tt24af5pw9x1bc" }
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

**request:** `UpdatePracticeRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Platform Pricing
<details><summary><code>client.PlatformPricing.<a href="/src/Affinity/PlatformPricing/PlatformPricingClient.cs">PlatformPublicApiSellingPricesReadSellingPriceAsync</a>(PlatformPublicApiSellingPricesReadSellingPriceRequest { ... }) -> WithRawResponseTask&lt;PlatformPublicApiSellingPricesReadSellingPriceResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires selling_prices:read. Omit practiceId for the platform default, or supply a managed practice. A null amount inherits the next applicable price. Amounts use the catalog pricing basis, in USD cents. purchaseAmountCents is the platform's Affinity purchase price for that same basis. requiresReview indicates changed product pricing terms, not a below-purchase-price discount.
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
await client.PlatformPricing.PlatformPublicApiSellingPricesReadSellingPriceAsync(
    new PlatformPublicApiSellingPricesReadSellingPriceRequest
    {
        CatalogItemId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
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

**request:** `PlatformPublicApiSellingPricesReadSellingPriceRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.PlatformPricing.<a href="/src/Affinity/PlatformPricing/PlatformPricingClient.cs">PlatformPublicApiSellingPricesUpdateSellingPriceAsync</a>(PlatformPublicApiSellingPricesUpdateSellingPriceRequest { ... }) -> WithRawResponseTask&lt;PlatformPublicApiSellingPricesUpdateSellingPriceResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Requires selling_prices:write. Sets a platform default or managed practice override in the current Test/Live mode. Send baseVersion from Read selling price. Null removes the override. Prices use the catalog pricing basis. Intentional discounts below purchaseAmountCents are allowed; compare these amounts to warn about selling below your Affinity purchase price. This does not change the platform's Affinity purchase price or collect practice payments.
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
await client.PlatformPricing.PlatformPublicApiSellingPricesUpdateSellingPriceAsync(
    new PlatformPublicApiSellingPricesUpdateSellingPriceRequest
    {
        CatalogItemId = "cat_01j2y8m6jcc9tt24af5pw9x1bc",
        IdempotencyKey = "Idempotency-Key",
        BaseVersion = 1,
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

**request:** `PlatformPublicApiSellingPricesUpdateSellingPriceRequest`

</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>
