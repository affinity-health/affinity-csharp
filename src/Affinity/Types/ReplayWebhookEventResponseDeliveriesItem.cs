using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity;

[Serializable]
public record ReplayWebhookEventResponseDeliveriesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("automaticAttemptCount")]
    public required OneOf<
        double,
        ReplayWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne
    > AutomaticAttemptCount { get; set; }

    [JsonPropertyName("endpointId")]
    public required string EndpointId { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("lastErrorCode")]
    public string? LastErrorCode { get; set; }

    [JsonPropertyName("lastErrorMessage")]
    public string? LastErrorMessage { get; set; }

    [JsonPropertyName("nextAttemptAt")]
    public string? NextAttemptAt { get; set; }

    [JsonPropertyName("status")]
    public required ReplayWebhookEventResponseDeliveriesItemStatus Status { get; set; }

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
