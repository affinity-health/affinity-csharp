using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListPracticesResponseDataItemPrescribersItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("credentials")]
    public string? Credentials { get; set; }

    [JsonPropertyName("licenseStates")]
    public IEnumerable<string> LicenseStates { get; set; } = new List<string>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

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
