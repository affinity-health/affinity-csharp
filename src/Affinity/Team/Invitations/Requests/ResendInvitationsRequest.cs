using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity.Team;

[Serializable]
public record ResendInvitationsRequest
{
    [JsonIgnore]
    public required string PracticeId { get; set; }

    [JsonIgnore]
    public required string InvitationId { get; set; }

    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
