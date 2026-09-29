using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record UpdateOrderTestSimulationRequest
{
    [JsonIgnore]
    public required string OrderId { get; set; }

    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

    [JsonPropertyName("mode")]
    public required UpdateOrderTestSimulationRequestMode Mode { get; set; }

    [JsonPropertyName("scenario")]
    public required UpdateOrderTestSimulationRequestScenario Scenario { get; set; }

    [JsonPropertyName("action")]
    public UpdateOrderTestSimulationRequestAction? Action { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
