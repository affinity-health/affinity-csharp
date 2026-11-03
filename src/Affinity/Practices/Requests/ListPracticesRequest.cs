using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListPracticesRequest
{
    /// <summary>
    /// Maximum records per page, from 1 to 100. Defaults to 25.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Page forward using the previous response's nextCursor. Keep the same filters, sort, organization and mode.
    /// </summary>
    [JsonIgnore]
    public string? StartingAfter { get; set; }

    /// <summary>
    /// Match the external practice ID exactly, including case. Keep this filter unchanged while paging.
    /// </summary>
    [JsonIgnore]
    public string? ExternalId { get; set; }

    /// <summary>
    /// Match practice names containing this text, ignoring case. Restart pagination after changing query.
    /// </summary>
    [JsonIgnore]
    public string? Query { get; set; }

    /// <summary>
    /// name and location sort A to Z; mode sorts practices without Live access before those with it; created sorts oldest first. A _desc suffix reverses the order. Defaults to created_desc. Missing locations sort last. Restart pagination after changing sort.
    /// </summary>
    [JsonIgnore]
    public ListPracticesRequestSort? Sort { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
