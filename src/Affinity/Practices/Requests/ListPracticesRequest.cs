using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListPracticesRequest
{
    /// <summary>
    /// Case-insensitive search by practice name or external ID.
    /// </summary>
    [JsonIgnore]
    public string? Search { get; set; }

    [JsonIgnore]
    public string? EndingBefore { get; set; }

    [JsonIgnore]
    public int? Limit { get; set; }

    [JsonIgnore]
    public string? StartingAfter { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
