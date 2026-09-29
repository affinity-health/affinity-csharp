using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record RegisterUserRequestProfileDetails : IJsonOnDeserialized
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
    public IEnumerable<RegisterUserRequestProfileDetailsSpecialtiesItem>? Specialties { get; set; }

    [JsonPropertyName("addresses")]
    public IEnumerable<RegisterUserRequestProfileDetailsAddressesItem>? Addresses { get; set; }

    [JsonPropertyName("otherNames")]
    public IEnumerable<RegisterUserRequestProfileDetailsOtherNamesItem>? OtherNames { get; set; }

    [JsonPropertyName("identifiers")]
    public IEnumerable<RegisterUserRequestProfileDetailsIdentifiersItem>? Identifiers { get; set; }

    [JsonPropertyName("endpoints")]
    public IEnumerable<RegisterUserRequestProfileDetailsEndpointsItem>? Endpoints { get; set; }

    [JsonPropertyName("certifications")]
    public IEnumerable<RegisterUserRequestProfileDetailsCertificationsItem>? Certifications { get; set; }

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
