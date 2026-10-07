using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record PlatformPublicApiSellingPricesReadPresentationPriceResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("amountCents")]
    public int? AmountCents { get; set; }

    [JsonPropertyName("version")]
    public required int Version { get; set; }

    [JsonPropertyName("currency")]
    public required PlatformPublicApiSellingPricesReadPresentationPriceResponseCurrency Currency { get; set; }

    [JsonPropertyName("affinityPriceCents")]
    public int? AffinityPriceCents { get; set; }

    [JsonPropertyName("affinityBasis")]
    public PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasis? AffinityBasis { get; set; }

    [JsonPropertyName("basis")]
    public PlatformPublicApiSellingPricesReadPresentationPriceResponseBasis? Basis { get; set; }

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
