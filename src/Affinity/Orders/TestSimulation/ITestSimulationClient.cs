using Affinity;

namespace Affinity.Orders;

public partial interface ITestSimulationClient
{
    /// <summary>
    /// Requires orders:write. Available only in Test mode.
    /// </summary>
    WithRawResponseTask<GetOrderTestSimulationResponse> GetAsync(
        GetTestSimulationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires orders:write and Idempotency-Key. Configure before submission or queue a valid pharmacy event in manual mode. Events use normal order history and Test webhooks. Live requests are rejected.
    /// </summary>
    WithRawResponseTask<UpdateOrderTestSimulationResponse> UpdateAsync(
        UpdateOrderTestSimulationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
