using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity;

[Serializable]
public record ReplayWebhookEventResponseAttemptsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("deliveryId")]
    public required string DeliveryId { get; set; }

    [JsonPropertyName("endpointId")]
    public required string EndpointId { get; set; }

    [JsonPropertyName("attemptNumber")]
    public required int AttemptNumber { get; set; }

    [JsonPropertyName("completedAt")]
    public string? CompletedAt { get; set; }

    [JsonPropertyName("durationMs")]
    public OneOf<
        double,
        ReplayWebhookEventResponseAttemptsItemDurationMsOne
    >? DurationMs { get; set; }

    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("requestedAt")]
    public required string RequestedAt { get; set; }

    [JsonPropertyName("responseStatus")]
    public OneOf<
        double,
        ReplayWebhookEventResponseAttemptsItemResponseStatusOne
    >? ResponseStatus { get; set; }

    [JsonPropertyName("trigger")]
    public required ReplayWebhookEventResponseAttemptsItemTrigger Trigger { get; set; }

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
