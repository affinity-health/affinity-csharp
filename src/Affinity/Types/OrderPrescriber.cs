using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record OrderPrescriber : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The first name.
    /// </summary>
    [JsonPropertyName("firstName")]
    public required string FirstName { get; set; }

    /// <summary>
    /// The last name.
    /// </summary>
    [JsonPropertyName("lastName")]
    public required string LastName { get; set; }

    /// <summary>
    /// The prescribing clinician's 10-digit National Provider Identifier (NPI).
    /// </summary>
    [JsonPropertyName("npi")]
    public required string Npi { get; set; }

    /// <summary>
    /// The contact phone number.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// The US mailing address.
    /// </summary>
    [JsonPropertyName("address")]
    public Address? Address { get; set; }

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
