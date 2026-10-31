using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record Fill : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// How much one fill holds, in `unit`.
    /// </summary>
    [JsonPropertyName("amount")]
    public required int Amount { get; set; }

    /// <summary>
    /// What holds one fill, such as `vial`. Null when the pharmacy does not say.
    /// </summary>
    [JsonPropertyName("container")]
    public string? Container { get; set; }

    /// <summary>
    /// Each active ingredient's total in one fill: a 2 mL vial of 30 mg/mL is 60 mg.
    /// </summary>
    [JsonPropertyName("ingredients")]
    public IEnumerable<FillIngredientsItem> Ingredients { get; set; } =
        new List<FillIngredientsItem>();

    /// <summary>
    /// The unit of `amount`, the same as `quantityUnit`: `vial` for a vial product.
    /// </summary>
    [JsonPropertyName("unit")]
    public required string Unit { get; set; }

    /// <summary>
    /// What one vial holds, such as 2 mL. Null for a product that is not a vial.
    /// </summary>
    [JsonPropertyName("volume")]
    public FillVolume? Volume { get; set; }

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
