using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record UpdatePracticeRequest
{
    [JsonIgnore]
    public required string PracticeId { get; set; }

    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// Enable or disable Live access for an owned practice. Requires an approved platform and a Live request. Affinity Admin decisions take precedence.
    /// </summary>
    [JsonPropertyName("liveEnabled")]
    public bool? LiveEnabled { get; set; }

    [JsonPropertyName("address")]
    public UpdatePracticeRequestAddress? Address { get; set; }

    [JsonPropertyName("attestations")]
    public UpdatePracticeRequestAttestations? Attestations { get; set; }

    [JsonPropertyName("complianceContact")]
    public UpdatePracticeRequestComplianceContact? ComplianceContact { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("legalName")]
    public string? LegalName { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("prescribers")]
    public IEnumerable<UpdatePracticeRequestPrescribersItem>? Prescribers { get; set; }

    [JsonPropertyName("primaryContact")]
    public UpdatePracticeRequestPrimaryContact? PrimaryContact { get; set; }

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
