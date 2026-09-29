using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListCatalogItemsResponseDataItemPricing : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("amountCents")]
    public required int AmountCents { get; set; }

    [JsonPropertyName("basis")]
    public required ListCatalogItemsResponseDataItemPricingBasis Basis { get; set; }

    [JsonPropertyName("currency")]
    public required ListCatalogItemsResponseDataItemPricingCurrency Currency { get; set; }

    [JsonPropertyName("medicationSubtotalCents")]
    public required int MedicationSubtotalCents { get; set; }

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
