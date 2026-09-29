using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record GetWebhookEventResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("apiVersion")]
    public required string ApiVersion { get; set; }

    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("eventType")]
    public required string EventType { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("livemode")]
    public required bool Livemode { get; set; }

    [JsonPropertyName("object")]
    public required GetWebhookEventResponseObject Object { get; set; }

    [JsonPropertyName("resourceId")]
    public required string ResourceId { get; set; }

    [JsonPropertyName("resourceType")]
    public required string ResourceType { get; set; }

    [JsonPropertyName("status")]
    public required GetWebhookEventResponseStatus Status { get; set; }

    [JsonPropertyName("attempts")]
    public IEnumerable<GetWebhookEventResponseAttemptsItem> Attempts { get; set; } =
        new List<GetWebhookEventResponseAttemptsItem>();

    [JsonPropertyName("deliveries")]
    public IEnumerable<GetWebhookEventResponseDeliveriesItem> Deliveries { get; set; } =
        new List<GetWebhookEventResponseDeliveriesItem>();

    [JsonPropertyName("payload")]
    public Dictionary<string, object?> Payload { get; set; } = new Dictionary<string, object?>();

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
