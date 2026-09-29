using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record PreviewOrderResponseTotals : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("currency")]
    public required PreviewOrderResponseTotalsCurrency Currency { get; set; }

    [JsonPropertyName("medicationSubtotalCents")]
    public int? MedicationSubtotalCents { get; set; }

    [JsonPropertyName("supplySubtotalCents")]
    public int? SupplySubtotalCents { get; set; }

    [JsonPropertyName("shippingTotalCents")]
    public int? ShippingTotalCents { get; set; }

    [JsonPropertyName("estimatedTotalCents")]
    public int? EstimatedTotalCents { get; set; }

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
