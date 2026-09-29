using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity;

[Serializable]
public record RetrievePrescribingOptionsResponseCatalogCatalogDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("attributes")]
    public Dictionary<string, OneOf<string, IEnumerable<string>>> Attributes { get; set; } =
        new Dictionary<string, OneOf<string, IEnumerable<string>>>();

    [JsonPropertyName("directions")]
    public IEnumerable<RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItem> Directions { get; set; } =
        new List<RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItem>();

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
