using Affinity;

namespace Affinity.Orders;

public partial interface IExceptionsClient
{
    /// <summary>
    /// Acknowledge, retry, contact, or resolve an order exception in the credential's Test/Live mode. assign_to_me requires a signed-in dashboard user; API keys receive 400 and may use acknowledge instead. Actor headers do not create a dashboard assignee.
    /// </summary>
    WithRawResponseTask<ActOnOrderExceptionResponse> ActAsync(
        ActOnOrderExceptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
