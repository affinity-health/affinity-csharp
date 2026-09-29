using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record GetOrderResponsePrescriptionsItemClinical : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("allergies")]
    public IEnumerable<GetOrderResponsePrescriptionsItemClinicalAllergiesItem>? Allergies { get; set; }

    [JsonPropertyName("medicationReviewStatus")]
    public GetOrderResponsePrescriptionsItemClinicalMedicationReviewStatus? MedicationReviewStatus { get; set; }

    [JsonPropertyName("diagnosisReviewStatus")]
    public GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus? DiagnosisReviewStatus { get; set; }

    [JsonPropertyName("conditions")]
    public IEnumerable<GetOrderResponsePrescriptionsItemClinicalConditionsItem>? Conditions { get; set; }

    [JsonPropertyName("compoundingReason")]
    public GetOrderResponsePrescriptionsItemClinicalCompoundingReason? CompoundingReason { get; set; }

    [JsonPropertyName("medications")]
    public IEnumerable<GetOrderResponsePrescriptionsItemClinicalMedicationsItem>? Medications { get; set; }

    [JsonPropertyName("observations")]
    public IEnumerable<GetOrderResponsePrescriptionsItemClinicalObservationsItem>? Observations { get; set; }

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
