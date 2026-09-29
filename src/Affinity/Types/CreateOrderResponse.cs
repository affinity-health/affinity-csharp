using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CreateOrderResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Opaque revision of the complete order prescription set. Send the revision you reviewed as expectedRevision; never replace it automatically after a conflict.
    /// </summary>
    [JsonPropertyName("revision")]
    public required string Revision { get; set; }

    [JsonPropertyName("otcItems")]
    public IEnumerable<CreateOrderResponseOtcItemsItem> OtcItems { get; set; } =
        new List<CreateOrderResponseOtcItemsItem>();

    [JsonPropertyName("externalOrderId")]
    public string? ExternalOrderId { get; set; }

    [JsonPropertyName("metadata")]
    public required CreateOrderResponseMetadata Metadata { get; set; }

    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("livemode")]
    public required bool Livemode { get; set; }

    [JsonPropertyName("object")]
    public required CreateOrderResponseObject Object { get; set; }

    [JsonPropertyName("patientId")]
    public required string PatientId { get; set; }

    [JsonPropertyName("practiceId")]
    public required string PracticeId { get; set; }

    [JsonPropertyName("prescriptions")]
    public IEnumerable<CreateOrderResponsePrescriptionsItem> Prescriptions { get; set; } =
        new List<CreateOrderResponsePrescriptionsItem>();

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("status")]
    public required CreateOrderResponseStatus Status { get; set; }

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
