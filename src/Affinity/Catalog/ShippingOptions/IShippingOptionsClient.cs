using Affinity;

namespace Affinity.Catalog;

public partial interface IShippingOptionsClient
{
    /// <summary>
    /// Returns an array of at most 50 reviewed shipping services eligible for a catalog item, destination, and API mode. destinationState must be a USPS state or territory code. Each option has one temperature; pharmacy catalog summaries list all supported temperatures.
    /// </summary>
    WithRawResponseTask<IEnumerable<ListShippingOptionsResponseItem>> ListAsync(
        ListShippingOptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
