using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record RetrievePrescribingOptionsResponseCatalogPrescriptionRequirements
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("allowedDaysSupply")]
    public IEnumerable<int>? AllowedDaysSupply { get; set; }

    [JsonPropertyName("allowedQuantities")]
    public IEnumerable<RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItem>? AllowedQuantities { get; set; }

    [JsonPropertyName("allowedReasonCategories")]
    public IEnumerable<RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedReasonCategoriesItem>? AllowedReasonCategories { get; set; }

    [JsonPropertyName("reasonCategoryLabels")]
    public Dictionary<string, string?>? ReasonCategoryLabels { get; set; }

    [JsonPropertyName("compoundingReason")]
    public required RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReason CompoundingReason { get; set; }

    [JsonPropertyName("compoundingReasonContext")]
    public RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext? CompoundingReasonContext { get; set; }

    [JsonPropertyName("controlledSchedule")]
    public RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsControlledSchedule? ControlledSchedule { get; set; }

    [JsonPropertyName("defaultDaysSupply")]
    public int? DefaultDaysSupply { get; set; }

    [JsonPropertyName("defaultQuantity")]
    public RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsDefaultQuantity? DefaultQuantity { get; set; }

    [JsonPropertyName("quantityIncrement")]
    public RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsQuantityIncrement? QuantityIncrement { get; set; }

    [JsonPropertyName("defaultSigs")]
    public IEnumerable<string>? DefaultSigs { get; set; }

    [JsonPropertyName("diagnosis")]
    public required RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsDiagnosis Diagnosis { get; set; }

    [JsonPropertyName("medicationReview")]
    public RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview? MedicationReview { get; set; }

    [JsonPropertyName("diagnosisReview")]
    public RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsDiagnosisReview? DiagnosisReview { get; set; }

    [JsonPropertyName("maxRefills")]
    public int? MaxRefills { get; set; }

    [JsonPropertyName("notes")]
    public IEnumerable<string>? Notes { get; set; }

    [JsonPropertyName("pharmacyNotes")]
    public required RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsPharmacyNotes PharmacyNotes { get; set; }

    [JsonPropertyName("refills")]
    public required RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills Refills { get; set; }

    [JsonPropertyName("substitution")]
    public required RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsSubstitution Substitution { get; set; }

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
