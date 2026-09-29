using Affinity.Core;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity;

[Serializable]
public record CreateOrderRequest
{
    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// Required for user actors and optional for system actors. Omit both actor headers to use the authenticated service account as a system actor.
    /// </summary>
    [JsonIgnore]
    public string? AffinityActorId { get; set; }

    /// <summary>
    /// Use user when a person initiated the action and system for autonomous work. Omit both actor headers to default to system.
    /// </summary>
    [JsonIgnore]
    public string? AffinityActorType { get; set; }

    [JsonPropertyName("practiceId")]
    public required string PracticeId { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("prescriber")]
    public CreateOrderRequestPrescriber? Prescriber { get; set; }

    [JsonPropertyName("otcItems")]
    public IEnumerable<CreateOrderRequestOtcItemsItem>? OtcItems { get; set; }

    [JsonPropertyName("externalOrderId")]
    public string? ExternalOrderId { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, OneOf<string, double, bool>?>? Metadata { get; set; }

    [JsonPropertyName("patientId")]
    public string? PatientId { get; set; }

    [JsonPropertyName("patient")]
    public CreateOrderRequestPatient? Patient { get; set; }

    [JsonPropertyName("shippingAddressId")]
    public string? ShippingAddressId { get; set; }

    [JsonPropertyName("prescriptions")]
    public IEnumerable<CreateOrderRequestPrescriptionsItem> Prescriptions { get; set; } =
        new List<CreateOrderRequestPrescriptionsItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
