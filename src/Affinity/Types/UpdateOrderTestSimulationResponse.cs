using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record UpdateOrderTestSimulationResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("mode")]
    public required UpdateOrderTestSimulationResponseMode Mode { get; set; }

    [JsonPropertyName("scenario")]
    public required UpdateOrderTestSimulationResponseScenario Scenario { get; set; }

    [JsonPropertyName("pendingAction")]
    public string? PendingAction { get; set; }

    [JsonPropertyName("lastError")]
    public string? LastError { get; set; }

    [JsonPropertyName("availableActions")]
    public IEnumerable<UpdateOrderTestSimulationResponseAvailableActionsItem> AvailableActions { get; set; } =
        new List<UpdateOrderTestSimulationResponseAvailableActionsItem>();

    [JsonPropertyName("scenarioEditable")]
    public required bool ScenarioEditable { get; set; }

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
