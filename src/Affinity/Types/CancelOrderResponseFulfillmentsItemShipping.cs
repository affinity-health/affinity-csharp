using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CancelOrderResponseFulfillmentsItemShipping : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("destinationType")]
    public required CancelOrderResponseFulfillmentsItemShippingDestinationType DestinationType { get; set; }

    [JsonPropertyName("method")]
    public required CancelOrderResponseFulfillmentsItemShippingMethod Method { get; set; }

    [JsonPropertyName("option")]
    public CancelOrderResponseFulfillmentsItemShippingOption? Option { get; set; }

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
