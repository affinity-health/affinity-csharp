using Affinity;

namespace Affinity.Orders;

public partial interface IEventsClient
{
    WithRawResponseTask<ListOrderEventsResponse> ListAsync(
        ListEventsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
