using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record PlatformPublicApiSellingPricesReadSellingPriceResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("amountCents")]
    public int? AmountCents { get; set; }

    [JsonPropertyName("version")]
    public required int Version { get; set; }

    [JsonPropertyName("currency")]
    public required PlatformPublicApiSellingPricesReadSellingPriceResponseCurrency Currency { get; set; }

    [JsonPropertyName("basis")]
    public required PlatformPublicApiSellingPricesReadSellingPriceResponseBasis Basis { get; set; }

    [JsonPropertyName("purchaseAmountCents")]
    public required int PurchaseAmountCents { get; set; }

    [JsonPropertyName("requiresReview")]
    public required bool RequiresReview { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
