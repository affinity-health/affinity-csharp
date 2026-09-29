using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListOrdersResponseDataItemPrescriptionsItemDispensing : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("dispenseUponAcceptance")]
    public required bool DispenseUponAcceptance { get; set; }

    [JsonPropertyName("substitutionPermitted")]
    public required bool SubstitutionPermitted { get; set; }

    [JsonPropertyName("pharmacyNotes")]
    public string? PharmacyNotes { get; set; }

    [JsonPropertyName("requestedFillDate")]
    public string? RequestedFillDate { get; set; }

    [JsonPropertyName("shippingOptionId")]
    public string? ShippingOptionId { get; set; }

    [JsonPropertyName("shippingAmountCents")]
    public int? ShippingAmountCents { get; set; }

    [JsonPropertyName("shippingDestinationType")]
    public ListOrdersResponseDataItemPrescriptionsItemDispensingShippingDestinationType? ShippingDestinationType { get; set; }

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
