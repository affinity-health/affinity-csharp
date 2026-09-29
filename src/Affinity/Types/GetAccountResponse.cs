using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record GetAccountResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("account")]
    public required GetAccountResponseAccount Account { get; set; }

    /// <summary>
    /// True for a Live request; false for a Test request.
    /// </summary>
    [JsonPropertyName("livemode")]
    public required bool Livemode { get; set; }

    /// <summary>
    /// Effective scopes of the authenticated API key. Null for a dashboard session; use membership.permissions for that session.
    /// </summary>
    [JsonPropertyName("scopes")]
    public IEnumerable<string>? Scopes { get; set; }

    [JsonPropertyName("membership")]
    public required GetAccountResponseMembership Membership { get; set; }

    /// <summary>
    /// The organization's Live-access status, independent of this request's livemode.
    /// </summary>
    [JsonPropertyName("operatingMode")]
    public required GetAccountResponseOperatingMode OperatingMode { get; set; }

    [JsonPropertyName("user")]
    public required GetAccountResponseUser User { get; set; }

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
