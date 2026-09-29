using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record UpdateOrderPrescriptionResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Opaque revision of the complete order prescription set. Send the revision you reviewed as expectedRevision; never replace it automatically after a conflict.
    /// </summary>
    [JsonPropertyName("revision")]
    public required string Revision { get; set; }

    [JsonPropertyName("object")]
    public required UpdateOrderPrescriptionResponseObject Object { get; set; }

    [JsonPropertyName("externalOrderId")]
    public string? ExternalOrderId { get; set; }

    [JsonPropertyName("metadata")]
    public required UpdateOrderPrescriptionResponseMetadata Metadata { get; set; }

    [JsonPropertyName("orderId")]
    public required string OrderId { get; set; }

    [JsonPropertyName("prescriptionId")]
    public required string PrescriptionId { get; set; }

    [JsonPropertyName("prescriptions")]
    public IEnumerable<UpdateOrderPrescriptionResponsePrescriptionsItem> Prescriptions { get; set; } =
        new List<UpdateOrderPrescriptionResponsePrescriptionsItem>();

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
