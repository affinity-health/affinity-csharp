using Affinity.Core;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record OrderList : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [JsonPropertyName("data")]
    public IEnumerable<Order> Data { get; set; } = new List<Order>();

    [JsonPropertyName("hasMore")]
    public required bool HasMore { get; set; }

    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; set; }

    [JsonPropertyName("object")]
    public required OrderListObject Object { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }

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
