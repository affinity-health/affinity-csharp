using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity.Catalog;

[Serializable]
public record PlatformPublicApiSellingPricesUpdateSellingPriceRequest
{
    [JsonIgnore]
    public required string CatalogItemId { get; set; }

    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

    [JsonPropertyName("practiceId")]
    public string? PracticeId { get; set; }

    [JsonPropertyName("amountCents")]
    public int? AmountCents { get; set; }

    [JsonPropertyName("baseVersion")]
    public required int BaseVersion { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
