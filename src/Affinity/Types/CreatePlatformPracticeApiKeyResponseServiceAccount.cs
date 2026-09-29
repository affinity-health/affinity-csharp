using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CreatePlatformPracticeApiKeyResponseServiceAccount : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("apiVersion")]
    public required CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion ApiVersion { get; set; }

    [JsonPropertyName("displayName")]
    public required string DisplayName { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("maxScopes")]
    public IEnumerable<CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem> MaxScopes { get; set; } =
        new List<CreatePlatformPracticeApiKeyResponseServiceAccountMaxScopesItem>();

    [JsonPropertyName("organizationId")]
    public required string OrganizationId { get; set; }

    [JsonPropertyName("status")]
    public required CreatePlatformPracticeApiKeyResponseServiceAccountStatus Status { get; set; }

    [JsonPropertyName("subjectId")]
    public required string SubjectId { get; set; }

    [JsonPropertyName("subjectType")]
    public required CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType SubjectType { get; set; }

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
