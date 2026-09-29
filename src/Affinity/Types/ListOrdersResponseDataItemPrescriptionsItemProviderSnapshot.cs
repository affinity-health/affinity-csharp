using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListOrdersResponseDataItemPrescriptionsItemProviderSnapshot : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("address")]
    public Dictionary<string, object?>? Address { get; set; }

    [JsonPropertyName("credentials")]
    public string? Credentials { get; set; }

    [JsonPropertyName("legalName")]
    public required string LegalName { get; set; }

    [JsonPropertyName("licenseNumber")]
    public string? LicenseNumber { get; set; }

    [JsonPropertyName("licenseState")]
    public string? LicenseState { get; set; }

    [JsonPropertyName("licenseExpiresAt")]
    public string? LicenseExpiresAt { get; set; }

    [JsonPropertyName("npi")]
    public required string Npi { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

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
