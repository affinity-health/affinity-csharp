using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record GetOrderResponseFulfillmentsItemShippingOption : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("amountCents")]
    public required int AmountCents { get; set; }

    [JsonPropertyName("currency")]
    public required GetOrderResponseFulfillmentsItemShippingOptionCurrency Currency { get; set; }

    [JsonPropertyName("label")]
    public required string Label { get; set; }

    [JsonPropertyName("serviceLevel")]
    public required string ServiceLevel { get; set; }

    [JsonPropertyName("temperature")]
    public required GetOrderResponseFulfillmentsItemShippingOptionTemperature Temperature { get; set; }

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
