using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record UpdateWebhooksRequest
{
    /// <summary>
    /// The webhook endpoint ID.
    /// </summary>
    [JsonIgnore]
    public required string WebhookEndpointId { get; set; }

    /// <summary>
    /// A unique key per operation, 1 to 255 printable ASCII characters without spaces. Retry the same key and body to avoid repeating the action. The replay response depends on the operation. See https://docs.affinityrx.com/guides/#retry-safely.
    /// </summary>
    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
