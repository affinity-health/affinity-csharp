using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record OrderInput
{
    /// <summary>
    /// A unique key per operation, 1 to 255 printable ASCII characters without spaces. Retry the same key and body to avoid repeating the action. The replay response depends on the operation. See https://docs.affinityrx.com/guides/#retry-safely.
    /// </summary>
    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// Your order identifier, unique within the practice and mode.
    /// </summary>
    [JsonPropertyName("externalOrderId")]
    public string? ExternalOrderId { get; set; }

    [JsonPropertyName("patient")]
    public required PatientInput Patient { get; set; }

    /// <summary>
    /// Required with a platform API key. Send a child practice ID. Independent practice keys can omit this field to use their own practice.
    /// </summary>
    [JsonPropertyName("practiceId")]
    public string? PracticeId { get; set; }

    [JsonPropertyName("prescriber")]
    public PrescriberInput? Prescriber { get; set; }

    /// <summary>
    /// The 1 to 20 prescriptions approved for this patient.
    /// </summary>
    [JsonPropertyName("prescriptions")]
    public IEnumerable<PrescriptionInput> Prescriptions { get; set; } =
        new List<PrescriptionInput>();

    /// <summary>
    /// The shipping option and destination.
    /// </summary>
    [JsonPropertyName("shipping")]
    public required OrderInputShipping Shipping { get; set; }

    /// <summary>
    /// Must be true to attest that the named prescriber approved and signed these prescriptions.
    /// </summary>
    [JsonPropertyName("signatureAttestation")]
    public required bool SignatureAttestation { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
