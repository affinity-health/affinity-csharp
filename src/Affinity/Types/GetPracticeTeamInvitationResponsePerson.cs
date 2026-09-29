using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record GetPracticeTeamInvitationResponsePerson : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("object")]
    public required GetPracticeTeamInvitationResponsePersonObject Object { get; set; }

    [JsonPropertyName("externalId")]
    public required string ExternalId { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("invitation")]
    public GetPracticeTeamInvitationResponsePersonInvitation? Invitation { get; set; }

    [JsonPropertyName("account")]
    public GetPracticeTeamInvitationResponsePersonAccount? Account { get; set; }

    [JsonPropertyName("nextActions")]
    public IEnumerable<string> NextActions { get; set; } = new List<string>();

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
