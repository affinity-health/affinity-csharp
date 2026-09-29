using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record SaveWebhookGrantRequest
{
    [JsonIgnore]
    public required string PlatformId { get; set; }

    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

    [JsonPropertyName("scopes")]
    public IEnumerable<SaveWebhookGrantRequestScopesItem> Scopes { get; set; } =
        new List<SaveWebhookGrantRequestScopesItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
