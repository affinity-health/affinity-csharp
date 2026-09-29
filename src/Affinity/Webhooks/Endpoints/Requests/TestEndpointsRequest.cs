using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity.Webhooks;

[Serializable]
public record TestEndpointsRequest
{
    [JsonIgnore]
    public required string EndpointId { get; set; }

    /// <summary>
    /// Defaults to the API key organization. A platform may select a practice or pharmacy only with an explicit webhook grant in this mode. This changes the webhook owner, not the caller or event subscriptions.
    /// </summary>
    [JsonIgnore]
    public string? AffinityOrganizationId { get; set; }

    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
