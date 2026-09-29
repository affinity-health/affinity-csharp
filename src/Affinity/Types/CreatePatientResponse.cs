using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CreatePatientResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("address")]
    public CreatePatientResponseAddress? Address { get; set; }

    [JsonPropertyName("defaultShippingAddressId")]
    public string? DefaultShippingAddressId { get; set; }

    [JsonPropertyName("shippingAddress")]
    public CreatePatientResponseShippingAddress? ShippingAddress { get; set; }

    [JsonPropertyName("allergyReviewStatus")]
    public required CreatePatientResponseAllergyReviewStatus AllergyReviewStatus { get; set; }

    [JsonPropertyName("allergySummary")]
    public IEnumerable<CreatePatientResponseAllergySummaryItem> AllergySummary { get; set; } =
        new List<CreatePatientResponseAllergySummaryItem>();

    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("clinicalProfile")]
    public required CreatePatientResponseClinicalProfile ClinicalProfile { get; set; }

    [JsonPropertyName("dateOfBirth")]
    public required string DateOfBirth { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("externalIdentities")]
    public IEnumerable<CreatePatientResponseExternalIdentitiesItem> ExternalIdentities { get; set; } =
        new List<CreatePatientResponseExternalIdentitiesItem>();

    [JsonPropertyName("addresses")]
    public IEnumerable<CreatePatientResponseAddressesItem> Addresses { get; set; } =
        new List<CreatePatientResponseAddressesItem>();

    [JsonPropertyName("encounters")]
    public IEnumerable<CreatePatientResponseEncountersItem> Encounters { get; set; } =
        new List<CreatePatientResponseEncountersItem>();

    [JsonPropertyName("gender")]
    public required CreatePatientResponseGender Gender { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("livemode")]
    public required bool Livemode { get; set; }

    [JsonPropertyName("location")]
    public required CreatePatientResponseLocation Location { get; set; }

    [JsonPropertyName("locationId")]
    public required string LocationId { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, object?> Metadata { get; set; } = new Dictionary<string, object?>();

    [JsonPropertyName("medicalRecordNumber")]
    public string? MedicalRecordNumber { get; set; }

    [JsonPropertyName("measurements")]
    public IEnumerable<CreatePatientResponseMeasurementsItem> Measurements { get; set; } =
        new List<CreatePatientResponseMeasurementsItem>();

    [JsonPropertyName("name")]
    public required CreatePatientResponseName Name { get; set; }

    [JsonPropertyName("object")]
    public required CreatePatientResponseObject Object { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("programs")]
    public IEnumerable<CreatePatientResponseProgramsItem> Programs { get; set; } =
        new List<CreatePatientResponseProgramsItem>();

    [JsonPropertyName("practiceId")]
    public required string PracticeId { get; set; }

    [JsonPropertyName("status")]
    public required CreatePatientResponseStatus Status { get; set; }

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
