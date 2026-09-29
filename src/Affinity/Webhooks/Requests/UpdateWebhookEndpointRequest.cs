using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record UpdateWebhookEndpointRequest
{
    [JsonIgnore]
    public required string EndpointId { get; set; }

    /// <summary>
    /// Defaults to the API key organization. A platform may select a practice or pharmacy only with an explicit webhook grant in this mode. This changes the webhook owner, not the caller or event subscriptions.
    /// </summary>
    [JsonIgnore]
    public string? AffinityOrganizationId { get; set; }

    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

    [JsonPropertyName("practiceIds")]
    public IEnumerable<string>? PracticeIds { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("payloadStyle")]
    public UpdateWebhookEndpointRequestPayloadStyle? PayloadStyle { get; set; }

    [JsonPropertyName("status")]
    public UpdateWebhookEndpointRequestStatus? Status { get; set; }

    [JsonPropertyName("subscribedEvents")]
    public IEnumerable<UpdateWebhookEndpointRequestSubscribedEventsItem>? SubscribedEvents { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
