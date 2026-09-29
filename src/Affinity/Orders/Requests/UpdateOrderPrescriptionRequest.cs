using Affinity.Core;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity;

[Serializable]
public record UpdateOrderPrescriptionRequest
{
    [JsonIgnore]
    public required string OrderId { get; set; }

    [JsonIgnore]
    public required string PrescriptionId { get; set; }

    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// Required for user actors and optional for system actors. Omit both actor headers to use the authenticated service account as a system actor.
    /// </summary>
    [JsonIgnore]
    public string? AffinityActorId { get; set; }

    /// <summary>
    /// Use user when a person initiated the action and system for autonomous work. Omit both actor headers to default to system.
    /// </summary>
    [JsonIgnore]
    public string? AffinityActorType { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, OneOf<string, double, bool>?>? Metadata { get; set; }

    [JsonPropertyName("practiceId")]
    public required string PracticeId { get; set; }

    /// <summary>
    /// Opaque revision of the complete order prescription set. Send the revision you reviewed as expectedRevision; never replace it automatically after a conflict.
    /// </summary>
    [JsonPropertyName("expectedRevision")]
    public string? ExpectedRevision { get; set; }

    [JsonPropertyName("expectedVersions")]
    public IEnumerable<UpdateOrderPrescriptionRequestExpectedVersionsItem>? ExpectedVersions { get; set; }

    [JsonPropertyName("prescription")]
    public required UpdateOrderPrescriptionRequestPrescription Prescription { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
