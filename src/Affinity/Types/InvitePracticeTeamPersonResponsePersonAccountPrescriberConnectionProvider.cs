using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record InvitePracticeTeamPersonResponsePersonAccountPrescriberConnectionProvider
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("legalName")]
    public required string LegalName { get; set; }

    [JsonPropertyName("credentials")]
    public string? Credentials { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("address")]
    public InvitePracticeTeamPersonResponsePersonAccountPrescriberConnectionProviderAddress? Address { get; set; }

    [JsonPropertyName("npi")]
    public required string Npi { get; set; }

    [JsonPropertyName("practiceStatus")]
    public required string PracticeStatus { get; set; }

    [JsonPropertyName("licenses")]
    public IEnumerable<InvitePracticeTeamPersonResponsePersonAccountPrescriberConnectionProviderLicensesItem> Licenses { get; set; } =
        new List<InvitePracticeTeamPersonResponsePersonAccountPrescriberConnectionProviderLicensesItem>();

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
