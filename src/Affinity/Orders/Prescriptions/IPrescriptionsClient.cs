using Affinity;

namespace Affinity.Orders;

public partial interface IPrescriptionsClient
{
    /// <summary>
    /// Requires orders:write, Idempotency-Key and expectedRevision from the order being edited. Existing integrations may send expectedVersions instead; supply exactly one. Adds a complete prescription to an unsigned Order and returns all new versions. Omitted actor context defaults to the authenticated service account as a system actor. Patient and prescriber attribution stay fixed. Signed orders cannot be amended through this endpoint. Signing and submission require orders:sign through their separate endpoints.
    /// </summary>
    WithRawResponseTask<AddOrderPrescriptionResponse> AddAsync(
        AddOrderPrescriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires orders:write, Idempotency-Key and expectedRevision from the order being edited. Existing integrations may send expectedVersions instead; supply exactly one. Replaces one prescription with complete medication instructions and returns all new versions. Omitted actor context defaults to the authenticated service account as a system actor. Patient and prescriber attribution stay fixed. Signed orders cannot be amended through this endpoint. Signing and submission require orders:sign through their separate endpoints.
    /// </summary>
    WithRawResponseTask<UpdateOrderPrescriptionResponse> UpdateAsync(
        UpdateOrderPrescriptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
