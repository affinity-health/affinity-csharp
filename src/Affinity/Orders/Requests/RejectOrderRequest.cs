using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record RejectOrderRequest
{
    [JsonIgnore]
    public required string OrderId { get; set; }

    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

    [JsonPropertyName("practiceId")]
    public required string PracticeId { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("prescriber")]
    public RejectOrderRequestPrescriber? Prescriber { get; set; }

    [JsonPropertyName("reason")]
    public required string Reason { get; set; }

    /// <summary>
    /// Opaque revision of the complete order prescription set. Send the revision you reviewed as expectedRevision; never replace it automatically after a conflict.
    /// </summary>
    [JsonPropertyName("expectedRevision")]
    public string? ExpectedRevision { get; set; }

    [JsonPropertyName("expectedVersions")]
    public IEnumerable<RejectOrderRequestExpectedVersionsItem>? ExpectedVersions { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
