using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record RetrievePrescribingOptionsResponsePresetsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("revision")]
    public required string Revision { get; set; }

    [JsonPropertyName("source")]
    public required RetrievePrescribingOptionsResponsePresetsItemSource Source { get; set; }

    [JsonPropertyName("directions")]
    public required string Directions { get; set; }

    [JsonPropertyName("format")]
    public required RetrievePrescribingOptionsResponsePresetsItemFormat Format { get; set; }

    [JsonPropertyName("structuredSig")]
    public RetrievePrescribingOptionsResponsePresetsItemStructuredSig? StructuredSig { get; set; }

    [JsonPropertyName("quantity")]
    public RetrievePrescribingOptionsResponsePresetsItemQuantity? Quantity { get; set; }

    [JsonPropertyName("daysSupply")]
    public int? DaysSupply { get; set; }

    [JsonPropertyName("refills")]
    public required int Refills { get; set; }

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
