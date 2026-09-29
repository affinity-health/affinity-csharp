using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity;

[Serializable]
public record CreatePatientRequestMeasurementsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("heightCentimeters")]
    public OneOf<
        double,
        CreatePatientRequestMeasurementsItemHeightCentimetersOne
    >? HeightCentimeters { get; set; }

    [JsonPropertyName("recordedAt")]
    public required string RecordedAt { get; set; }

    [JsonPropertyName("source")]
    public required string Source { get; set; }

    [JsonPropertyName("weightKilograms")]
    public OneOf<
        double,
        CreatePatientRequestMeasurementsItemWeightKilogramsOne
    >? WeightKilograms { get; set; }

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
