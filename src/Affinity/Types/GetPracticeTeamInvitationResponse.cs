using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record GetPracticeTeamInvitationResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("object")]
    public required GetPracticeTeamInvitationResponseObject Object { get; set; }

    [JsonPropertyName("email")]
    public required string Email { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("status")]
    public required GetPracticeTeamInvitationResponseStatus Status { get; set; }

    [JsonPropertyName("roles")]
    public IEnumerable<GetPracticeTeamInvitationResponseRolesItem> Roles { get; set; } =
        new List<GetPracticeTeamInvitationResponseRolesItem>();

    [JsonPropertyName("locationIds")]
    public IEnumerable<string> LocationIds { get; set; } = new List<string>();

    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("expiresAt")]
    public required string ExpiresAt { get; set; }

    [JsonPropertyName("acceptedAt")]
    public string? AcceptedAt { get; set; }

    /// <summary>
    /// This integration's mode-scoped user ID, used for draft attribution and sessions after acceptance. Null for invitations outside this integration.
    /// </summary>
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("memberId")]
    public string? MemberId { get; set; }

    [JsonPropertyName("prescriberId")]
    public string? PrescriberId { get; set; }

    /// <summary>
    /// This integration's current onboarding and account-connection state. Null for invitations outside this integration.
    /// </summary>
    [JsonPropertyName("person")]
    public GetPracticeTeamInvitationResponsePerson? Person { get; set; }

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
