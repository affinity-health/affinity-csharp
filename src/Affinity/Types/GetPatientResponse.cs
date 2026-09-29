using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record GetPatientResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("address")]
    public GetPatientResponseAddress? Address { get; set; }

    [JsonPropertyName("defaultShippingAddressId")]
    public string? DefaultShippingAddressId { get; set; }

    [JsonPropertyName("shippingAddress")]
    public GetPatientResponseShippingAddress? ShippingAddress { get; set; }

    [JsonPropertyName("allergyReviewStatus")]
    public required GetPatientResponseAllergyReviewStatus AllergyReviewStatus { get; set; }

    [JsonPropertyName("allergySummary")]
    public IEnumerable<GetPatientResponseAllergySummaryItem> AllergySummary { get; set; } =
        new List<GetPatientResponseAllergySummaryItem>();

    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("clinicalProfile")]
    public required GetPatientResponseClinicalProfile ClinicalProfile { get; set; }

    [JsonPropertyName("dateOfBirth")]
    public required string DateOfBirth { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("externalIdentities")]
    public IEnumerable<GetPatientResponseExternalIdentitiesItem> ExternalIdentities { get; set; } =
        new List<GetPatientResponseExternalIdentitiesItem>();

    [JsonPropertyName("addresses")]
    public IEnumerable<GetPatientResponseAddressesItem> Addresses { get; set; } =
        new List<GetPatientResponseAddressesItem>();

    [JsonPropertyName("encounters")]
    public IEnumerable<GetPatientResponseEncountersItem> Encounters { get; set; } =
        new List<GetPatientResponseEncountersItem>();

    [JsonPropertyName("gender")]
    public required GetPatientResponseGender Gender { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("livemode")]
    public required bool Livemode { get; set; }

    [JsonPropertyName("location")]
    public required GetPatientResponseLocation Location { get; set; }

    [JsonPropertyName("locationId")]
    public required string LocationId { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, object?> Metadata { get; set; } = new Dictionary<string, object?>();

    [JsonPropertyName("medicalRecordNumber")]
    public string? MedicalRecordNumber { get; set; }

    [JsonPropertyName("measurements")]
    public IEnumerable<GetPatientResponseMeasurementsItem> Measurements { get; set; } =
        new List<GetPatientResponseMeasurementsItem>();

    [JsonPropertyName("name")]
    public required GetPatientResponseName Name { get; set; }

    [JsonPropertyName("object")]
    public required GetPatientResponseObject Object { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("programs")]
    public IEnumerable<GetPatientResponseProgramsItem> Programs { get; set; } =
        new List<GetPatientResponseProgramsItem>();

    [JsonPropertyName("practiceId")]
    public required string PracticeId { get; set; }

    [JsonPropertyName("status")]
    public required GetPatientResponseStatus Status { get; set; }

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
