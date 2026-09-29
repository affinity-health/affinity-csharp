using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListWebhookEndpointsRequest
{
    [JsonIgnore]
    public string? EndingBefore { get; set; }

    [JsonIgnore]
    public int? Limit { get; set; }

    [JsonIgnore]
    public string? StartingAfter { get; set; }

    /// <summary>
    /// Defaults to the API key organization. A platform may select a practice or pharmacy only with an explicit webhook grant in this mode. This changes the webhook owner, not the caller or event subscriptions.
    /// </summary>
    [JsonIgnore]
    public string? AffinityOrganizationId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
