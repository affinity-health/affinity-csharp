using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record RetrievePrescribingOptionsResponseFormulationDefaultStructuredSig
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("dose")]
    public required string Dose { get; set; }

    [JsonPropertyName("doseUnit")]
    public required string DoseUnit { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [JsonPropertyName("frequency")]
    public required string Frequency { get; set; }

    [JsonPropertyName("maxDailyUse")]
    public string? MaxDailyUse { get; set; }

    [JsonPropertyName("prn")]
    public required bool Prn { get; set; }

    [JsonPropertyName("route")]
    public required string Route { get; set; }

    [JsonPropertyName("titrationSchedule")]
    public string? TitrationSchedule { get; set; }

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
