using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record PreviewOrderResponseOrderInputPrescriptionsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("externalPrescriptionId")]
    public string? ExternalPrescriptionId { get; set; }

    [JsonPropertyName("clinical")]
    public PreviewOrderResponseOrderInputPrescriptionsItemClinical? Clinical { get; set; }

    [JsonPropertyName("pharmacyId")]
    public string? PharmacyId { get; set; }

    [JsonPropertyName("daysSupply")]
    public required int DaysSupply { get; set; }

    [JsonPropertyName("dispensing")]
    public required PreviewOrderResponseOrderInputPrescriptionsItemDispensing Dispensing { get; set; }

    [JsonPropertyName("directions")]
    public required string Directions { get; set; }

    [JsonPropertyName("medicationId")]
    public required string MedicationId { get; set; }

    [JsonPropertyName("quantity")]
    public required double Quantity { get; set; }

    [JsonPropertyName("quantityUnit")]
    public required string QuantityUnit { get; set; }

    [JsonPropertyName("refills")]
    public required int Refills { get; set; }

    [JsonPropertyName("structuredSig")]
    public PreviewOrderResponseOrderInputPrescriptionsItemStructuredSig? StructuredSig { get; set; }

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
