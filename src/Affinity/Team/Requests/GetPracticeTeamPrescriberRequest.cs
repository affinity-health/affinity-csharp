using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record GetPracticeTeamPrescriberRequest
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
