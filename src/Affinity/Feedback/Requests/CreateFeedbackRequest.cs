using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CreateFeedbackRequest
{
    /// <summary>
    /// A unique key per operation, 1 to 255 printable ASCII characters without spaces. Retry the same key and body to avoid repeating the action. The replay response depends on the operation. See https://docs.affinityrx.com/guides/#retry-safely.
    /// </summary>
    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// Text with at least one visible character.
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; set; }

    [JsonPropertyName("pageUrl")]
    public string? PageUrl { get; set; }

    /// <summary>
    /// The `requestId` of the response, as the API returned it: a UUID or its `req_` form.
    /// </summary>
    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
