using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

/// <summary>
/// An event about one prescription of an order. Affinity does not send these yet: no released pharmacy reports a prescription apart from its order. Handle them so that a later release does not break your receiver.
/// </summary>
[Serializable]
public record PrescriptionEvent : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The event identifier; retries and resends keep the same identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// When the event was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The event payload.
    /// </summary>
    [JsonPropertyName("data")]
    public required PrescriptionEventData Data { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
