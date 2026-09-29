using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record InvitePracticeTeamPersonRequest
{
    [JsonIgnore]
    public required string PracticeId { get; set; }

    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

    [JsonPropertyName("externalId")]
    public required string ExternalId { get; set; }

    [JsonPropertyName("email")]
    public required string Email { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("role")]
    public InvitePracticeTeamPersonRequestRole? Role { get; set; }

    [JsonPropertyName("roles")]
    public IEnumerable<InvitePracticeTeamPersonRequestRolesItem>? Roles { get; set; }

    [JsonPropertyName("profileDetails")]
    public InvitePracticeTeamPersonRequestProfileDetails? ProfileDetails { get; set; }

    [JsonPropertyName("npi")]
    public string? Npi { get; set; }

    [JsonPropertyName("licenses")]
    public IEnumerable<InvitePracticeTeamPersonRequestLicensesItem>? Licenses { get; set; }

    [JsonPropertyName("legalName")]
    public string? LegalName { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("credentials")]
    public string? Credentials { get; set; }

    [JsonPropertyName("address")]
    public InvitePracticeTeamPersonRequestAddress? Address { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("locationIds")]
    public IEnumerable<string>? LocationIds { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
