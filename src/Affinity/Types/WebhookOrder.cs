using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

/// <summary>
/// The order's operational details without patient data or prescription clinical details. `failureReason` is always Affinity's own summary; a reason written by Affinity staff is in the order that `GET /v1/orders/{orderId}` returns.
/// </summary>
[Serializable]
public record WebhookOrder : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// When cancellation was requested, or null when no cancellation is waiting.
    /// </summary>
    [JsonPropertyName("cancelRequestedAt")]
    public DateTime? CancelRequestedAt { get; set; }

    /// <summary>
    /// Your order identifier, unique within the practice and mode.
    /// </summary>
    [JsonPropertyName("externalOrderId")]
    public string? ExternalOrderId { get; set; }

    /// <summary>
    /// The failure or cancellation refusal reason, or null when there is none.
    /// </summary>
    [JsonPropertyName("failureReason")]
    public string? FailureReason { get; set; }

    /// <summary>
    /// The public record identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The shipped packages, oldest first; a split shipment or reshipment adds a package.
    /// </summary>
    [JsonPropertyName("shipments")]
    public IEnumerable<Shipment> Shipments { get; set; } = new List<Shipment>();

    /// <summary>
    /// The prescriptions for this order's patient.
    /// </summary>
    [JsonPropertyName("prescriptions")]
    public IEnumerable<WebhookOrderPrescriptionsItem> Prescriptions { get; set; } =
        new List<WebhookOrderPrescriptionsItem>();

    /// <summary>
    /// The current fulfillment status.
    /// </summary>
    [JsonPropertyName("status")]
    public required WebhookOrderStatus Status { get; set; }

    /// <summary>
    /// The carrier's tracking page for the newest package, or null before the order ships.
    /// </summary>
    [JsonPropertyName("trackingUrl")]
    public string? TrackingUrl { get; set; }

    /// <summary>
    /// When the record was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
