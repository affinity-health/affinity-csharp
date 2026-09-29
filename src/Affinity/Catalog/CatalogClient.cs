using Affinity.Core;

namespace Affinity.Catalog;

public partial class CatalogClient : ICatalogClient
{
    private readonly RawClient _client;

    internal CatalogClient(RawClient client)
    {
        _client = client;
        Items = new ItemsClient(_client);
        ShippingOptions = new ShippingOptionsClient(_client);
        PrescribingOptions = new PrescribingOptionsClient(_client);
        SellingPrices = new SellingPricesClient(_client);
    }

    public IItemsClient Items { get; }

    public IShippingOptionsClient ShippingOptions { get; }

    public IPrescribingOptionsClient PrescribingOptions { get; }

    public ISellingPricesClient SellingPrices { get; }
}
