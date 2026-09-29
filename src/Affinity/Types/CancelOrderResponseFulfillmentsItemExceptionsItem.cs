using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CancelOrderResponseFulfillmentsItemExceptionsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("actionable")]
    public required bool Actionable { get; set; }

    [JsonPropertyName("assignedTo")]
    public CancelOrderResponseFulfillmentsItemExceptionsItemAssignedTo? AssignedTo { get; set; }

    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("dueAt")]
    public string? DueAt { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("kind")]
    public required string Kind { get; set; }

    [JsonPropertyName("resolution")]
    public string? Resolution { get; set; }

    [JsonPropertyName("resolvedAt")]
    public string? ResolvedAt { get; set; }

    [JsonPropertyName("retryable")]
    public required bool Retryable { get; set; }

    [JsonPropertyName("severity")]
    public required CancelOrderResponseFulfillmentsItemExceptionsItemSeverity Severity { get; set; }

    [JsonPropertyName("status")]
    public required CancelOrderResponseFulfillmentsItemExceptionsItemStatus Status { get; set; }

    [JsonPropertyName("summary")]
    public required string Summary { get; set; }

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
