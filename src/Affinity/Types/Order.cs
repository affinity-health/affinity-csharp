using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record Order : IJsonOnDeserialized, IJsonOnSerializing
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
    /// When the record was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

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
    /// The Test or Live mode of this record.
    /// </summary>
    [JsonPropertyName("mode")]
    public required OrderMode Mode { get; set; }

    [JsonPropertyName("patient")]
    public required Patient Patient { get; set; }

    /// <summary>
    /// The patient's public identifier.
    /// </summary>
    [JsonPropertyName("patientId")]
    public required string PatientId { get; set; }

    /// <summary>
    /// The practice contact details saved when the order was signed, or null for historical orders without a snapshot.
    /// </summary>
    [JsonPropertyName("practice")]
    public OrderPractice? Practice { get; set; }

    /// <summary>
    /// The practice's public identifier.
    /// </summary>
    [JsonPropertyName("practiceId")]
    public required string PracticeId { get; set; }

    /// <summary>
    /// The prescribing clinician's details saved when the order was signed.
    /// </summary>
    [JsonPropertyName("prescriber")]
    public OrderPrescriber? Prescriber { get; set; }

    /// <summary>
    /// The prescriptions for this order's patient.
    /// </summary>
    [JsonPropertyName("prescriptions")]
    public IEnumerable<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    /// <summary>
    /// The shipping option and destination.
    /// </summary>
    [JsonPropertyName("shipping")]
    public required OrderShipping Shipping { get; set; }

    /// <summary>
    /// The shipped packages, oldest first; a split shipment or reshipment adds a package.
    /// </summary>
    [JsonPropertyName("shipments")]
    public IEnumerable<Shipment> Shipments { get; set; } = new List<Shipment>();

    /// <summary>
    /// The current fulfillment status.
    /// </summary>
    [JsonPropertyName("status")]
    public required OrderStatus Status { get; set; }

    /// <summary>
    /// The carrier's tracking page for the newest package, or null before the order ships.
    /// </summary>
    [JsonPropertyName("trackingUrl")]
    public string? TrackingUrl { get; set; }

    /// <summary>
    /// The order's status changes, oldest first.
    /// </summary>
    [JsonPropertyName("statusHistory")]
    public IEnumerable<StatusHistoryEntry> StatusHistory { get; set; } =
        new List<StatusHistoryEntry>();

    /// <summary>
    /// The total order price in integer cents, including medication and shipping.
    /// </summary>
    [JsonPropertyName("total")]
    public required int Total { get; set; }

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
