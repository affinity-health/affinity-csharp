using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CreateOrderRequestPatient : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("address")]
    public CreateOrderRequestPatientAddress? Address { get; set; }

    [JsonPropertyName("clinicalProfile")]
    public CreateOrderRequestPatientClinicalProfile? ClinicalProfile { get; set; }

    [JsonPropertyName("dateOfBirth")]
    public required string DateOfBirth { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("externalIdentities")]
    public IEnumerable<CreateOrderRequestPatientExternalIdentitiesItem>? ExternalIdentities { get; set; }

    [JsonPropertyName("addresses")]
    public IEnumerable<CreateOrderRequestPatientAddressesItem>? Addresses { get; set; }

    [JsonPropertyName("encounters")]
    public IEnumerable<CreateOrderRequestPatientEncountersItem>? Encounters { get; set; }

    [JsonPropertyName("gender")]
    public CreateOrderRequestPatientGender? Gender { get; set; }

    [JsonPropertyName("locationId")]
    public string? LocationId { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    [JsonPropertyName("medicalRecordNumber")]
    public string? MedicalRecordNumber { get; set; }

    [JsonPropertyName("measurements")]
    public IEnumerable<CreateOrderRequestPatientMeasurementsItem>? Measurements { get; set; }

    [JsonPropertyName("name")]
    public required CreateOrderRequestPatientName Name { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("programs")]
    public IEnumerable<CreateOrderRequestPatientProgramsItem>? Programs { get; set; }

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
