using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CancelOrderResponsePrescriptionsItemClinical : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("allergies")]
    public IEnumerable<CancelOrderResponsePrescriptionsItemClinicalAllergiesItem>? Allergies { get; set; }

    [JsonPropertyName("medicationReviewStatus")]
    public CancelOrderResponsePrescriptionsItemClinicalMedicationReviewStatus? MedicationReviewStatus { get; set; }

    [JsonPropertyName("diagnosisReviewStatus")]
    public CancelOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus? DiagnosisReviewStatus { get; set; }

    [JsonPropertyName("conditions")]
    public IEnumerable<CancelOrderResponsePrescriptionsItemClinicalConditionsItem>? Conditions { get; set; }

    [JsonPropertyName("compoundingReason")]
    public CancelOrderResponsePrescriptionsItemClinicalCompoundingReason? CompoundingReason { get; set; }

    [JsonPropertyName("medications")]
    public IEnumerable<CancelOrderResponsePrescriptionsItemClinicalMedicationsItem>? Medications { get; set; }

    [JsonPropertyName("observations")]
    public IEnumerable<CancelOrderResponsePrescriptionsItemClinicalObservationsItem>? Observations { get; set; }

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
