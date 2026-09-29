using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record GetAccountResponseMembership : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Effective API scopes for a service key; dashboard permissions for a signed-in member.
    /// </summary>
    [JsonPropertyName("permissions")]
    public IEnumerable<string> Permissions { get; set; } = new List<string>();

    [JsonPropertyName("role")]
    public required GetAccountResponseMembershipRole Role { get; set; }

    [JsonPropertyName("roleName")]
    public required string RoleName { get; set; }

    [JsonPropertyName("status")]
    public required GetAccountResponseMembershipStatus Status { get; set; }

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
