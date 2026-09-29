using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity.Catalog;

[Serializable]
public record ListShippingOptionsRequest
{
    [JsonIgnore]
    public required string CatalogItemId { get; set; }

    [JsonIgnore]
    public required string DestinationState { get; set; }

    [JsonIgnore]
    public ListShippingOptionsRequestDestinationType? DestinationType { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
