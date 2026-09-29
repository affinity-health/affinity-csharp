using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record PreviewOrderResponseOrderInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("otcItems")]
    public IEnumerable<PreviewOrderResponseOrderInputOtcItemsItem>? OtcItems { get; set; }

    [JsonPropertyName("practiceId")]
    public required string PracticeId { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("prescriber")]
    public PreviewOrderResponseOrderInputPrescriber? Prescriber { get; set; }

    [JsonPropertyName("shippingAddressId")]
    public string? ShippingAddressId { get; set; }

    [JsonPropertyName("externalOrderId")]
    public string? ExternalOrderId { get; set; }

    [JsonPropertyName("prescriptions")]
    public IEnumerable<PreviewOrderResponseOrderInputPrescriptionsItem> Prescriptions { get; set; } =
        new List<PreviewOrderResponseOrderInputPrescriptionsItem>();

    [JsonPropertyName("patientId")]
    public string? PatientId { get; set; }

    [JsonPropertyName("patient")]
    public PreviewOrderResponseOrderInputPatient? Patient { get; set; }

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
