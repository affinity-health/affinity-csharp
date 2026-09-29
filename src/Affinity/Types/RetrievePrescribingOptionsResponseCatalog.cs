using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record RetrievePrescribingOptionsResponseCatalog : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("catalogDetails")]
    public required RetrievePrescribingOptionsResponseCatalogCatalogDetails CatalogDetails { get; set; }

    [JsonPropertyName("composition")]
    public required RetrievePrescribingOptionsResponseCatalogComposition Composition { get; set; }

    [JsonPropertyName("allowedStates")]
    public IEnumerable<string> AllowedStates { get; set; } = new List<string>();

    [JsonPropertyName("availability")]
    public required RetrievePrescribingOptionsResponseCatalogAvailability Availability { get; set; }

    [JsonPropertyName("catalogKind")]
    public required string CatalogKind { get; set; }

    [JsonPropertyName("fulfillmentInclusions")]
    public IEnumerable<RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItem> FulfillmentInclusions { get; set; } =
        new List<RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItem>();

    [JsonPropertyName("ordering")]
    public required RetrievePrescribingOptionsResponseCatalogOrdering Ordering { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("coldShip")]
    public required bool ColdShip { get; set; }

    [JsonPropertyName("pharmacyId")]
    public required string PharmacyId { get; set; }

    [JsonPropertyName("pharmacyName")]
    public required string PharmacyName { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("dosageForm")]
    public required string DosageForm { get; set; }

    [JsonPropertyName("facilityType")]
    public required string FacilityType { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Primary product photo, falling back to dosage-form artwork. Null when neither is available.
    /// </summary>
    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("imageUrls")]
    public IEnumerable<string> ImageUrls { get; set; } = new List<string>();

    [JsonPropertyName("medicationGroup")]
    public RetrievePrescribingOptionsResponseCatalogMedicationGroup? MedicationGroup { get; set; }

    [JsonPropertyName("isOrderable")]
    public required bool IsOrderable { get; set; }

    [JsonPropertyName("livemode")]
    public required bool Livemode { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("object")]
    public required RetrievePrescribingOptionsResponseCatalogObject Object { get; set; }

    [JsonPropertyName("patientSpecificRequired")]
    public required bool PatientSpecificRequired { get; set; }

    [JsonPropertyName("quantityConstraint")]
    public RetrievePrescribingOptionsResponseCatalogQuantityConstraint? QuantityConstraint { get; set; }

    [JsonPropertyName("prescriptionRequirements")]
    public required RetrievePrescribingOptionsResponseCatalogPrescriptionRequirements PrescriptionRequirements { get; set; }

    [JsonPropertyName("pricing")]
    public RetrievePrescribingOptionsResponseCatalogPricing? Pricing { get; set; }

    [JsonPropertyName("restrictedStates")]
    public IEnumerable<string> RestrictedStates { get; set; } = new List<string>();

    [JsonPropertyName("route")]
    public required string Route { get; set; }

    [JsonPropertyName("shippingOptions")]
    public IEnumerable<RetrievePrescribingOptionsResponseCatalogShippingOptionsItem> ShippingOptions { get; set; } =
        new List<RetrievePrescribingOptionsResponseCatalogShippingOptionsItem>();

    [JsonPropertyName("strength")]
    public string? Strength { get; set; }

    [JsonPropertyName("unit")]
    public string? Unit { get; set; }

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
