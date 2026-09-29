using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record RetrievePrescribingOptionsResponseOptions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("doseUnits")]
    public IEnumerable<RetrievePrescribingOptionsResponseOptionsDoseUnitsItem> DoseUnits { get; set; } =
        new List<RetrievePrescribingOptionsResponseOptionsDoseUnitsItem>();

    [JsonPropertyName("doses")]
    public IEnumerable<RetrievePrescribingOptionsResponseOptionsDosesItem> Doses { get; set; } =
        new List<RetrievePrescribingOptionsResponseOptionsDosesItem>();

    [JsonPropertyName("frequencies")]
    public IEnumerable<RetrievePrescribingOptionsResponseOptionsFrequenciesItem> Frequencies { get; set; } =
        new List<RetrievePrescribingOptionsResponseOptionsFrequenciesItem>();

    [JsonPropertyName("routes")]
    public IEnumerable<RetrievePrescribingOptionsResponseOptionsRoutesItem> Routes { get; set; } =
        new List<RetrievePrescribingOptionsResponseOptionsRoutesItem>();

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
