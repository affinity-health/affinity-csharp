using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListPracticeTeamPrescribersRequest
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
    public string? Npi { get; set; }

    /// <summary>
    /// Match a submitted license jurisdiction. This does not establish signing eligibility.
    /// </summary>
    [JsonIgnore]
    public string? State { get; set; }

    [JsonIgnore]
    public ListPracticeTeamPrescribersRequestStatus? Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
