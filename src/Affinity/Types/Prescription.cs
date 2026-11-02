using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record Prescription : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The reason for compounding, required when the medication's requirements include it.
    /// </summary>
    [JsonPropertyName("compoundingReason")]
    public string? CompoundingReason { get; set; }

    /// <summary>
    /// The prescriber's directions for use.
    /// </summary>
    [JsonPropertyName("directions")]
    public required string Directions { get; set; }

    /// <summary>
    /// The public record identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("pharmacy")]
    public required PharmacyReference Pharmacy { get; set; }

    /// <summary>
    /// The current fulfillment status.
    /// </summary>
    [JsonPropertyName("status")]
    public required PrescriptionStatus Status { get; set; }

    /// <summary>
    /// The failure or cancellation refusal reason, or null when there is none.
    /// </summary>
    [JsonPropertyName("failureReason")]
    public string? FailureReason { get; set; }

    /// <summary>
    /// The medication details saved when the order was signed.
    /// </summary>
    [JsonPropertyName("medication")]
    public required PrescriptionMedication Medication { get; set; }

    /// <summary>
    /// The prescriber's additional notes to the pharmacy.
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    /// <summary>
    /// The price in integer cents.
    /// </summary>
    [JsonPropertyName("price")]
    public required int Price { get; set; }

    /// <summary>
    /// The prescribed quantity in quantityUnit, not a count of fills. With a fill, it is a whole number of fills in units: two fills of 30 tablets is 60. A vial's unit is vial, so 2 is two vials.
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
    public required bool SubstitutionPermitted { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
