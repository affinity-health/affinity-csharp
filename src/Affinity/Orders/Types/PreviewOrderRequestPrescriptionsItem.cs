using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record PreviewOrderRequestPrescriptionsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("medicationId")]
    public required string MedicationId { get; set; }

    [JsonPropertyName("externalPrescriptionId")]
    public string? ExternalPrescriptionId { get; set; }

    [JsonPropertyName("preset")]
    public string? Preset { get; set; }

    [JsonPropertyName("expectedRevision")]
    public string? ExpectedRevision { get; set; }

    [JsonPropertyName("overrides")]
    public PreviewOrderRequestPrescriptionsItemOverrides? Overrides { get; set; }

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
