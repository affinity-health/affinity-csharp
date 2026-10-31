using Affinity.Core;

namespace Affinity;

public partial interface IWebhooksClient
{
    /// <summary>
    /// List webhook endpoints owned by the API key's organization in its current mode. Signing secrets are not returned.
    /// </summary>
    Task<Pager<WebhookEndpoint>> ListAsync(
        ListWebhooksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Platforms and independent practices can register up to 16 public HTTPS endpoints per mode. An API key acts only for its own organization and mode. Every event goes to every endpoint. The signing secret is returned by creation and its idempotent replay for 24 hours.
    /// </summary>
    WithRawResponseTask<CreateWebhooksResponse> CreateAsync(
        CreateWebhooksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Events not delivered to it yet are dropped.
    /// </summary>
    WithRawResponseTask<RemoveWebhooksResponse> RemoveAsync(
        RemoveWebhooksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The signing secret stays the same.
    /// </summary>
    WithRawResponseTask<WebhookEndpoint> UpdateAsync(
        UpdateWebhooksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Queue failed order event deliveries from the last 30 days for this endpoint. Only the current organization and mode apply. Each failed delivery gets up to 12 new attempts. Also make pending deliveries waiting on a later retry due now, without resetting their attempt counts. Keep the same event IDs, payloads, and per-order delivery sequence. The queued count includes both kinds. Pending deliveries already due, delivered events, and one-time test events stay unchanged. Send a unique Idempotency-Key for each request. Reuse that key after an uncertain response to return the original count. A request with a new key returns 0 when no eligible failures or pending deliveries waiting on a later retry remain.
    /// </summary>
    WithRawResponseTask<ResendFailedWebhooksResponse> ResendFailedAsync(
        ResendFailedWebhooksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
