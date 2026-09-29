using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record PreviewOrderResponseShippingGroupsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("key")]
    public required string Key { get; set; }

    [JsonPropertyName("pharmacy")]
    public required string Pharmacy { get; set; }

    [JsonPropertyName("label")]
    public required string Label { get; set; }

    [JsonPropertyName("temperature")]
    public required PreviewOrderResponseShippingGroupsItemTemperature Temperature { get; set; }

    [JsonPropertyName("amountCents")]
    public required int AmountCents { get; set; }

    [JsonPropertyName("itemCount")]
    public required int ItemCount { get; set; }

    /// <summary>
    /// Zero-based indexes into the preview prescriptions array. This is an estimated shipping charge group, not a guarantee of one physical package.
    /// </summary>
    [JsonPropertyName("prescriptionIndexes")]
    public IEnumerable<int> PrescriptionIndexes { get; set; } = new List<int>();

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
