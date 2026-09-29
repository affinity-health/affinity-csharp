using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record AddOrderPrescriptionRequestPrescriptionClinical : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("compoundingReason")]
    public AddOrderPrescriptionRequestPrescriptionClinicalCompoundingReason? CompoundingReason { get; set; }

    [JsonPropertyName("medicationReviewStatus")]
    public AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus? MedicationReviewStatus { get; set; }

    [JsonPropertyName("diagnosisReviewStatus")]
    public AddOrderPrescriptionRequestPrescriptionClinicalDiagnosisReviewStatus? DiagnosisReviewStatus { get; set; }

    [JsonPropertyName("currentMedications")]
    public IEnumerable<string>? CurrentMedications { get; set; }

    [JsonPropertyName("diagnoses")]
    public IEnumerable<AddOrderPrescriptionRequestPrescriptionClinicalDiagnosesItem>? Diagnoses { get; set; }

    [JsonPropertyName("observations")]
    public IEnumerable<AddOrderPrescriptionRequestPrescriptionClinicalObservationsItem>? Observations { get; set; }

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
