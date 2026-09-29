using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity.Team;

[Serializable]
public record GetPrescribersRequest
{
    [JsonIgnore]
    public required string PracticeId { get; set; }

    [JsonIgnore]
    public required string PrescriberId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
