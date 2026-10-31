using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

/// <summary>
/// Required with an API key. Send the prescribing clinician's NPI, firstName and lastName. Session callers can omit this field to sign with their own profile.
/// </summary>
[Serializable]
public record PrescriberInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A US phone number: 10 digits, with or without +1 or 1 before them. Spaces, dashes, dots and parentheses are allowed, such as (512) 555-0100. Affinity stores and returns +15125550100. Empty text counts as null. When the phone is omitted, null or blank, the order uses the practice phone.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("address")]
    public AddressInput? Address { get; set; }

    [JsonPropertyName("firstName")]
    public required string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public required string LastName { get; set; }

    /// <summary>
    /// The prescribing clinician's 10-digit National Provider Identifier (NPI). Surrounding spaces are removed.
    /// </summary>
    [JsonPropertyName("npi")]
    public required string Npi { get; set; }

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
