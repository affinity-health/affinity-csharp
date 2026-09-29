namespace Affinity.Catalog;

public partial interface ICatalogClient
{
    public IItemsClient Items { get; }
    public IShippingOptionsClient ShippingOptions { get; }
    public IPrescribingOptionsClient PrescribingOptions { get; }
    public ISellingPricesClient SellingPrices { get; }
}
