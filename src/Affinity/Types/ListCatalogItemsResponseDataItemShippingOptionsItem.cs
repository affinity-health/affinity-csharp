using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListCatalogItemsResponseDataItemShippingOptionsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("amountCents")]
    public required int AmountCents { get; set; }

    [JsonPropertyName("carrier")]
    public string? Carrier { get; set; }

    [JsonPropertyName("currency")]
    public required ListCatalogItemsResponseDataItemShippingOptionsItemCurrency Currency { get; set; }

    [JsonPropertyName("destinationTypes")]
    public IEnumerable<ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem> DestinationTypes { get; set; } =
        new List<ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem>();

    [JsonPropertyName("estimatedDaysMax")]
    public int? EstimatedDaysMax { get; set; }

    [JsonPropertyName("estimatedDaysMin")]
    public int? EstimatedDaysMin { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("label")]
    public required string Label { get; set; }

    [JsonPropertyName("serviceLevel")]
    public required string ServiceLevel { get; set; }

    [JsonPropertyName("temperatures")]
    public IEnumerable<ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem> Temperatures { get; set; } =
        new List<ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem>();

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
