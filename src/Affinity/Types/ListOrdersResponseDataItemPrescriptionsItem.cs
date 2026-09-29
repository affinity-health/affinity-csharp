using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity;

[Serializable]
public record ListOrdersResponseDataItemPrescriptionsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("version")]
    public required int Version { get; set; }

    [JsonPropertyName("daysSupply")]
    public OneOf<
        double,
        ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne
    >? DaysSupply { get; set; }

    [JsonPropertyName("patientSnapshot")]
    public required ListOrdersResponseDataItemPrescriptionsItemPatientSnapshot PatientSnapshot { get; set; }

    /// <summary>
    /// The saved delivery address for this prescription version. Patient profile updates do not replace it. Review this address before signing.
    /// </summary>
    [JsonPropertyName("deliveryAddress")]
    public Dictionary<string, object?>? DeliveryAddress { get; set; }

    /// <summary>
    /// Whether the saved delivery address differs from the current primary patient address. This can be intentional; confirm the delivery address before signing.
    /// </summary>
    [JsonPropertyName("deliveryAddressDiffersFromPatient")]
    public required bool DeliveryAddressDiffersFromPatient { get; set; }

    [JsonPropertyName("providerSnapshot")]
    public ListOrdersResponseDataItemPrescriptionsItemProviderSnapshot? ProviderSnapshot { get; set; }

    [JsonPropertyName("clinical")]
    public ListOrdersResponseDataItemPrescriptionsItemClinical? Clinical { get; set; }

    [JsonPropertyName("dispensing")]
    public ListOrdersResponseDataItemPrescriptionsItemDispensing? Dispensing { get; set; }

    [JsonPropertyName("structuredSig")]
    public ListOrdersResponseDataItemPrescriptionsItemStructuredSig? StructuredSig { get; set; }

    [JsonPropertyName("externalPrescriptionId")]
    public string? ExternalPrescriptionId { get; set; }

    [JsonPropertyName("catalogItemId")]
    public string? CatalogItemId { get; set; }

    [JsonPropertyName("pharmacyId")]
    public string? PharmacyId { get; set; }

    [JsonPropertyName("pharmacyName")]
    public string? PharmacyName { get; set; }

    [JsonPropertyName("directions")]
    public required string Directions { get; set; }

    [JsonPropertyName("dosageForm")]
    public string? DosageForm { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("medicationName")]
    public required string MedicationName { get; set; }

    [JsonPropertyName("quantity")]
    public required OneOf<
        double,
        ListOrdersResponseDataItemPrescriptionsItemQuantityOne
    > Quantity { get; set; }

    [JsonPropertyName("quantityUnit")]
    public required string QuantityUnit { get; set; }

    [JsonPropertyName("refills")]
    public required int Refills { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("strength")]
    public string? Strength { get; set; }

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
