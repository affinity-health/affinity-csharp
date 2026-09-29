using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListOrdersResponseDataItemPrescriptionsItemClinical : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("allergies")]
    public IEnumerable<ListOrdersResponseDataItemPrescriptionsItemClinicalAllergiesItem>? Allergies { get; set; }

    [JsonPropertyName("medicationReviewStatus")]
    public ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus? MedicationReviewStatus { get; set; }

    [JsonPropertyName("diagnosisReviewStatus")]
    public ListOrdersResponseDataItemPrescriptionsItemClinicalDiagnosisReviewStatus? DiagnosisReviewStatus { get; set; }

    [JsonPropertyName("conditions")]
    public IEnumerable<ListOrdersResponseDataItemPrescriptionsItemClinicalConditionsItem>? Conditions { get; set; }

    [JsonPropertyName("compoundingReason")]
    public ListOrdersResponseDataItemPrescriptionsItemClinicalCompoundingReason? CompoundingReason { get; set; }

    [JsonPropertyName("medications")]
    public IEnumerable<ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationsItem>? Medications { get; set; }

    [JsonPropertyName("observations")]
    public IEnumerable<ListOrdersResponseDataItemPrescriptionsItemClinicalObservationsItem>? Observations { get; set; }

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
