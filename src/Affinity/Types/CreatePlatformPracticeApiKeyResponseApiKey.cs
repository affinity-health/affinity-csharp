using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CreatePlatformPracticeApiKeyResponseApiKey : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("allowedIps")]
    public IEnumerable<string> AllowedIps { get; set; } = new List<string>();

    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("expiresAt")]
    public string? ExpiresAt { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("keyPrefix")]
    public required string KeyPrefix { get; set; }

    [JsonPropertyName("lastUsedAt")]
    public string? LastUsedAt { get; set; }

    [JsonPropertyName("mode")]
    public required CreatePlatformPracticeApiKeyResponseApiKeyMode Mode { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("revokedAt")]
    public string? RevokedAt { get; set; }

    [JsonPropertyName("scopes")]
    public IEnumerable<CreatePlatformPracticeApiKeyResponseApiKeyScopesItem> Scopes { get; set; } =
        new List<CreatePlatformPracticeApiKeyResponseApiKeyScopesItem>();

    [JsonPropertyName("status")]
    public required CreatePlatformPracticeApiKeyResponseApiKeyStatus Status { get; set; }

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
