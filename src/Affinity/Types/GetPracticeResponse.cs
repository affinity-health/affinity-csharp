using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record GetPracticeResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("address")]
    public GetPracticeResponseAddress? Address { get; set; }

    [JsonPropertyName("contacts")]
    public required GetPracticeResponseContacts Contacts { get; set; }

    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("legalName")]
    public string? LegalName { get; set; }

    [JsonPropertyName("livemode")]
    public required bool Livemode { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, object?> Metadata { get; set; } = new Dictionary<string, object?>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("object")]
    public required GetPracticeResponseObject Object { get; set; }

    [JsonPropertyName("prescribers")]
    public IEnumerable<GetPracticeResponsePrescribersItem> Prescribers { get; set; } =
        new List<GetPracticeResponsePrescribersItem>();

    /// <summary>
    /// Whether this practice currently has Live access. False for Test practices.
    /// </summary>
    [JsonPropertyName("liveEnabled")]
    public required bool LiveEnabled { get; set; }

    [JsonPropertyName("supportEmail")]
    public string? SupportEmail { get; set; }

    [JsonPropertyName("supportPhone")]
    public string? SupportPhone { get; set; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

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
