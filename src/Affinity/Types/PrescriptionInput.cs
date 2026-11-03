using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record PrescriptionInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The reason for compounding, required when the medication's requirements include it. Empty text counts as null.
    /// </summary>
    [JsonPropertyName("compoundingReason")]
    public string? CompoundingReason { get; set; }

    /// <summary>
    /// The prescriber's directions for use.
    /// </summary>
    [JsonPropertyName("directions")]
    public required string Directions { get; set; }

    /// <summary>
    /// The medication's public identifier from the current catalog.
    /// </summary>
    [JsonPropertyName("medicationId")]
    public required string MedicationId { get; set; }

    /// <summary>
    /// The prescriber's additional notes to the pharmacy. Empty text counts as null.
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    /// <summary>
    /// The prescribed quantity in quantityUnit, not a count of fills. With a fill, send a whole number of fills in units: two fills of 30 tablets is 60. A vial's unit is vial, so 2 is two vials.
    /// </summary>
    [JsonPropertyName("quantity")]
    public required int Quantity { get; set; }

    /// <summary>
    /// The number of authorized refills in addition to the first fill.
    /// </summary>
    [JsonPropertyName("refills")]
    public required int Refills { get; set; }

    /// <summary>
    /// Whether the prescriber permits substitution; defaults to true when omitted.
    /// </summary>
    [JsonPropertyName("substitutionPermitted")]
    public bool? SubstitutionPermitted { get; set; }

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
