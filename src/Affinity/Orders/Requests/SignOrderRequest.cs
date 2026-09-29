using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record SignOrderRequest
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
    public SignOrderRequestPrescriber? Prescriber { get; set; }

    [JsonPropertyName("signatureAttestation")]
    public required bool SignatureAttestation { get; set; }

    /// <summary>
    /// Opaque revision of the complete order prescription set. Send the revision you reviewed as expectedRevision; never replace it automatically after a conflict.
    /// </summary>
    [JsonPropertyName("expectedRevision")]
    public string? ExpectedRevision { get; set; }

    [JsonPropertyName("expectedVersions")]
    public IEnumerable<SignOrderRequestExpectedVersionsItem>? ExpectedVersions { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
