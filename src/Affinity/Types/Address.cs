using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

/// <summary>
/// The US mailing address.
/// </summary>
[Serializable]
public record Address : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The street address.
    /// </summary>
    [JsonPropertyName("line1")]
    public required string Line1 { get; set; }

    /// <summary>
    /// The apartment or suite, or null when there is none.
    /// </summary>
    [JsonPropertyName("line2")]
    public string? Line2 { get; set; }

    /// <summary>
    /// The city name.
    /// </summary>
    [JsonPropertyName("city")]
    public required string City { get; set; }

    /// <summary>
    /// The two-letter US state code.
    /// </summary>
    [JsonPropertyName("state")]
    public required string State { get; set; }

    /// <summary>
    /// The US ZIP code.
    /// </summary>
    [JsonPropertyName("postalCode")]
    public required string PostalCode { get; set; }

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
