using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record RetrievePrescribingOptionsResponseCompoundingReason : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("required")]
    public required bool Required { get; set; }

    [JsonPropertyName("categoryRequired")]
    public required bool CategoryRequired { get; set; }

    [JsonPropertyName("context")]
    public required RetrievePrescribingOptionsResponseCompoundingReasonContext Context { get; set; }

    [JsonPropertyName("contextPrompt")]
    public string? ContextPrompt { get; set; }

    [JsonPropertyName("choices")]
    public IEnumerable<RetrievePrescribingOptionsResponseCompoundingReasonChoicesItem> Choices { get; set; } =
        new List<RetrievePrescribingOptionsResponseCompoundingReasonChoicesItem>();

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
