using Affinity;

namespace Affinity.Catalog;

public partial interface ISellingPricesClient
{
    /// <summary>
    /// Requires selling_prices:read. Reads the Affinity-managed purchase-price override inherited by this platform's practices unless Affinity sets a practice override. Use the practice-scoped catalog for effective practice prices and presentation-price when an Affinity default may be absent. Platforms cannot edit purchase prices.
    /// </summary>
    WithRawResponseTask<PlatformPublicApiSellingPricesReadSellingPriceResponse> GetAsync(
        GetSellingPricesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
