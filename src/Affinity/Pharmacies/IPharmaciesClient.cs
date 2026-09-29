namespace Affinity;

public partial interface IPharmaciesClient
{
    /// <summary>
    /// Lists pharmacies available to the authenticated account, including approved invite-only relationships.
    /// </summary>
    WithRawResponseTask<ListPharmaciesResponse> ListAsync(
        ListPharmaciesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
