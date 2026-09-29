namespace Affinity;

public partial interface IWebhooksClient
{
    /// <summary>
    /// Requires webhooks:read. Returns endpoints owned by the key organization, or the organization selected with X-Affinity-Organization-Id. Platform delegation requires a webhook grant in the key's mode.
    /// </summary>
    WithRawResponseTask<ListWebhookEndpointsResponse> ListWebhookEndpointsAsync(
        ListWebhookEndpointsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires webhooks:write and Idempotency-Key. Defaults to the API key organization. A platform can select a practice or pharmacy owner with X-Affinity-Organization-Id and an explicit webhook grant. For platform-owned endpoints, practiceIds narrows delivery to selected connected practices. An empty filter receives all otherwise-authorized events.
    /// </summary>
    WithRawResponseTask<CreateWebhookEndpointResponse> CreateWebhookEndpointAsync(
        CreateWebhookEndpointRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<DeleteWebhookEndpointResponse> DeleteWebhookEndpointAsync(
        DeleteWebhookEndpointRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires webhooks:write and Idempotency-Key. Updates an endpoint in the selected organization and mode. Omitted practiceIds preserves the filter; an empty array removes the practice filter. Subscription changes apply to newly generated events.
    /// </summary>
    WithRawResponseTask<UpdateWebhookEndpointResponse> UpdateWebhookEndpointAsync(
        UpdateWebhookEndpointRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<RotateWebhookEndpointSecretResponse> RotateWebhookEndpointSecretAsync(
        RotateWebhookEndpointSecretRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<TestWebhookEndpointResponse> TestWebhookEndpointAsync(
        TestWebhookEndpointRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<ListWebhookEventsResponse> ListWebhookEventsAsync(
        ListWebhookEventsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetWebhookEventResponse> GetWebhookEventAsync(
        GetWebhookEventRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<ReplayWebhookEventResponse> ReplayWebhookEventAsync(
        ReplayWebhookEventRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires webhooks:read on the owning practice or pharmacy key. Lists platform webhook grants in the key's mode. Platforms cannot list or grant themselves delegated access.
    /// </summary>
    WithRawResponseTask<ListWebhookGrantsResponse> ListWebhookGrantsAsync(
        ListWebhookGrantsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires webhooks:write on the owning practice or pharmacy key and Idempotency-Key. Grants or replaces a platform's webhook permissions in this mode. A practice must already be connected to that platform. The grant does not give the platform access to other API resources.
    /// </summary>
    WithRawResponseTask<SaveWebhookGrantResponse> SaveWebhookGrantAsync(
        SaveWebhookGrantRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires webhooks:write on the owning practice or pharmacy key and Idempotency-Key. Removes platform webhook access in this mode. Existing endpoints remain owned by the practice or pharmacy and continue operating.
    /// </summary>
    WithRawResponseTask<RevokeWebhookGrantResponse> RevokeWebhookGrantAsync(
        RevokeWebhookGrantRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
