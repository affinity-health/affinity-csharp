using Affinity.Core;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity;

[Serializable]
public record ListCatalogItemsRequest
{
    [JsonIgnore]
    public ListCatalogItemsRequestView? View { get; set; }

    [JsonIgnore]
    public string? RelatedToCatalogItemId { get; set; }

    [JsonIgnore]
    public ListCatalogItemsRequestCatalogKind? CatalogKind { get; set; }

    [JsonIgnore]
    public ListCatalogItemsRequestSort? Sort { get; set; }

    [JsonIgnore]
    public string? CatalogItemId { get; set; }

    [JsonIgnore]
    public ListCatalogItemsRequestAvailability? Availability { get; set; }

    [JsonIgnore]
    public OneOf<string, IEnumerable<string>>? PharmacyIds { get; set; }

    [JsonIgnore]
    public OneOf<
        ListCatalogItemsRequestDosageFormsZero,
        IEnumerable<ListCatalogItemsRequestDosageFormsOneItem>
    >? DosageForms { get; set; }

    [JsonIgnore]
    public string? EndingBefore { get; set; }

    [JsonIgnore]
    public bool? HideControlledSubstances { get; set; }

    [JsonIgnore]
    public bool? HideUnpriced { get; set; }

    [JsonIgnore]
    public int? Limit { get; set; }

    [JsonIgnore]
    public string? OrgId { get; set; }

    [JsonIgnore]
    public string? PracticeId { get; set; }

    [JsonIgnore]
    public string? Query { get; set; }

    [JsonIgnore]
    public ListCatalogItemsRequestRequirement? Requirement { get; set; }

    [JsonIgnore]
    public OneOf<
        ListCatalogItemsRequestRoutesZero,
        IEnumerable<ListCatalogItemsRequestRoutesOneItem>
    >? Routes { get; set; }

    [JsonIgnore]
    public string? StartingAfter { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
