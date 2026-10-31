using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListOrdersRequest
{
    /// <summary>
    /// Maximum records per page, from 1 to 100. Defaults to 25.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Page forward using the previous response's nextCursor. Keep the same filters, sort, organization and mode. Use only one cursor parameter.
    /// </summary>
    [JsonIgnore]
    public string? StartingAfter { get; set; }

    /// <summary>
    /// Match the external order ID exactly, including case. Combine with practiceId when your platform reuses IDs across practices.
    /// </summary>
    [JsonIgnore]
    public string? ExternalOrderId { get; set; }

    /// <summary>
    /// Return orders whose updatedAt is strictly later than this ISO 8601 timestamp. Sorting stays by creation time and ID unless sort is supplied. Keep this cutoff unchanged while paging.
    /// </summary>
    [JsonIgnore]
    public DateTime? UpdatedAfter { get; set; }

    /// <summary>
    /// Limit results to the patient with this pat_ ID.
    /// </summary>
    [JsonIgnore]
    public string? PatientId { get; set; }

    /// <summary>
    /// Limit results to the practice with this prac_ ID, within your authorized practices.
    /// </summary>
    [JsonIgnore]
    public string? PracticeId { get; set; }

    /// <summary>
    /// Search saved order snapshots: patient names, email, phone and external ID; order external ID; prescriber name and NPI; medication names and brands; pharmacy name. Whole ord_ and pat_ IDs and six-character order numbers also match. Text matches ignore case and allow substrings, word prefixes and similar spellings for alphanumeric words of four or more characters. Every one of the first eight words containing letters or numbers must match; punctuation-only words are ignored. An empty or punctuation-only query leaves the list unfiltered. Date of birth, separate strength fields, practice names, prac_ IDs and rx_ IDs are not searched. Restart pagination when filters change.
    /// </summary>
    [JsonIgnore]
    public string? Query { get; set; }

    /// <summary>
    /// Return only orders with this status. Omit to include all statuses.
    /// </summary>
    [JsonIgnore]
    public ListOrdersRequestStatus? Status { get; set; }

    /// <summary>
    /// true returns only submitted or processing orders with a cancel the pharmacy has not confirmed yet (cancelRequestedAt set). false leaves those orders out. Omit to include both.
    /// </summary>
    [JsonIgnore]
    public ListOrdersRequestCancelRequested? CancelRequested { get; set; }

    /// <summary>
    /// true returns only orders whose status is shipped and that shipped in the last 60 days; delivered orders are excluded. false leaves those orders out. Omit to include both.
    /// </summary>
    [JsonIgnore]
    public ListOrdersRequestRecentlyShipped? RecentlyShipped { get; set; }

    /// <summary>
    /// patient sorts the lowercase text firstName + space + lastName A to Z, then order ID; created sorts oldest first. A leading - reverses the order. Defaults to -created. Restart pagination after changing sort.
    /// </summary>
    [JsonIgnore]
    public ListOrdersRequestSort? Sort { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
