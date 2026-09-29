using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record RetrievePrescribingOptionsResponseDefault : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("directions")]
    public required string Directions { get; set; }

    [JsonPropertyName("format")]
    public required RetrievePrescribingOptionsResponseDefaultFormat Format { get; set; }

    [JsonPropertyName("source")]
    public required RetrievePrescribingOptionsResponseDefaultSource Source { get; set; }

    [JsonPropertyName("structuredSig")]
    public RetrievePrescribingOptionsResponseDefaultStructuredSig? StructuredSig { get; set; }

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
