using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity;

[Serializable]
public record RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsQuantityIncrement
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("max")]
    public OneOf<
        double,
        RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsQuantityIncrementMaxOne
    >? Max { get; set; }

    [JsonPropertyName("min")]
    public OneOf<
        double,
        RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsQuantityIncrementMinOne
    >? Min { get; set; }

    [JsonPropertyName("unit")]
    public required string Unit { get; set; }

    [JsonPropertyName("value")]
    public required OneOf<
        double,
        RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsQuantityIncrementValueOne
    > Value { get; set; }

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
