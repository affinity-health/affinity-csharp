using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CreateOrderBatchRequestOrdersItemPatient : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("address")]
    public CreateOrderBatchRequestOrdersItemPatientAddress? Address { get; set; }

    [JsonPropertyName("clinicalProfile")]
    public CreateOrderBatchRequestOrdersItemPatientClinicalProfile? ClinicalProfile { get; set; }

    [JsonPropertyName("dateOfBirth")]
    public required string DateOfBirth { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("externalIdentities")]
    public IEnumerable<CreateOrderBatchRequestOrdersItemPatientExternalIdentitiesItem>? ExternalIdentities { get; set; }

    [JsonPropertyName("addresses")]
    public IEnumerable<CreateOrderBatchRequestOrdersItemPatientAddressesItem>? Addresses { get; set; }

    [JsonPropertyName("encounters")]
    public IEnumerable<CreateOrderBatchRequestOrdersItemPatientEncountersItem>? Encounters { get; set; }

    [JsonPropertyName("gender")]
    public CreateOrderBatchRequestOrdersItemPatientGender? Gender { get; set; }

    [JsonPropertyName("locationId")]
    public string? LocationId { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    [JsonPropertyName("medicalRecordNumber")]
    public string? MedicalRecordNumber { get; set; }

    [JsonPropertyName("measurements")]
    public IEnumerable<CreateOrderBatchRequestOrdersItemPatientMeasurementsItem>? Measurements { get; set; }

    [JsonPropertyName("name")]
    public required CreateOrderBatchRequestOrdersItemPatientName Name { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("programs")]
    public IEnumerable<CreateOrderBatchRequestOrdersItemPatientProgramsItem>? Programs { get; set; }

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
