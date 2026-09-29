using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record PreviewOrderRequest
{
    [JsonPropertyName("otcItems")]
    public IEnumerable<PreviewOrderRequestOtcItemsItem>? OtcItems { get; set; }

    [JsonPropertyName("practiceId")]
    public required string PracticeId { get; set; }

    [JsonPropertyName("patientId")]
    public string? PatientId { get; set; }

    [JsonPropertyName("patientExternalId")]
    public string? PatientExternalId { get; set; }

    [JsonPropertyName("patient")]
    public PreviewOrderRequestPatient? Patient { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("prescriber")]
    public PreviewOrderRequestPrescriber? Prescriber { get; set; }

    [JsonPropertyName("shippingAddressId")]
    public string? ShippingAddressId { get; set; }

    [JsonPropertyName("externalOrderId")]
    public string? ExternalOrderId { get; set; }

    [JsonPropertyName("prescriptions")]
    public IEnumerable<PreviewOrderRequestPrescriptionsItem> Prescriptions { get; set; } =
        new List<PreviewOrderRequestPrescriptionsItem>();

    [JsonPropertyName("shipping")]
    public PreviewOrderRequestShipping? Shipping { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
