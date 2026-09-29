using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity.Team;

[Serializable]
public record ListInvitationsRequest
{
    [JsonIgnore]
    public required string PracticeId { get; set; }

    [JsonIgnore]
    public int? Limit { get; set; }

    [JsonIgnore]
    public string? StartingAfter { get; set; }

    [JsonIgnore]
    public string? EndingBefore { get; set; }

    [JsonIgnore]
    public ListInvitationsRequestStatus? Status { get; set; }

    [JsonIgnore]
    public string? Email { get; set; }

    /// <summary>
    /// Match this integration's external identity in the API key's mode.
    /// </summary>
    [JsonIgnore]
    public string? ExternalId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
