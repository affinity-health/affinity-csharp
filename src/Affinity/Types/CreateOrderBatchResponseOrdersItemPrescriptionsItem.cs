using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity;

[Serializable]
public record CreateOrderBatchResponseOrdersItemPrescriptionsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("pharmacyId")]
    public required string PharmacyId { get; set; }

    [JsonPropertyName("externalPrescriptionId")]
    public string? ExternalPrescriptionId { get; set; }

    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("directions")]
    public required string Directions { get; set; }

    [JsonPropertyName("version")]
    public required int Version { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("medicationId")]
    public string? MedicationId { get; set; }

    [JsonPropertyName("medicationName")]
    public required string MedicationName { get; set; }

    [JsonPropertyName("object")]
    public required CreateOrderBatchResponseOrdersItemPrescriptionsItemObject Object { get; set; }

    [JsonPropertyName("quantity")]
    public required OneOf<
        double,
        CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne
    > Quantity { get; set; }

    [JsonPropertyName("quantityUnit")]
    public required string QuantityUnit { get; set; }

    [JsonPropertyName("refills")]
    public required int Refills { get; set; }

    [JsonPropertyName("status")]
    public required CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus Status { get; set; }

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
