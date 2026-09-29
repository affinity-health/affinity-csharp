using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensing : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("dispenseUponAcceptance")]
    public bool? DispenseUponAcceptance { get; set; }

    [JsonPropertyName("shippingOptionId")]
    public string? ShippingOptionId { get; set; }

    /// <summary>
    /// Reviewed customer shipping rate for the selected service. Preview supplies this value. Shared group rates must not be summed per prescription.
    /// </summary>
    [JsonPropertyName("shippingAmountCents")]
    public int? ShippingAmountCents { get; set; }

    [JsonPropertyName("shippingDestinationType")]
    public CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType? ShippingDestinationType { get; set; }

    [JsonPropertyName("pharmacyNotes")]
    public string? PharmacyNotes { get; set; }

    [JsonPropertyName("requestedFillDate")]
    public string? RequestedFillDate { get; set; }

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
