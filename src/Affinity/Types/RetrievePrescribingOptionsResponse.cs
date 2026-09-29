using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record RetrievePrescribingOptionsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("compoundingReason")]
    public required RetrievePrescribingOptionsResponseCompoundingReason CompoundingReason { get; set; }

    [JsonPropertyName("compoundingReasonCategoryDefault")]
    public RetrievePrescribingOptionsResponseCompoundingReasonCategoryDefault? CompoundingReasonCategoryDefault { get; set; }

    [JsonPropertyName("compoundingReasonDefault")]
    public string? CompoundingReasonDefault { get; set; }

    [JsonPropertyName("default")]
    public RetrievePrescribingOptionsResponseDefault? Default { get; set; }

    [JsonPropertyName("formulationDefault")]
    public RetrievePrescribingOptionsResponseFormulationDefault? FormulationDefault { get; set; }

    [JsonPropertyName("initial")]
    public required RetrievePrescribingOptionsResponseInitial Initial { get; set; }

    [JsonPropertyName("medication")]
    public required RetrievePrescribingOptionsResponseMedication Medication { get; set; }

    [JsonPropertyName("options")]
    public required RetrievePrescribingOptionsResponseOptions Options { get; set; }

    [JsonPropertyName("pharmacyDirections")]
    public IEnumerable<RetrievePrescribingOptionsResponsePharmacyDirectionsItem> PharmacyDirections { get; set; } =
        new List<RetrievePrescribingOptionsResponsePharmacyDirectionsItem>();

    [JsonPropertyName("templates")]
    public IEnumerable<RetrievePrescribingOptionsResponseTemplatesItem> Templates { get; set; } =
        new List<RetrievePrescribingOptionsResponseTemplatesItem>();

    [JsonPropertyName("object")]
    public required RetrievePrescribingOptionsResponseObject Object { get; set; }

    [JsonPropertyName("catalogItemId")]
    public required string CatalogItemId { get; set; }

    [JsonPropertyName("practiceId")]
    public required string PracticeId { get; set; }

    [JsonPropertyName("livemode")]
    public required bool Livemode { get; set; }

    [JsonPropertyName("revision")]
    public required string Revision { get; set; }

    [JsonPropertyName("catalog")]
    public required RetrievePrescribingOptionsResponseCatalog Catalog { get; set; }

    [JsonPropertyName("defaultPresetId")]
    public string? DefaultPresetId { get; set; }

    [JsonPropertyName("presets")]
    public IEnumerable<RetrievePrescribingOptionsResponsePresetsItem> Presets { get; set; } =
        new List<RetrievePrescribingOptionsResponsePresetsItem>();

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
