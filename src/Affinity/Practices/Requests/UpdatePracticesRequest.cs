using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record UpdatePracticesRequest
{
    /// <summary>
    /// The practice ID.
    /// </summary>
    [JsonIgnore]
    public required string PracticeId { get; set; }

    /// <summary>
    /// A unique key per operation, 1 to 255 printable ASCII characters without spaces. Retry the same key and body to avoid repeating the action. The replay response depends on the operation. See https://docs.affinityrx.com/guides/#retry-safely.
    /// </summary>
    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// Your practice identifier, unique among your platform's active practices. Send null to clear it.
    /// </summary>
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// Affinity merges the address parts you send into the saved address. An omitted part keeps its saved value. To move to an address with no suite, send `"line2": null` with the new `line1`, `city`, `state` and `postalCode`. PerfectRx prints it: use Windows-1252 characters, without &lt; or &gt;. Line 1 and line 2 together: 70 characters or fewer.
    /// </summary>
    [JsonPropertyName("address")]
    public UpdatePracticesRequestAddress? Address { get; set; }

    /// <summary>
    /// Omit it or send null to leave Live unchanged.
    /// </summary>
    [JsonPropertyName("liveEnabled")]
    public bool? LiveEnabled { get; set; }

    /// <summary>
    /// The practice name. PerfectRx prints it: use Windows-1252 characters, without &lt; or &gt;.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// A US phone number: 10 digits, with or without +1 or 1 before them. Spaces, dashes, dots and parentheses are allowed, such as (512) 555-0100. Affinity stores and returns +15125550100. Empty text counts as null.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
