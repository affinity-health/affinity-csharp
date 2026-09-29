using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CreatePracticeRequest
{
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// Enable Live access at creation. Requires an approved platform and a Live request. Defaults to false.
    /// </summary>
    [JsonPropertyName("liveEnabled")]
    public bool? LiveEnabled { get; set; }

    [JsonPropertyName("address")]
    public required CreatePracticeRequestAddress Address { get; set; }

    [JsonPropertyName("attestations")]
    public required CreatePracticeRequestAttestations Attestations { get; set; }

    [JsonPropertyName("complianceContact")]
    public CreatePracticeRequestComplianceContact? ComplianceContact { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("legalName")]
    public string? LegalName { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("prescribers")]
    public IEnumerable<CreatePracticeRequestPrescribersItem>? Prescribers { get; set; }

    [JsonPropertyName("primaryContact")]
    public CreatePracticeRequestPrimaryContact? PrimaryContact { get; set; }

    [JsonPropertyName("supportEmail")]
    public string? SupportEmail { get; set; }

    [JsonPropertyName("supportPhone")]
    public string? SupportPhone { get; set; }

    /// <summary>
    /// Optional IANA timezone override. Omit to leave unchanged; null clears it. No timezone is inferred when creating a record.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
