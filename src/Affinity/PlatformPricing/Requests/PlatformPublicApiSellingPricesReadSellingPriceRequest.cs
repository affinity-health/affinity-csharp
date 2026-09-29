using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record PlatformPublicApiSellingPricesReadSellingPriceRequest
{
    [JsonIgnore]
    public required string CatalogItemId { get; set; }

    [JsonIgnore]
    public string? PracticeId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
