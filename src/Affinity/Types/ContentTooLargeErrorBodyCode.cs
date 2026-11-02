using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ContentTooLargeErrorBodyCode : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [JsonPropertyName("code")]
    public required ContentTooLargeErrorBodyCodeCode Code { get; set; }

    [JsonPropertyName("detail")]
    public required string Detail { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("instance")]
    public required string Instance { get; set; }

    [JsonPropertyName("requestId")]
    public required string RequestId { get; set; }

    [JsonPropertyName("status")]
    public required int Status { get; set; }

    [JsonPropertyName("traceId")]
    public string? TraceId { get; set; }

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
