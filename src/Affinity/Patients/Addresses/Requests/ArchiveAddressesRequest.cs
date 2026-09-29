using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity.Patients;

[Serializable]
public record ArchiveAddressesRequest
{
    [JsonIgnore]
    public required string PracticeId { get; set; }

    [JsonIgnore]
    public required string PatientId { get; set; }

    [JsonIgnore]
    public required string AddressId { get; set; }

    /// <summary>
    /// Optional in the SDK. A fresh key is generated once per call when omitted. Supply a stable key to retry across calls.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
