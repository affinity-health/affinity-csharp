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

    /// <summary>
    /// The street address. Line 1 and line 2 together: 70 characters or fewer.
    /// </summary>
    [JsonPropertyName("line1")]
    public string? Line1 { get; set; }

    /// <summary>
    /// The apartment or suite. Send null, empty text, N/A, NA, none or - to remove it. See notes, TBD and unknown return 422. An omitted `line2` keeps the saved suite, also when `line1` changes.
    /// </summary>
    [JsonPropertyName("line2")]
    public string? Line2 { get; set; }

    /// <summary>
    /// The city name.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// The two-letter code of a US state, DC or PR, in any letter case. Affinity stores and returns it in upper case.
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
