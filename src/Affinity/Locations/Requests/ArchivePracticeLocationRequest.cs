using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ArchivePracticeLocationRequest
{
    [JsonIgnore]
    public required string PracticeId { get; set; }

    [JsonIgnore]
    public required string LocationId { get; set; }

    [JsonIgnore]
    public required string IdempotencyKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
