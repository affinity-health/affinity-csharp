using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record PreviewOrderRequestPrescriptionsItemOverridesClinical : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("compoundingReason")]
    public PreviewOrderRequestPrescriptionsItemOverridesClinicalCompoundingReason? CompoundingReason { get; set; }

    [JsonPropertyName("medicationReviewStatus")]
    public PreviewOrderRequestPrescriptionsItemOverridesClinicalMedicationReviewStatus? MedicationReviewStatus { get; set; }

    [JsonPropertyName("diagnosisReviewStatus")]
    public PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus? DiagnosisReviewStatus { get; set; }

    [JsonPropertyName("currentMedications")]
    public IEnumerable<string>? CurrentMedications { get; set; }

    [JsonPropertyName("diagnoses")]
    public IEnumerable<PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosesItem>? Diagnoses { get; set; }

    [JsonPropertyName("observations")]
    public IEnumerable<PreviewOrderRequestPrescriptionsItemOverridesClinicalObservationsItem>? Observations { get; set; }

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
