using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CancelOrderResponseFulfillmentsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("carrier")]
    public string? Carrier { get; set; }

    [JsonPropertyName("cancellations")]
    public IEnumerable<CancelOrderResponseFulfillmentsItemCancellationsItem> Cancellations { get; set; } =
        new List<CancelOrderResponseFulfillmentsItemCancellationsItem>();

    [JsonPropertyName("pharmacyId")]
    public string? PharmacyId { get; set; }

    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("prescriptionId")]
    public required string PrescriptionId { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("trackingNumber")]
    public string? TrackingNumber { get; set; }

    [JsonPropertyName("trackingStatus")]
    public string? TrackingStatus { get; set; }

    [JsonPropertyName("shippedAt")]
    public string? ShippedAt { get; set; }

    [JsonPropertyName("deliveredAt")]
    public string? DeliveredAt { get; set; }

    [JsonPropertyName("estimatedDeliveryAt")]
    public string? EstimatedDeliveryAt { get; set; }

    [JsonPropertyName("exceptions")]
    public IEnumerable<CancelOrderResponseFulfillmentsItemExceptionsItem> Exceptions { get; set; } =
        new List<CancelOrderResponseFulfillmentsItemExceptionsItem>();

    [JsonPropertyName("shipping")]
    public required CancelOrderResponseFulfillmentsItemShipping Shipping { get; set; }

    [JsonPropertyName("shipments")]
    public IEnumerable<CancelOrderResponseFulfillmentsItemShipmentsItem> Shipments { get; set; } =
        new List<CancelOrderResponseFulfillmentsItemShipmentsItem>();

    [JsonPropertyName("trackingUrl")]
    public string? TrackingUrl { get; set; }

    [JsonPropertyName("updatedAt")]
    public required string UpdatedAt { get; set; }

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
