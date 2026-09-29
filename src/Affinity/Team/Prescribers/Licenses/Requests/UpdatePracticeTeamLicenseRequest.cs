using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity.Team.Prescribers;

[Serializable]
public record UpdatePracticeTeamLicenseRequest
{
    [JsonIgnore]
    public required string PracticeId { get; set; }

    [JsonIgnore]
    public required string PrescriberId { get; set; }

    [JsonIgnore]
    public required string LicenseId { get; set; }

    /// <summary>
    /// Optional in the SDK. A fresh key is generated once per call when omitted. Supply a stable key to retry across calls.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("licenseNumber")]
    public string? LicenseNumber { get; set; }

    [JsonPropertyName("expiresAt")]
    public string? ExpiresAt { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
