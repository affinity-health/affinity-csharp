using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record PreviewOrderResponsePrescriptionsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("medicationId")]
    public required string MedicationId { get; set; }

    [JsonPropertyName("revision")]
    public required string Revision { get; set; }

    [JsonPropertyName("directions")]
    public required string Directions { get; set; }

    [JsonPropertyName("structuredSig")]
    public PreviewOrderResponsePrescriptionsItemStructuredSig? StructuredSig { get; set; }

    [JsonPropertyName("format")]
    public required PreviewOrderResponsePrescriptionsItemFormat Format { get; set; }

    [JsonPropertyName("quantity")]
    public PreviewOrderResponsePrescriptionsItemQuantity? Quantity { get; set; }

    [JsonPropertyName("daysSupply")]
    public int? DaysSupply { get; set; }

    [JsonPropertyName("daysSupplySource")]
    public required PreviewOrderResponsePrescriptionsItemDaysSupplySource DaysSupplySource { get; set; }

    [JsonPropertyName("refills")]
    public required int Refills { get; set; }

    [JsonPropertyName("shippingOptions")]
    public IEnumerable<PreviewOrderResponsePrescriptionsItemShippingOptionsItem> ShippingOptions { get; set; } =
        new List<PreviewOrderResponsePrescriptionsItemShippingOptionsItem>();

    [JsonPropertyName("shippingOptionId")]
    public string? ShippingOptionId { get; set; }

    [JsonPropertyName("medicationSubtotalCents")]
    public int? MedicationSubtotalCents { get; set; }

    [JsonPropertyName("shippingAmountCents")]
    public int? ShippingAmountCents { get; set; }

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
