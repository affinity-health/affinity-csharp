using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

/// <summary>
/// The shipping option and destination.
/// </summary>
[Serializable]
public record OrderShipping : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The shipping option saved at signing, or null for historical orders without an option.
    /// </summary>
    [JsonPropertyName("option")]
    public OrderShippingOption? Option { get; set; }

    [JsonPropertyName("destination")]
    public required ShippingDestination Destination { get; set; }

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
