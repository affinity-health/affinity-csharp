using Affinity;
using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Patients;

[Serializable]
public record ReplacePatientAllergiesRequestAllergiesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("category")]
    public required ReplacePatientAllergiesRequestAllergiesItemCategory Category { get; set; }

    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("codeSystem")]
    public ReplacePatientAllergiesRequestAllergiesItemCodeSystem? CodeSystem { get; set; }

    [JsonPropertyName("reactions")]
    public IEnumerable<ReplacePatientAllergiesRequestAllergiesItemReactionsItem> Reactions { get; set; } =
        new List<ReplacePatientAllergiesRequestAllergiesItemReactionsItem>();

    [JsonPropertyName("severity")]
    public ReplacePatientAllergiesRequestAllergiesItemSeverity? Severity { get; set; }

    [JsonPropertyName("source")]
    public required ReplacePatientAllergiesRequestAllergiesItemSource Source { get; set; }

    [JsonPropertyName("substance")]
    public required string Substance { get; set; }

    [JsonPropertyName("type")]
    public ReplacePatientAllergiesRequestAllergiesItemType? Type { get; set; }

    [JsonPropertyName("verificationStatus")]
    public required ReplacePatientAllergiesRequestAllergiesItemVerificationStatus VerificationStatus { get; set; }

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
