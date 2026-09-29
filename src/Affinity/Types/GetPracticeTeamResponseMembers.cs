using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity;

[Serializable]
public record GetPracticeTeamResponseMembers : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("total")]
    public required OneOf<double, GetPracticeTeamResponseMembersTotalOne> Total { get; set; }

    [JsonPropertyName("active")]
    public required OneOf<double, GetPracticeTeamResponseMembersActiveOne> Active { get; set; }

    [JsonPropertyName("disabled")]
    public required OneOf<double, GetPracticeTeamResponseMembersDisabledOne> Disabled { get; set; }

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
