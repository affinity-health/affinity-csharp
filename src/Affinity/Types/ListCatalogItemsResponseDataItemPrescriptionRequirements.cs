using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListCatalogItemsResponseDataItemPrescriptionRequirements : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("allowedDaysSupply")]
    public IEnumerable<int>? AllowedDaysSupply { get; set; }

    [JsonPropertyName("allowedQuantities")]
    public IEnumerable<ListCatalogItemsResponseDataItemPrescriptionRequirementsAllowedQuantitiesItem>? AllowedQuantities { get; set; }

    [JsonPropertyName("allowedReasonCategories")]
    public IEnumerable<ListCatalogItemsResponseDataItemPrescriptionRequirementsAllowedReasonCategoriesItem>? AllowedReasonCategories { get; set; }

    [JsonPropertyName("reasonCategoryLabels")]
    public Dictionary<string, string?>? ReasonCategoryLabels { get; set; }

    [JsonPropertyName("compoundingReason")]
    public required ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason CompoundingReason { get; set; }

    [JsonPropertyName("compoundingReasonContext")]
    public ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext? CompoundingReasonContext { get; set; }

    [JsonPropertyName("controlledSchedule")]
    public ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule? ControlledSchedule { get; set; }

    [JsonPropertyName("defaultDaysSupply")]
    public int? DefaultDaysSupply { get; set; }

    [JsonPropertyName("defaultQuantity")]
    public ListCatalogItemsResponseDataItemPrescriptionRequirementsDefaultQuantity? DefaultQuantity { get; set; }

    [JsonPropertyName("quantityIncrement")]
    public ListCatalogItemsResponseDataItemPrescriptionRequirementsQuantityIncrement? QuantityIncrement { get; set; }

    [JsonPropertyName("defaultSigs")]
    public IEnumerable<string>? DefaultSigs { get; set; }

    [JsonPropertyName("diagnosis")]
    public required ListCatalogItemsResponseDataItemPrescriptionRequirementsDiagnosis Diagnosis { get; set; }

    [JsonPropertyName("medicationReview")]
    public ListCatalogItemsResponseDataItemPrescriptionRequirementsMedicationReview? MedicationReview { get; set; }

    [JsonPropertyName("diagnosisReview")]
    public ListCatalogItemsResponseDataItemPrescriptionRequirementsDiagnosisReview? DiagnosisReview { get; set; }

    [JsonPropertyName("maxRefills")]
    public int? MaxRefills { get; set; }

    [JsonPropertyName("notes")]
    public IEnumerable<string>? Notes { get; set; }

    [JsonPropertyName("pharmacyNotes")]
    public required ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes PharmacyNotes { get; set; }

    [JsonPropertyName("refills")]
    public required ListCatalogItemsResponseDataItemPrescriptionRequirementsRefills Refills { get; set; }

    [JsonPropertyName("substitution")]
    public required ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution Substitution { get; set; }

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
