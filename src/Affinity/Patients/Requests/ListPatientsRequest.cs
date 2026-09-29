using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListPatientsRequest
{
    [JsonIgnore]
    public required string PracticeId { get; set; }

    [JsonIgnore]
    public string? EndingBefore { get; set; }

    [JsonIgnore]
    public string? ExternalId { get; set; }

    [JsonIgnore]
    public string? ExternalIdentitySource { get; set; }

    [JsonIgnore]
    public string? ExternalIdentityValue { get; set; }

    [JsonIgnore]
    public ListPatientsRequestGender? Gender { get; set; }

    [JsonIgnore]
    public string? LastOrderAfter { get; set; }

    [JsonIgnore]
    public string? LastOrderBefore { get; set; }

    [JsonIgnore]
    public int? Limit { get; set; }

    [JsonIgnore]
    public string? Program { get; set; }

    [JsonIgnore]
    public string? Query { get; set; }

    [JsonIgnore]
    public ListPatientsRequestSort? Sort { get; set; }

    [JsonIgnore]
    public string? StartingAfter { get; set; }

    [JsonIgnore]
    public string? States { get; set; }

    [JsonIgnore]
    public ListPatientsRequestStatus? Status { get; set; }

    /// <summary>
    /// Required for user actors and optional for system actors. Omit both actor headers to use the authenticated service account as a system actor.
    /// </summary>
    [JsonIgnore]
    public string? AffinityActorId { get; set; }

    /// <summary>
    /// Use user when a person initiated the action and system for autonomous work. Omit both actor headers to default to system.
    /// </summary>
    [JsonIgnore]
    public string? AffinityActorType { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
