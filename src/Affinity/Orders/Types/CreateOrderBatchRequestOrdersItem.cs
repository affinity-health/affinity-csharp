using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity;

[Serializable]
public record CreateOrderBatchRequestOrdersItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("otcItems")]
    public IEnumerable<CreateOrderBatchRequestOrdersItemOtcItemsItem>? OtcItems { get; set; }

    [JsonPropertyName("externalOrderId")]
    public string? ExternalOrderId { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, OneOf<string, double, bool>?>? Metadata { get; set; }

    [JsonPropertyName("patientId")]
    public string? PatientId { get; set; }

    [JsonPropertyName("patient")]
    public CreateOrderBatchRequestOrdersItemPatient? Patient { get; set; }

    [JsonPropertyName("shippingAddressId")]
    public string? ShippingAddressId { get; set; }

    [JsonPropertyName("prescriptions")]
    public IEnumerable<CreateOrderBatchRequestOrdersItemPrescriptionsItem> Prescriptions { get; set; } =
        new List<CreateOrderBatchRequestOrdersItemPrescriptionsItem>();

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
