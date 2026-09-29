namespace Affinity;

public partial interface IOrdersClient
{
    WithRawResponseTask<ListOrdersResponse> ListOrdersAsync(
        ListOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates one unsigned order with 1–20 prescriptions for one patient in one practice. Supply patientId or patient; inline patient creation requires patients:write. Prescriber is optional: select by npi, provider id, or integration-scoped externalId, or leave the draft unassigned until signing. First-use prescriber registration requires team:write. Legacy userId is supported but cannot be combined with prescriber. Idempotency-Key is required.
    /// </summary>
    WithRawResponseTask<CreateOrderResponse> CreateOrderAsync(
        CreateOrderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetOrderResponse> GetOrderAsync(
        GetOrderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requests cancellation. HTTP 200 means the request was handled; check cancellation.status for confirmed, pending, partial, or failed. Only confirmed means the entire order is cancelled. Shipment possession makes a fulfillment cancellation too late.
    /// </summary>
    WithRawResponseTask<CancelOrderResponse> CancelOrderAsync(
        CancelOrderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Acknowledge, retry, contact, or resolve an order exception in the credential's Test/Live mode. assign_to_me requires a signed-in dashboard user; API keys receive 400 and may use acknowledge instead. Actor headers do not create a dashboard assignee.
    /// </summary>
    WithRawResponseTask<ActOnOrderExceptionResponse> ActOnOrderExceptionAsync(
        ActOnOrderExceptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<ListOrderEventsResponse> ListOrderEventsAsync(
        ListOrderEventsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires orders:write. Available only in Test mode.
    /// </summary>
    WithRawResponseTask<GetOrderTestSimulationResponse> GetOrderTestSimulationAsync(
        GetOrderTestSimulationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires orders:write and Idempotency-Key. Configure before submission or queue a valid pharmacy event in manual mode. Events use normal order history and Test webhooks. Live requests are rejected.
    /// </summary>
    WithRawResponseTask<UpdateOrderTestSimulationResponse> UpdateOrderTestSimulationAsync(
        UpdateOrderTestSimulationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires orders:write and catalog:read. Supply exactly one of patientId, patientExternalId, or inline patient details. External-ID lookup additionally requires patients:read; inline details require patients:write. Resolves defaults and explicit edits for 1–20 prescriptions. Reuses stored patient details when identifiers match; otherwise previews inline details without creating a patient. Complete previews contain an orders.create input. Does not create records, reserve prices, sign, charge or transmit. No idempotency key is required. Creation and signing recheck current requirements.
    /// </summary>
    WithRawResponseTask<PreviewOrderResponse> PreviewOrderAsync(
        PreviewOrderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires orders:sign, Idempotency-Key, signatureAttestation, and expectedRevision from the reviewed order. Existing integrations may send expectedVersions instead; supply exactly one. A stale revision returns 409 and requires renewed clinician review. Select prescriber by npi, provider id, or integration-scoped externalId, or inherit the draft's prescriber. First-use registration requires team:write. Actor headers are optional audit metadata with prescriber; legacy userId requires matching clinician actor headers. Signing does not submit to a pharmacy.
    /// </summary>
    WithRawResponseTask<SignOrderResponse> SignOrderAsync(
        SignOrderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires orders:sign, Idempotency-Key, signatureAttestation, and expectedRevision from the reviewed order. Existing integrations may send expectedVersions instead; supply exactly one. A stale revision returns 409 and requires renewed clinician review. Select prescriber by npi, provider id, or externalId, or inherit the draft's prescriber. First-use registration requires team:write. Actor headers are optional with prescriber; legacy userId requires matching clinician actor headers. Signs the complete order, then attempts each submission. Signing remains committed if submission fails. Replay the same key after an uncertain response; retry reported submission failures through Submit order with a new key. Submitted means queued, not pharmacy acceptance.
    /// </summary>
    WithRawResponseTask<SignAndSubmitOrderResponse> SignAndSubmitOrderAsync(
        SignAndSubmitOrderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires orders:sign and Idempotency-Key. Queues signed prescriptions after rechecking authorization, signature integrity, billing, and fulfillment eligibility. Track pharmacy acceptance through order reads and webhooks. After a partial failure, retry submission with a new idempotency key; already queued prescriptions are not duplicated.
    /// </summary>
    WithRawResponseTask<SubmitOrderResponse> SubmitOrderAsync(
        SubmitOrderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires orders:sign and Idempotency-Key. Select a prescriber or inherit the draft's prescriber. Legacy userId requires matching clinician actor headers. Supply expectedRevision from the reviewed order, or expectedVersions for existing integrations. Permanently rejects the complete unsigned order after checking its revision.
    /// </summary>
    WithRawResponseTask<RejectOrderResponse> RejectOrderAsync(
        RejectOrderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires orders:write, Idempotency-Key and expectedRevision from the order being edited. Existing integrations may send expectedVersions instead; supply exactly one. Adds a complete prescription to an unsigned Order and returns all new versions. Omitted actor context defaults to the authenticated service account as a system actor. Patient and prescriber attribution stay fixed. Signed orders cannot be amended through this endpoint. Signing and submission require orders:sign through their separate endpoints.
    /// </summary>
    WithRawResponseTask<AddOrderPrescriptionResponse> AddOrderPrescriptionAsync(
        AddOrderPrescriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires orders:write, Idempotency-Key and expectedRevision from the order being edited. Existing integrations may send expectedVersions instead; supply exactly one. Replaces one prescription with complete medication instructions and returns all new versions. Omitted actor context defaults to the authenticated service account as a system actor. Patient and prescriber attribution stay fixed. Signed orders cannot be amended through this endpoint. Signing and submission require orders:sign through their separate endpoints.
    /// </summary>
    WithRawResponseTask<UpdateOrderPrescriptionResponse> UpdateOrderPrescriptionAsync(
        UpdateOrderPrescriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates 1–20 orders for distinct patients in one practice, each with 1–20 prescriptions. Each accepts patientId or inline patient details. Orders and newly created patients commit atomically; any failure saves none. Requires orders:write and Idempotency-Key; inline patients also require patients:write. Omitted actor context defaults to the authenticated service account as a system actor. Sign and submit each resulting order separately using orders:sign.
    /// </summary>
    WithRawResponseTask<CreateOrderBatchResponse> CreateOrderBatchAsync(
        CreateOrderBatchRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
