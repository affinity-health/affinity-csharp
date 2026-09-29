namespace Affinity;

public partial interface ICatalogClient
{
    /// <summary>
    /// Lists catalog items for the authenticated account and mode. Use view=medications for priced prescription groups with offer counts, pharmacy counts, and strengths; the default view=offers returns individual offers. Use relatedToCatalogItemId to find offers for the same medication and route. When practiceId is supplied, a practice price overrides the platform price and missing overrides inherit the platform price.
    /// </summary>
    WithRawResponseTask<ListCatalogItemsResponse> ListCatalogItemsAsync(
        ListCatalogItemsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists pharmacies available to the authenticated account, including approved invite-only relationships.
    /// </summary>
    WithRawResponseTask<ListPharmaciesResponse> ListPharmaciesAsync(
        ListPharmaciesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns an array of at most 50 reviewed shipping services eligible for a catalog item, destination, and API mode. destinationState must be a USPS state or territory code. Each option has one temperature; pharmacy catalog summaries list all supported temperatures.
    /// </summary>
    WithRawResponseTask<IEnumerable<ListShippingOptionsResponseItem>> ListShippingOptionsAsync(
        ListShippingOptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires catalog:read. Returns reviewed SIG presets, guided patterns, quantity constraints and product requirements for a practice and mode. Revisions identify changed defaults. No patient-specific rationale or diagnosis is inferred.
    /// </summary>
    WithRawResponseTask<RetrievePrescribingOptionsResponse> RetrievePrescribingOptionsAsync(
        RetrievePrescribingOptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
