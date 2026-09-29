using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CancelOrderResponseFulfillmentsItemCancellationsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("attempts")]
    public required int Attempts { get; set; }

    [JsonPropertyName("confirmedAt")]
    public string? ConfirmedAt { get; set; }

    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("providerStatus")]
    public string? ProviderStatus { get; set; }

    [JsonPropertyName("reason")]
    public required string Reason { get; set; }

    [JsonPropertyName("requestedAt")]
    public required string RequestedAt { get; set; }

    [JsonPropertyName("requestedBy")]
    public required CancelOrderResponseFulfillmentsItemCancellationsItemRequestedBy RequestedBy { get; set; }

    [JsonPropertyName("resolvedAt")]
    public string? ResolvedAt { get; set; }

    [JsonPropertyName("sentAt")]
    public string? SentAt { get; set; }

    [JsonPropertyName("source")]
    public required CancelOrderResponseFulfillmentsItemCancellationsItemSource Source { get; set; }

    [JsonPropertyName("status")]
    public required CancelOrderResponseFulfillmentsItemCancellationsItemStatus Status { get; set; }

    [JsonPropertyName("updatedAt")]
    public required string UpdatedAt { get; set; }

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
