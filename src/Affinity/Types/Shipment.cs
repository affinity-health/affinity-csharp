using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record Shipment : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The carrier name, or null when it is unknown.
    /// </summary>
    [JsonPropertyName("carrier")]
    public string? Carrier { get; set; }

    /// <summary>
    /// The package tracking number.
    /// </summary>
    [JsonPropertyName("trackingNumber")]
    public required string TrackingNumber { get; set; }

    /// <summary>
    /// The carrier's tracking page for this package, or null when the carrier has none.
    /// </summary>
    [JsonPropertyName("trackingUrl")]
    public string? TrackingUrl { get; set; }

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
