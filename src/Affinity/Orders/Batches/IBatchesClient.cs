using Affinity;

namespace Affinity.Orders;

public partial interface IBatchesClient
{
    /// <summary>
    /// Creates 1–20 orders for distinct patients in one practice, each with 1–20 prescriptions. Each accepts patientId or inline patient details. Orders and newly created patients commit atomically; any failure saves none. Requires orders:write and Idempotency-Key; inline patients also require patients:write. Omitted actor context defaults to the authenticated service account as a system actor. Sign and submit each resulting order separately using orders:sign.
    /// </summary>
    WithRawResponseTask<CreateOrderBatchResponse> CreateAsync(
        CreateOrderBatchRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
