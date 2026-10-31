using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record GetMedicationsRequest
{
    [JsonIgnore]
    public required string MedicationId { get; set; }

    /// <summary>
    /// Quote prices and availability for this practice. A platform may select only its own child practices; a practice may select only itself. Omit to use the caller's organization.
    /// </summary>
    [JsonIgnore]
    public string? PracticeId { get; set; }

    /// <summary>
    /// Add related records to the response. `variants` adds the medication's other strengths, forms and pharmacies.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<GetMedicationsRequestExpandItem> Expand { get; set; } =
        new List<GetMedicationsRequestExpandItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
