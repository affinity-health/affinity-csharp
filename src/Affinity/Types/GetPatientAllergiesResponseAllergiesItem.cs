using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record GetPatientAllergiesResponseAllergiesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("category")]
    public required GetPatientAllergiesResponseAllergiesItemCategory Category { get; set; }

    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("codeSystem")]
    public GetPatientAllergiesResponseAllergiesItemCodeSystem? CodeSystem { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("reactions")]
    public IEnumerable<GetPatientAllergiesResponseAllergiesItemReactionsItem> Reactions { get; set; } =
        new List<GetPatientAllergiesResponseAllergiesItemReactionsItem>();

    [JsonPropertyName("severity")]
    public GetPatientAllergiesResponseAllergiesItemSeverity? Severity { get; set; }

    [JsonPropertyName("source")]
    public required GetPatientAllergiesResponseAllergiesItemSource Source { get; set; }

    [JsonPropertyName("substance")]
    public required string Substance { get; set; }

    [JsonPropertyName("type")]
    public GetPatientAllergiesResponseAllergiesItemType? Type { get; set; }

    [JsonPropertyName("verificationStatus")]
    public required GetPatientAllergiesResponseAllergiesItemVerificationStatus VerificationStatus { get; set; }

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
