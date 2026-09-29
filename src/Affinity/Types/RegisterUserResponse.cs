using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record RegisterUserResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("object")]
    public required RegisterUserResponseObject Object { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("practiceId")]
    public required string PracticeId { get; set; }

    [JsonPropertyName("memberId")]
    public required string MemberId { get; set; }

    [JsonPropertyName("prescriberId")]
    public string? PrescriberId { get; set; }

    [JsonPropertyName("externalId")]
    public required string ExternalId { get; set; }

    [JsonPropertyName("livemode")]
    public required bool Livemode { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
