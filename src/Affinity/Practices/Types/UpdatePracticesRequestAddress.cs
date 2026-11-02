using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record UpdatePracticesRequestAddress : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("line1")]
    public string? Line1 { get; set; }

    /// <summary>
    /// The apartment or suite. Send null or empty text to remove it. An omitted `line2` keeps the saved suite, also when `line1` changes.
    /// </summary>
    [JsonPropertyName("line2")]
    public string? Line2 { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// The two-letter US state or territory code, such as TX, in any letter case. Affinity stores and returns it in upper case.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// The US ZIP code: 78701, or ZIP+4 as 78701-1234, 78701 1234 or 787011234. Affinity stores and returns 78701 or 78701-1234.
    /// </summary>
    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; set; }

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
