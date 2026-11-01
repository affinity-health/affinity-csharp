using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListMedicationsRequest
{
    /// <summary>
    /// Quote prices and availability for this practice. A platform may select only its own child practices; a practice may select only itself. Omit to use the caller's organization.
    /// </summary>
    [JsonIgnore]
    public string? PracticeId { get; set; }

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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
