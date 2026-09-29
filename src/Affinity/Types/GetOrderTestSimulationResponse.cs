using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record GetOrderTestSimulationResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("mode")]
    public required GetOrderTestSimulationResponseMode Mode { get; set; }

    [JsonPropertyName("scenario")]
    public required GetOrderTestSimulationResponseScenario Scenario { get; set; }

    [JsonPropertyName("pendingAction")]
    public string? PendingAction { get; set; }

    [JsonPropertyName("lastError")]
    public string? LastError { get; set; }

    [JsonPropertyName("availableActions")]
    public IEnumerable<GetOrderTestSimulationResponseAvailableActionsItem> AvailableActions { get; set; } =
        new List<GetOrderTestSimulationResponseAvailableActionsItem>();

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
