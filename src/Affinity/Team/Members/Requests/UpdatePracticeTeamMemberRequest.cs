using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity.Team;

[Serializable]
public record UpdatePracticeTeamMemberRequest
{
    [JsonIgnore]
    public required string PracticeId { get; set; }

    [JsonIgnore]
    public required string MemberId { get; set; }

    /// <summary>
    /// Optional in the SDK. A fresh key is generated once per call when omitted. Supply a stable key to retry across calls.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonPropertyName("role")]
    public UpdatePracticeTeamMemberRequestRole? Role { get; set; }

    [JsonPropertyName("roles")]
    public IEnumerable<UpdatePracticeTeamMemberRequestRolesItem>? Roles { get; set; }

    [JsonPropertyName("status")]
    public UpdatePracticeTeamMemberRequestStatus? Status { get; set; }

    /// <summary>
    /// Replace location access. An empty array grants access to all practice locations.
    /// </summary>
    [JsonPropertyName("locationIds")]
    public IEnumerable<string>? LocationIds { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
