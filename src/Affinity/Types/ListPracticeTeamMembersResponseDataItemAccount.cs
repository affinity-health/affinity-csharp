using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListPracticeTeamMembersResponseDataItemAccount : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("accountId")]
    public required string AccountId { get; set; }

    [JsonPropertyName("emailVerified")]
    public required bool EmailVerified { get; set; }

    [JsonPropertyName("membershipId")]
    public required string MembershipId { get; set; }

    [JsonPropertyName("membershipStatus")]
    public required string MembershipStatus { get; set; }

    [JsonPropertyName("roles")]
    public IEnumerable<ListPracticeTeamMembersResponseDataItemAccountRolesItem> Roles { get; set; } =
        new List<ListPracticeTeamMembersResponseDataItemAccountRolesItem>();

    [JsonPropertyName("prescriberConnection")]
    public ListPracticeTeamMembersResponseDataItemAccountPrescriberConnection? PrescriberConnection { get; set; }

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
