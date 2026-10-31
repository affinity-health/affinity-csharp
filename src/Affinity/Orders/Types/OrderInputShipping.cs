using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

/// <summary>
/// The shipping option and destination.
/// </summary>
[Serializable]
public record OrderInputShipping : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The shipping option identifier from the medication's shippingOptions.
    /// </summary>
    [JsonPropertyName("optionId")]
    public required string OptionId { get; set; }

    [JsonPropertyName("destination")]
    public ShippingDestinationInput? Destination { get; set; }

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
