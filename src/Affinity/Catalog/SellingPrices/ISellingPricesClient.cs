using Affinity;

namespace Affinity.Catalog;

public partial interface ISellingPricesClient
{
    /// <summary>
    /// Requires selling_prices:read. Omit practiceId for the platform default, or supply a managed practice. A null amount inherits the next applicable price. Amounts use the catalog pricing basis, in USD cents. purchaseAmountCents is the platform's Affinity purchase price for that same basis. requiresReview indicates changed product pricing terms, not a below-purchase-price discount.
    /// </summary>
    WithRawResponseTask<PlatformPublicApiSellingPricesReadSellingPriceResponse> GetAsync(
        GetSellingPricesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires selling_prices:write. Sets a platform default or managed practice override in the current Test/Live mode. Send baseVersion from Read selling price. Null removes the override. Prices use the catalog pricing basis. Intentional discounts below purchaseAmountCents are allowed; compare these amounts to warn about selling below your Affinity purchase price. This does not change the platform's Affinity purchase price or collect practice payments.
    /// </summary>
    WithRawResponseTask<PlatformPublicApiSellingPricesUpdateSellingPriceResponse> UpdateAsync(
        PlatformPublicApiSellingPricesUpdateSellingPriceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
