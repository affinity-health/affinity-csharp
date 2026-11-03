using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record GetPracticesRequest
{
    /// <summary>
    /// The practice ID.
    /// </summary>
    [JsonIgnore]
    public required string PracticeId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
