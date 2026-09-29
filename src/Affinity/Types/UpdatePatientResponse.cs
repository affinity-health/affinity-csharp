using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record UpdatePatientResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("address")]
    public UpdatePatientResponseAddress? Address { get; set; }

    [JsonPropertyName("defaultShippingAddressId")]
    public string? DefaultShippingAddressId { get; set; }

    [JsonPropertyName("shippingAddress")]
    public UpdatePatientResponseShippingAddress? ShippingAddress { get; set; }

    [JsonPropertyName("allergyReviewStatus")]
    public required UpdatePatientResponseAllergyReviewStatus AllergyReviewStatus { get; set; }

    [JsonPropertyName("allergySummary")]
    public IEnumerable<UpdatePatientResponseAllergySummaryItem> AllergySummary { get; set; } =
        new List<UpdatePatientResponseAllergySummaryItem>();

    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("clinicalProfile")]
    public required UpdatePatientResponseClinicalProfile ClinicalProfile { get; set; }

    [JsonPropertyName("dateOfBirth")]
    public required string DateOfBirth { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("externalIdentities")]
    public IEnumerable<UpdatePatientResponseExternalIdentitiesItem> ExternalIdentities { get; set; } =
        new List<UpdatePatientResponseExternalIdentitiesItem>();

    [JsonPropertyName("addresses")]
    public IEnumerable<UpdatePatientResponseAddressesItem> Addresses { get; set; } =
        new List<UpdatePatientResponseAddressesItem>();

    [JsonPropertyName("encounters")]
    public IEnumerable<UpdatePatientResponseEncountersItem> Encounters { get; set; } =
        new List<UpdatePatientResponseEncountersItem>();

    [JsonPropertyName("gender")]
    public required UpdatePatientResponseGender Gender { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("livemode")]
    public required bool Livemode { get; set; }

    [JsonPropertyName("location")]
    public required UpdatePatientResponseLocation Location { get; set; }

    [JsonPropertyName("locationId")]
    public required string LocationId { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, object?> Metadata { get; set; } = new Dictionary<string, object?>();

    [JsonPropertyName("medicalRecordNumber")]
    public string? MedicalRecordNumber { get; set; }

    [JsonPropertyName("measurements")]
    public IEnumerable<UpdatePatientResponseMeasurementsItem> Measurements { get; set; } =
        new List<UpdatePatientResponseMeasurementsItem>();

    [JsonPropertyName("name")]
    public required UpdatePatientResponseName Name { get; set; }

    [JsonPropertyName("object")]
    public required UpdatePatientResponseObject Object { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("programs")]
    public IEnumerable<UpdatePatientResponseProgramsItem> Programs { get; set; } =
        new List<UpdatePatientResponseProgramsItem>();

    [JsonPropertyName("practiceId")]
    public required string PracticeId { get; set; }

    [JsonPropertyName("status")]
    public required UpdatePatientResponseStatus Status { get; set; }

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
