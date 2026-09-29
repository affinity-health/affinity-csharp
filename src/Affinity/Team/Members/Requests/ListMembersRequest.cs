using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity.Team;

[Serializable]
public record ListMembersRequest
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
    public ListMembersRequestRole? Role { get; set; }

    [JsonIgnore]
    public ListMembersRequestStatus? Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
