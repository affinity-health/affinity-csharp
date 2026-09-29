using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CancelOrderRequest
{
    [JsonIgnore]
    public required string OrderId { get; set; }

    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// Required for user actors and optional for system actors. Omit both actor headers to use the authenticated service account as a system actor.
    /// </summary>
    [JsonIgnore]
    public string? AffinityActorId { get; set; }

    /// <summary>
    /// Use user when a person initiated the action and system for autonomous work. Omit both actor headers to default to system.
    /// </summary>
    [JsonIgnore]
    public string? AffinityActorType { get; set; }

    [JsonPropertyName("reason")]
    public required string Reason { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
