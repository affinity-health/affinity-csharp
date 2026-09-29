using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record UpdatePracticeTeamMemberRequest
{
    [JsonIgnore]
    public required string PracticeId { get; set; }

    [JsonIgnore]
    public required string MemberId { get; set; }

    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

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
