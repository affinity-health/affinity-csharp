using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

/// <summary>
/// The practice's US mailing address. PerfectRx prints it: use Windows-1252 characters, without &lt; or &gt;. Line 1 and line 2 together: 70 characters or fewer.
/// </summary>
[Serializable]
public record PracticeAddressInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The street address. Line 1 and line 2 together: 70 characters or fewer.
    /// </summary>
    [JsonPropertyName("line1")]
    public required string Line1 { get; set; }

    /// <summary>
    /// The apartment or suite, or null when there is none. Empty text, N/A, NA, none and - count as null. See notes, TBD and unknown return 422. Line 1 and line 2 together: 70 characters or fewer.
    /// </summary>
    [JsonPropertyName("line2")]
    public string? Line2 { get; set; }

    /// <summary>
    /// The city name.
    /// </summary>
    [JsonPropertyName("city")]
    public required string City { get; set; }

    /// <summary>
    /// The two-letter code of a US state, DC or PR, in any letter case. Affinity stores and returns it in upper case.
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
