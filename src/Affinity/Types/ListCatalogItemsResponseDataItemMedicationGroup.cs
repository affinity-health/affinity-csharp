using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity;

[Serializable]
public record ListCatalogItemsResponseDataItemMedicationGroup : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("offerCount")]
    public required OneOf<
        double,
        ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne
    > OfferCount { get; set; }

    [JsonPropertyName("pharmacyCount")]
    public required OneOf<
        double,
        ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne
    > PharmacyCount { get; set; }

    [JsonPropertyName("strengths")]
    public IEnumerable<string> Strengths { get; set; } = new List<string>();

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
