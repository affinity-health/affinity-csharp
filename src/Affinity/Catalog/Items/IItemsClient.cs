using Affinity;

namespace Affinity.Catalog;

public partial interface IItemsClient
{
    /// <summary>
    /// Lists catalog items for the authenticated account and mode. Use view=medications for priced prescription groups with offer counts, pharmacy counts, and strengths; the default view=offers returns individual offers. Use relatedToCatalogItemId to find offers for the same medication and route. When practiceId is supplied, a practice price overrides the platform price and missing overrides inherit the platform price.
    /// </summary>
    WithRawResponseTask<ListCatalogItemsResponse> ListAsync(
        ListItemsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
