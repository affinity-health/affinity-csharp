using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

/// <summary>
/// The US mailing address.
/// </summary>
[Serializable]
public record AddressInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("line1")]
    public required string Line1 { get; set; }

    /// <summary>
    /// The apartment or suite, or null when there is none. Empty text counts as null.
    /// </summary>
    [JsonPropertyName("line2")]
    public string? Line2 { get; set; }

    [JsonPropertyName("city")]
    public required string City { get; set; }

    /// <summary>
    /// The two-letter US state or territory code, such as TX, in any letter case. Affinity stores and returns it in upper case.
    /// </summary>
    [JsonPropertyName("state")]
    public required string State { get; set; }

    /// <summary>
    /// The US ZIP code: 78701, or ZIP+4 as 78701-1234, 78701 1234 or 787011234. Affinity stores and returns 78701 or 78701-1234.
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
