using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListPharmaciesRequest
{
    [JsonIgnore]
    public string? EndingBefore { get; set; }

    [JsonIgnore]
    public int? Limit { get; set; }

    [JsonIgnore]
    public string? OrgId { get; set; }

    [JsonIgnore]
    public string? PharmacyId { get; set; }

    [JsonIgnore]
    public string? Query { get; set; }

    [JsonIgnore]
    public string? ShipsToState { get; set; }

    [JsonIgnore]
    public string? StartingAfter { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
