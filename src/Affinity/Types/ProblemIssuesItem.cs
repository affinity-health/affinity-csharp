using Affinity.Core;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity;

[Serializable]
public record ProblemIssuesItem : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [JsonPropertyName("code")]
    public required string Code { get; set; }

    [JsonPropertyName("field")]
    public required string Field { get; set; }

    [JsonPropertyName("message")]
    public required string Message { get; set; }

    [JsonPropertyName("path")]
    public IEnumerable<OneOf<string, int>> Path { get; set; } = new List<OneOf<string, int>>();

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
