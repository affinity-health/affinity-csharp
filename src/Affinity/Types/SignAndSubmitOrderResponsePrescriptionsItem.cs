using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record SignAndSubmitOrderResponsePrescriptionsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("prescriptionId")]
    public required string PrescriptionId { get; set; }

    [JsonPropertyName("status")]
    public required SignAndSubmitOrderResponsePrescriptionsItemStatus Status { get; set; }

    [JsonPropertyName("fulfillmentOrderId")]
    public string? FulfillmentOrderId { get; set; }

    [JsonPropertyName("error")]
    public SignAndSubmitOrderResponsePrescriptionsItemError? Error { get; set; }

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
