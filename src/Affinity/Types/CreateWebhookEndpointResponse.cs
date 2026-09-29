using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CreateWebhookEndpointResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("organizationId")]
    public required string OrganizationId { get; set; }

    [JsonPropertyName("practiceIds")]
    public IEnumerable<string> PracticeIds { get; set; } = new List<string>();

    [JsonPropertyName("apiVersion")]
    public required string ApiVersion { get; set; }

    [JsonPropertyName("consecutiveFailures")]
    public required int ConsecutiveFailures { get; set; }

    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("livemode")]
    public required bool Livemode { get; set; }

    [JsonPropertyName("object")]
    public required CreateWebhookEndpointResponseObject Object { get; set; }

    [JsonPropertyName("payloadStyle")]
    public required CreateWebhookEndpointResponsePayloadStyle PayloadStyle { get; set; }

    [JsonPropertyName("status")]
    public required CreateWebhookEndpointResponseStatus Status { get; set; }

    [JsonPropertyName("subscribedEvents")]
    public IEnumerable<string> SubscribedEvents { get; set; } = new List<string>();

    [JsonPropertyName("updatedAt")]
    public required string UpdatedAt { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }

    [JsonPropertyName("signingSecret")]
    public required string SigningSecret { get; set; }

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
