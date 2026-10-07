using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity;

[Serializable]
public record AddOrderPrescriptionResponse : IJsonOnDeserialized
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
    public required AddOrderPrescriptionResponseObject Object { get; set; }

    [JsonPropertyName("externalOrderId")]
    public string? ExternalOrderId { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, OneOf<string, double, bool>?> Metadata { get; set; } =
        new Dictionary<string, OneOf<string, double, bool>?>();

    [JsonPropertyName("orderId")]
    public required string OrderId { get; set; }

    [JsonPropertyName("prescriptionId")]
    public required string PrescriptionId { get; set; }

    [JsonPropertyName("prescriptions")]
    public IEnumerable<AddOrderPrescriptionResponsePrescriptionsItem> Prescriptions { get; set; } =
        new List<AddOrderPrescriptionResponsePrescriptionsItem>();

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
