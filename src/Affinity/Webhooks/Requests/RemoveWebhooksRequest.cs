using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record RemoveWebhooksRequest
{
    /// <summary>
    /// The webhook endpoint ID.
    /// </summary>
    [JsonIgnore]
    public required string WebhookEndpointId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
