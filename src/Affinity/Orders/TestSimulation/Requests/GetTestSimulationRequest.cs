using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity.Orders;

[Serializable]
public record GetTestSimulationRequest
{
    [JsonIgnore]
    public required string OrderId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
