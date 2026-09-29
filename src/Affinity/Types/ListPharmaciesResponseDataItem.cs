using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListPharmaciesResponseDataItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("access")]
    public required ListPharmaciesResponseDataItemAccess Access { get; set; }

    [JsonPropertyName("catalogItemCount")]
    public required int CatalogItemCount { get; set; }

    [JsonPropertyName("facilityType")]
    public required string FacilityType { get; set; }

    [JsonPropertyName("facilityLocations")]
    public IEnumerable<ListPharmaciesResponseDataItemFacilityLocationsItem> FacilityLocations { get; set; } =
        new List<ListPharmaciesResponseDataItemFacilityLocationsItem>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("livemode")]
    public required bool Livemode { get; set; }

    [JsonPropertyName("logoUrl")]
    public string? LogoUrl { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("object")]
    public required ListPharmaciesResponseDataItemObject Object { get; set; }

    [JsonPropertyName("prescriptionsLast30Days")]
    public required int PrescriptionsLast30Days { get; set; }

    [JsonPropertyName("profile")]
    public ListPharmaciesResponseDataItemProfile? Profile { get; set; }

    [JsonPropertyName("restrictedStates")]
    public IEnumerable<string> RestrictedStates { get; set; } = new List<string>();

    [JsonPropertyName("shippingOptions")]
    public IEnumerable<ListPharmaciesResponseDataItemShippingOptionsItem> ShippingOptions { get; set; } =
        new List<ListPharmaciesResponseDataItemShippingOptionsItem>();

    [JsonPropertyName("supportedStates")]
    public IEnumerable<string> SupportedStates { get; set; } = new List<string>();

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
