using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record GetOrderResponseFulfillmentsItemShipping : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("destinationType")]
    public required GetOrderResponseFulfillmentsItemShippingDestinationType DestinationType { get; set; }

    [JsonPropertyName("method")]
    public required GetOrderResponseFulfillmentsItemShippingMethod Method { get; set; }

    [JsonPropertyName("option")]
    public GetOrderResponseFulfillmentsItemShippingOption? Option { get; set; }

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
