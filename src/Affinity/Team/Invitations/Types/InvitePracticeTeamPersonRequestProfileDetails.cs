using Affinity;
using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Team;

[Serializable]
public record InvitePracticeTeamPersonRequestProfileDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("middleName")]
    public string? MiddleName { get; set; }

    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("namePrefix")]
    public string? NamePrefix { get; set; }

    [JsonPropertyName("nameSuffix")]
    public string? NameSuffix { get; set; }

    [JsonPropertyName("fax")]
    public string? Fax { get; set; }

    [JsonPropertyName("specialties")]
    public IEnumerable<InvitePracticeTeamPersonRequestProfileDetailsSpecialtiesItem>? Specialties { get; set; }

    [JsonPropertyName("addresses")]
    public IEnumerable<InvitePracticeTeamPersonRequestProfileDetailsAddressesItem>? Addresses { get; set; }

    [JsonPropertyName("otherNames")]
    public IEnumerable<InvitePracticeTeamPersonRequestProfileDetailsOtherNamesItem>? OtherNames { get; set; }

    [JsonPropertyName("identifiers")]
    public IEnumerable<InvitePracticeTeamPersonRequestProfileDetailsIdentifiersItem>? Identifiers { get; set; }

    [JsonPropertyName("endpoints")]
    public IEnumerable<InvitePracticeTeamPersonRequestProfileDetailsEndpointsItem>? Endpoints { get; set; }

    [JsonPropertyName("certifications")]
    public IEnumerable<InvitePracticeTeamPersonRequestProfileDetailsCertificationsItem>? Certifications { get; set; }

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
