using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListWebhooksRequest
{
    /// <summary>
    /// Page backward before this opaque cursor. Keep the same filters, sort, organization and mode. Send either startingAfter or endingBefore.
    /// </summary>
    [JsonIgnore]
    public string? EndingBefore { get; set; }

    /// <summary>
    /// Maximum records per page, from 1 to 100. Defaults to 25.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Page forward using the previous response's nextCursor. Keep the same filters, sort, organization and mode. Use only one cursor parameter.
    /// </summary>
    [JsonIgnore]
    public string? StartingAfter { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
