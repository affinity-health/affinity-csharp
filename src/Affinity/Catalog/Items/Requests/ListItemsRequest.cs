using Affinity.Core;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity.Catalog;

[Serializable]
public record ListItemsRequest
{
    [JsonIgnore]
    public ListItemsRequestView? View { get; set; }

    [JsonIgnore]
    public string? RelatedToCatalogItemId { get; set; }

    [JsonIgnore]
    public ListItemsRequestCatalogKind? CatalogKind { get; set; }

    [JsonIgnore]
    public ListItemsRequestSort? Sort { get; set; }

    [JsonIgnore]
    public string? CatalogItemId { get; set; }

    [JsonIgnore]
    public ListItemsRequestAvailability? Availability { get; set; }

    [JsonIgnore]
    public OneOf<string, IEnumerable<string>>? PharmacyIds { get; set; }

    [JsonIgnore]
    public OneOf<
        ListItemsRequestDosageFormsZero,
        IEnumerable<ListItemsRequestDosageFormsOneItem>
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
    public ListItemsRequestRequirement? Requirement { get; set; }

    [JsonIgnore]
    public OneOf<
        ListItemsRequestRoutesZero,
        IEnumerable<ListItemsRequestRoutesOneItem>
    >? Routes { get; set; }

    [JsonIgnore]
    public string? StartingAfter { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
