using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ReplacePatientAllergiesResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("allergies")]
    public IEnumerable<ReplacePatientAllergiesResponseAllergiesItem> Allergies { get; set; } =
        new List<ReplacePatientAllergiesResponseAllergiesItem>();

    [JsonPropertyName("reviewStatus")]
    public required ReplacePatientAllergiesResponseReviewStatus ReviewStatus { get; set; }

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
