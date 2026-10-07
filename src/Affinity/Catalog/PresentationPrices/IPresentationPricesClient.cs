using Affinity;

namespace Affinity.Catalog;

public partial interface IPresentationPricesClient
{
    /// <summary>
    /// Requires selling_prices:read. Reads the Affinity default and the Affinity-managed purchase-price override for this platform, shared by every pharmacy. Practices inherit it unless Affinity sets a practice override; use the practice-scoped catalog for effective practice prices. Missing defaults are null. Platforms cannot edit purchase prices.
    /// </summary>
    WithRawResponseTask<PlatformPublicApiSellingPricesReadPresentationPriceResponse> GetAsync(
        GetPresentationPricesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
