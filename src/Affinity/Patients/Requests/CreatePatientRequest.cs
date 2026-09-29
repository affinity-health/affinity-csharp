using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CreatePatientRequest
{
    [JsonIgnore]
    public required string PracticeId { get; set; }

    /// <summary>
    /// Optional in the SDK. A fresh key is generated once per call when omitted. Supply a stable key to retry across calls.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// Required for user actors and optional for system actors. Omit both actor headers to use the authenticated service account as a system actor.
    /// </summary>
    [JsonIgnore]
    public string? AffinityActorId { get; set; }

    /// <summary>
    /// Use user when a person initiated the action and system for autonomous work. Omit both actor headers to default to system.
    /// </summary>
    [JsonIgnore]
    public string? AffinityActorType { get; set; }

    [JsonPropertyName("address")]
    public CreatePatientRequestAddress? Address { get; set; }

    [JsonPropertyName("clinicalProfile")]
    public CreatePatientRequestClinicalProfile? ClinicalProfile { get; set; }

    [JsonPropertyName("dateOfBirth")]
    public required string DateOfBirth { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("externalIdentities")]
    public IEnumerable<CreatePatientRequestExternalIdentitiesItem>? ExternalIdentities { get; set; }

    [JsonPropertyName("addresses")]
    public IEnumerable<CreatePatientRequestAddressesItem>? Addresses { get; set; }

    [JsonPropertyName("encounters")]
    public IEnumerable<CreatePatientRequestEncountersItem>? Encounters { get; set; }

    [JsonPropertyName("gender")]
    public CreatePatientRequestGender? Gender { get; set; }

    [JsonPropertyName("locationId")]
    public string? LocationId { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    [JsonPropertyName("medicalRecordNumber")]
    public string? MedicalRecordNumber { get; set; }

    [JsonPropertyName("measurements")]
    public IEnumerable<CreatePatientRequestMeasurementsItem>? Measurements { get; set; }

    [JsonPropertyName("name")]
    public required CreatePatientRequestName Name { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("programs")]
    public IEnumerable<CreatePatientRequestProgramsItem>? Programs { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
