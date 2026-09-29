using Affinity;

namespace Affinity.Webhooks;

public partial interface IEndpointsClient
{
    /// <summary>
    /// Requires webhooks:read. Returns endpoints owned by the key organization, or the organization selected with X-Affinity-Organization-Id. Platform delegation requires a webhook grant in the key's mode.
    /// </summary>
    WithRawResponseTask<ListWebhookEndpointsResponse> ListAsync(
        ListEndpointsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires webhooks:write and Idempotency-Key. Defaults to the API key organization. A platform can select a practice or pharmacy owner with X-Affinity-Organization-Id and an explicit webhook grant. For platform-owned endpoints, practiceIds narrows delivery to selected connected practices. An empty filter receives all otherwise-authorized events.
    /// </summary>
    WithRawResponseTask<CreateWebhookEndpointResponse> CreateAsync(
        CreateWebhookEndpointRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<DeleteWebhookEndpointResponse> DeleteAsync(
        DeleteEndpointsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires webhooks:write and Idempotency-Key. Updates an endpoint in the selected organization and mode. Omitted practiceIds preserves the filter; an empty array removes the practice filter. Subscription changes apply to newly generated events.
    /// </summary>
    WithRawResponseTask<UpdateWebhookEndpointResponse> UpdateAsync(
        UpdateWebhookEndpointRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<RotateWebhookEndpointSecretResponse> RotateSecretAsync(
        RotateSecretEndpointsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<TestWebhookEndpointResponse> TestAsync(
        TestEndpointsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
