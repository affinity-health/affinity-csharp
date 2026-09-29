using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record PreviewOrderRequestPrescriptionsItemOverrides : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("sig")]
    public PreviewOrderRequestPrescriptionsItemOverridesSig? Sig { get; set; }

    [JsonPropertyName("quantity")]
    public PreviewOrderRequestPrescriptionsItemOverridesQuantity? Quantity { get; set; }

    [JsonPropertyName("daysSupply")]
    public int? DaysSupply { get; set; }

    [JsonPropertyName("refills")]
    public int? Refills { get; set; }

    [JsonPropertyName("clinical")]
    public PreviewOrderRequestPrescriptionsItemOverridesClinical? Clinical { get; set; }

    [JsonPropertyName("dispensing")]
    public PreviewOrderRequestPrescriptionsItemOverridesDispensing? Dispensing { get; set; }

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
