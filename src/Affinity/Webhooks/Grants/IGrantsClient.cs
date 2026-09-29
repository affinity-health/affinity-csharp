using Affinity;

namespace Affinity.Webhooks;

public partial interface IGrantsClient
{
    /// <summary>
    /// Requires webhooks:read on the owning practice or pharmacy key. Lists platform webhook grants in the key's mode. Platforms cannot list or grant themselves delegated access.
    /// </summary>
    WithRawResponseTask<ListWebhookGrantsResponse> ListAsync(
        ListGrantsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires webhooks:write on the owning practice or pharmacy key and Idempotency-Key. Grants or replaces a platform's webhook permissions in this mode. A practice must already be connected to that platform. The grant does not give the platform access to other API resources.
    /// </summary>
    WithRawResponseTask<SaveWebhookGrantResponse> SaveAsync(
        SaveWebhookGrantRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires webhooks:write on the owning practice or pharmacy key and Idempotency-Key. Removes platform webhook access in this mode. Existing endpoints remain owned by the practice or pharmacy and continue operating.
    /// </summary>
    WithRawResponseTask<RevokeWebhookGrantResponse> RevokeAsync(
        RevokeGrantsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
