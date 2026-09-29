using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListOrdersRequest
{
    [JsonIgnore]
    public string? Query { get; set; }

    [JsonIgnore]
    public string? ExternalOrderId { get; set; }

    [JsonIgnore]
    public string? CreatedAfter { get; set; }

    [JsonIgnore]
    public string? CreatedBefore { get; set; }

    [JsonIgnore]
    public string? EndingBefore { get; set; }

    [JsonIgnore]
    public int? Limit { get; set; }

    [JsonIgnore]
    public string? OrderId { get; set; }

    [JsonIgnore]
    public string? PatientId { get; set; }

    [JsonIgnore]
    public string? PatientExternalId { get; set; }

    [JsonIgnore]
    public string? PracticeId { get; set; }

    [JsonIgnore]
    public ListOrdersRequestSort? Sort { get; set; }

    [JsonIgnore]
    public string? StartingAfter { get; set; }

    [JsonIgnore]
    public ListOrdersRequestStatus? Status { get; set; }

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
