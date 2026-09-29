using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListWebhookGrantsRequest
{
    [JsonIgnore]
    public int? Limit { get; set; }

    [JsonIgnore]
    public string? StartingAfter { get; set; }

    [JsonIgnore]
    public string? EndingBefore { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
