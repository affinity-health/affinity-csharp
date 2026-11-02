using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record Medication : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// What the medication is prescribed for. Every strength, form and pharmacy of one medication has the same category.
    /// </summary>
    [JsonPropertyName("category")]
    public required MedicationCategory Category { get; set; }

    /// <summary>
    /// Whether the medication requires refrigerated shipping.
    /// </summary>
    [JsonPropertyName("coldChainRequired")]
    public required bool ColdChainRequired { get; set; }

    /// <summary>
    /// The accepted compounding reasons when the pharmacy limits them.
    /// </summary>
    [JsonPropertyName("compoundingReasons")]
    public IEnumerable<string> CompoundingReasons { get; set; } = new List<string>();

    /// <summary>
    /// The catalog's default directions, or null when none are supplied.
    /// </summary>
    [JsonPropertyName("defaultDirections")]
    public string? DefaultDirections { get; set; }

    /// <summary>
    /// What the pharmacy dispenses for one price, or null when the complete fill is unknown.
    /// </summary>
    [JsonPropertyName("fill")]
    public Fill? Fill { get; set; }

    /// <summary>
    /// The dosage form, or null when it is unknown.
    /// </summary>
    [JsonPropertyName("form")]
    public string? Form { get; set; }

    /// <summary>
    /// The name with each ingredient's salt where the catalog records one, such as Enclomiphene Citrate. Equals name otherwise.
    /// </summary>
    [JsonPropertyName("fullName")]
    public required string FullName { get; set; }

    /// <summary>
    /// The public record identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("pharmacy")]
    public required PharmacyReference Pharmacy { get; set; }

    /// <summary>
    /// The price in integer cents.
    /// </summary>
    [JsonPropertyName("price")]
    public required int Price { get; set; }

    /// <summary>
    /// The accepted quantities, counted in quantityUnit; an empty list permits any quantity within the request limits.
    /// </summary>
    [JsonPropertyName("quantities")]
    public IEnumerable<int> Quantities { get; set; } = new List<int>();

    /// <summary>
    /// The unit used to count the prescribed quantity, or null when it is unknown.
    /// </summary>
    [JsonPropertyName("quantityUnit")]
    public string? QuantityUnit { get; set; }

    /// <summary>
    /// The optional prescription field paths that this medication requires.
    /// </summary>
    [JsonPropertyName("requirements")]
    public IEnumerable<string> Requirements { get; set; } = new List<string>();

    /// <summary>
    /// The states where this medication cannot ship; other states are permitted subject to pharmacy coverage.
    /// </summary>
    [JsonPropertyName("restrictedStates")]
    public IEnumerable<string> RestrictedStates { get; set; } = new List<string>();

    /// <summary>
    /// The shipping options available for this medication.
    /// </summary>
    [JsonPropertyName("shippingOptions")]
    public IEnumerable<ShippingOption> ShippingOptions { get; set; } = new List<ShippingOption>();

    /// <summary>
    /// Each shipping option price includes shippingSuppliesPrice. A mixed order pays the highest supplies price once. Example: $25.00 cold chain + $2.06 supplies = $27.06.
    /// </summary>
    [JsonPropertyName("shippingSuppliesPrice")]
    public required int ShippingSuppliesPrice { get; set; }

    /// <summary>
    /// The pharmacy's strength text, or null when it is unknown.
    /// </summary>
    [JsonPropertyName("strength")]
    public string? Strength { get; set; }

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
