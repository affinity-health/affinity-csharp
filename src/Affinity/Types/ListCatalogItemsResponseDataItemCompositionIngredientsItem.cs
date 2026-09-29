using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListCatalogItemsResponseDataItemCompositionIngredientsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("role")]
    public required ListCatalogItemsResponseDataItemCompositionIngredientsItemRole Role { get; set; }

    [JsonPropertyName("basisOfStrengthSubstance")]
    public ListCatalogItemsResponseDataItemCompositionIngredientsItemBasisOfStrengthSubstance? BasisOfStrengthSubstance { get; set; }

    [JsonPropertyName("strength")]
    public required ListCatalogItemsResponseDataItemCompositionIngredientsItemStrength Strength { get; set; }

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
