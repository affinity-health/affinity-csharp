using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record PreviewOrderResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("clinicalRequirementsSatisfied")]
    public required bool ClinicalRequirementsSatisfied { get; set; }

    [JsonPropertyName("clinicalIssues")]
    public IEnumerable<PreviewOrderResponseClinicalIssuesItem> ClinicalIssues { get; set; } =
        new List<PreviewOrderResponseClinicalIssuesItem>();

    [JsonPropertyName("clinicalRequirements")]
    public IEnumerable<PreviewOrderResponseClinicalRequirementsItem> ClinicalRequirements { get; set; } =
        new List<PreviewOrderResponseClinicalRequirementsItem>();

    [JsonPropertyName("otcItems")]
    public IEnumerable<PreviewOrderResponseOtcItemsItem> OtcItems { get; set; } =
        new List<PreviewOrderResponseOtcItemsItem>();

    [JsonPropertyName("shippingGroups")]
    public IEnumerable<PreviewOrderResponseShippingGroupsItem> ShippingGroups { get; set; } =
        new List<PreviewOrderResponseShippingGroupsItem>();

    [JsonPropertyName("totals")]
    public required PreviewOrderResponseTotals Totals { get; set; }

    [JsonPropertyName("object")]
    public required PreviewOrderResponseObject Object { get; set; }

    [JsonPropertyName("livemode")]
    public required bool Livemode { get; set; }

    [JsonPropertyName("prescriptions")]
    public IEnumerable<PreviewOrderResponsePrescriptionsItem> Prescriptions { get; set; } =
        new List<PreviewOrderResponsePrescriptionsItem>();

    [JsonPropertyName("issues")]
    public IEnumerable<PreviewOrderResponseIssuesItem> Issues { get; set; } =
        new List<PreviewOrderResponseIssuesItem>();

    [JsonPropertyName("status")]
    public required PreviewOrderResponseStatus Status { get; set; }

    [JsonPropertyName("orderInput")]
    public PreviewOrderResponseOrderInput? OrderInput { get; set; }

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
