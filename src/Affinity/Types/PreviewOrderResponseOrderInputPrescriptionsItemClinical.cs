using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record PreviewOrderResponseOrderInputPrescriptionsItemClinical : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("compoundingReason")]
    public PreviewOrderResponseOrderInputPrescriptionsItemClinicalCompoundingReason? CompoundingReason { get; set; }

    [JsonPropertyName("medicationReviewStatus")]
    public PreviewOrderResponseOrderInputPrescriptionsItemClinicalMedicationReviewStatus? MedicationReviewStatus { get; set; }

    [JsonPropertyName("diagnosisReviewStatus")]
    public PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus? DiagnosisReviewStatus { get; set; }

    [JsonPropertyName("currentMedications")]
    public IEnumerable<string>? CurrentMedications { get; set; }

    [JsonPropertyName("diagnoses")]
    public IEnumerable<PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosesItem>? Diagnoses { get; set; }

    [JsonPropertyName("observations")]
    public IEnumerable<PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItem>? Observations { get; set; }

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
