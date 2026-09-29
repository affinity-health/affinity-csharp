using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListPatientsResponseDataItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("address")]
    public ListPatientsResponseDataItemAddress? Address { get; set; }

    [JsonPropertyName("defaultShippingAddressId")]
    public string? DefaultShippingAddressId { get; set; }

    [JsonPropertyName("shippingAddress")]
    public ListPatientsResponseDataItemShippingAddress? ShippingAddress { get; set; }

    [JsonPropertyName("allergyReviewStatus")]
    public required ListPatientsResponseDataItemAllergyReviewStatus AllergyReviewStatus { get; set; }

    [JsonPropertyName("allergySummary")]
    public IEnumerable<ListPatientsResponseDataItemAllergySummaryItem> AllergySummary { get; set; } =
        new List<ListPatientsResponseDataItemAllergySummaryItem>();

    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("clinicalProfile")]
    public required ListPatientsResponseDataItemClinicalProfile ClinicalProfile { get; set; }

    [JsonPropertyName("dateOfBirth")]
    public required string DateOfBirth { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("externalIdentities")]
    public IEnumerable<ListPatientsResponseDataItemExternalIdentitiesItem> ExternalIdentities { get; set; } =
        new List<ListPatientsResponseDataItemExternalIdentitiesItem>();

    [JsonPropertyName("addresses")]
    public IEnumerable<ListPatientsResponseDataItemAddressesItem> Addresses { get; set; } =
        new List<ListPatientsResponseDataItemAddressesItem>();

    [JsonPropertyName("encounters")]
    public IEnumerable<ListPatientsResponseDataItemEncountersItem> Encounters { get; set; } =
        new List<ListPatientsResponseDataItemEncountersItem>();

    [JsonPropertyName("gender")]
    public required ListPatientsResponseDataItemGender Gender { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("livemode")]
    public required bool Livemode { get; set; }

    [JsonPropertyName("location")]
    public required ListPatientsResponseDataItemLocation Location { get; set; }

    [JsonPropertyName("locationId")]
    public required string LocationId { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, object?> Metadata { get; set; } = new Dictionary<string, object?>();

    [JsonPropertyName("medicalRecordNumber")]
    public string? MedicalRecordNumber { get; set; }

    [JsonPropertyName("measurements")]
    public IEnumerable<ListPatientsResponseDataItemMeasurementsItem> Measurements { get; set; } =
        new List<ListPatientsResponseDataItemMeasurementsItem>();

    [JsonPropertyName("name")]
    public required ListPatientsResponseDataItemName Name { get; set; }

    [JsonPropertyName("object")]
    public required ListPatientsResponseDataItemObject Object { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("programs")]
    public IEnumerable<ListPatientsResponseDataItemProgramsItem> Programs { get; set; } =
        new List<ListPatientsResponseDataItemProgramsItem>();

    [JsonPropertyName("practiceId")]
    public required string PracticeId { get; set; }

    [JsonPropertyName("status")]
    public required ListPatientsResponseDataItemStatus Status { get; set; }

    [JsonPropertyName("updatedAt")]
    public required string UpdatedAt { get; set; }

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
