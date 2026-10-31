using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

/// <summary>
/// The medication details saved when the order was signed.
/// </summary>
[Serializable]
public record PrescriptionMedication : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("fill")]
    public Fill? Fill { get; set; }

    /// <summary>
    /// The dosage form, or null when it is unknown.
    /// </summary>
    [JsonPropertyName("form")]
    public string? Form { get; set; }

    /// <summary>
    /// The public record identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The unit used to count the prescribed quantity, or null when it is unknown.
    /// </summary>
    [JsonPropertyName("quantityUnit")]
    public string? QuantityUnit { get; set; }

    /// <summary>
    /// The pharmacy's strength text, or null when it is unknown.
    /// </summary>
    [JsonPropertyName("strength")]
    public string? Strength { get; set; }

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
