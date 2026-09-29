using Affinity;

namespace Affinity.Webhooks;

public partial interface IEventsClient
{
    WithRawResponseTask<ListWebhookEventsResponse> ListAsync(
        ListEventsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetWebhookEventResponse> GetAsync(
        GetEventsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<ReplayWebhookEventResponse> ReplayAsync(
        ReplayEventsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
