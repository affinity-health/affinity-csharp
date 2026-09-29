using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record CreatePracticeRequestAttestations : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("authorizedPracticeRelationship")]
    public required bool AuthorizedPracticeRelationship { get; set; }

    [JsonPropertyName("authorizedPhiTransfer")]
    public required bool AuthorizedPhiTransfer { get; set; }

    [JsonPropertyName("minimumNecessaryPhi")]
    public required bool MinimumNecessaryPhi { get; set; }

    [JsonPropertyName("providerDataAccuracy")]
    public required bool ProviderDataAccuracy { get; set; }

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
