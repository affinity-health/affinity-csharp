using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record SignOrderResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("orderId")]
    public required string OrderId { get; set; }

    [JsonPropertyName("prescriptions")]
    public IEnumerable<string> Prescriptions { get; set; } = new List<string>();

    [JsonPropertyName("signedAt")]
    public required string SignedAt { get; set; }

    [JsonPropertyName("status")]
    public required SignOrderResponseStatus Status { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
