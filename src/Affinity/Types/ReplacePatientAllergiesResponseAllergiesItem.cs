using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ReplacePatientAllergiesResponseAllergiesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("category")]
    public required ReplacePatientAllergiesResponseAllergiesItemCategory Category { get; set; }

    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("codeSystem")]
    public ReplacePatientAllergiesResponseAllergiesItemCodeSystem? CodeSystem { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("reactions")]
    public IEnumerable<ReplacePatientAllergiesResponseAllergiesItemReactionsItem> Reactions { get; set; } =
        new List<ReplacePatientAllergiesResponseAllergiesItemReactionsItem>();

    [JsonPropertyName("severity")]
    public ReplacePatientAllergiesResponseAllergiesItemSeverity? Severity { get; set; }

    [JsonPropertyName("source")]
    public required ReplacePatientAllergiesResponseAllergiesItemSource Source { get; set; }

    [JsonPropertyName("substance")]
    public required string Substance { get; set; }

    [JsonPropertyName("type")]
    public ReplacePatientAllergiesResponseAllergiesItemType? Type { get; set; }

    [JsonPropertyName("verificationStatus")]
    public required ReplacePatientAllergiesResponseAllergiesItemVerificationStatus VerificationStatus { get; set; }

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
