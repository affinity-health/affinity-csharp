using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListOrdersResponseDataItemFulfillmentsItemShipmentsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("carrier")]
    public string? Carrier { get; set; }

    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("deliveredAt")]
    public string? DeliveredAt { get; set; }

    [JsonPropertyName("estimatedDeliveryAt")]
    public string? EstimatedDeliveryAt { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("isActive")]
    public required bool IsActive { get; set; }

    [JsonPropertyName("providerStatus")]
    public string? ProviderStatus { get; set; }

    [JsonPropertyName("replacedAt")]
    public string? ReplacedAt { get; set; }

    [JsonPropertyName("replacesShipmentId")]
    public string? ReplacesShipmentId { get; set; }

    [JsonPropertyName("shippedAt")]
    public string? ShippedAt { get; set; }

    [JsonPropertyName("source")]
    public required ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource Source { get; set; }

    [JsonPropertyName("status")]
    public required ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus Status { get; set; }

    [JsonPropertyName("trackingNumber")]
    public string? TrackingNumber { get; set; }

    [JsonPropertyName("trackingUrl")]
    public string? TrackingUrl { get; set; }

    [JsonPropertyName("updatedAt")]
    public required string UpdatedAt { get; set; }

    [JsonPropertyName("voidedAt")]
    public string? VoidedAt { get; set; }

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
