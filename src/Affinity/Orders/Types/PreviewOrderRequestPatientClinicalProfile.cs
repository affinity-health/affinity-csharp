using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity;

[Serializable]
public record PreviewOrderRequestPatientClinicalProfile : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("currentMedications")]
    public IEnumerable<string> CurrentMedications { get; set; } = new List<string>();

    [JsonPropertyName("heightInches")]
    public OneOf<
        double,
        PreviewOrderRequestPatientClinicalProfileHeightInchesOne
    >? HeightInches { get; set; }

    [JsonPropertyName("reviewedAt")]
    public string? ReviewedAt { get; set; }

    [JsonPropertyName("weightPounds")]
    public OneOf<
        double,
        PreviewOrderRequestPatientClinicalProfileWeightPoundsOne
    >? WeightPounds { get; set; }

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
