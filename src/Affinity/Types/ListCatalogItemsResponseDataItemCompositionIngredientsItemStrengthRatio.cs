using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthRatio
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("numerator")]
    public required ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthRatioNumerator Numerator { get; set; }

    [JsonPropertyName("denominator")]
    public required ListCatalogItemsResponseDataItemCompositionIngredientsItemStrengthRatioDenominator Denominator { get; set; }

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
