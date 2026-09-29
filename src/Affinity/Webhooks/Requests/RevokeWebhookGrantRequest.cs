using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record RevokeWebhookGrantRequest
{
    [JsonIgnore]
    public required string PlatformId { get; set; }

    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
