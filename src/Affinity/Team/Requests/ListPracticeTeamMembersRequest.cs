using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListPracticeTeamMembersRequest
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
    public string? Search { get; set; }

    [JsonIgnore]
    public ListPracticeTeamMembersRequestRole? Role { get; set; }

    [JsonIgnore]
    public ListPracticeTeamMembersRequestStatus? Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
