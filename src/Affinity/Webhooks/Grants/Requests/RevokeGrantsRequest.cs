using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity.Webhooks;

[Serializable]
public record RevokeGrantsRequest
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
