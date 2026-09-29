using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListOrdersResponseDataItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Opaque revision of the complete order prescription set. Send the revision you reviewed as expectedRevision; never replace it automatically after a conflict.
    /// </summary>
    [JsonPropertyName("revision")]
    public required string Revision { get; set; }

    [JsonPropertyName("otcItems")]
    public IEnumerable<ListOrdersResponseDataItemOtcItemsItem> OtcItems { get; set; } =
        new List<ListOrdersResponseDataItemOtcItemsItem>();

    /// <summary>
    /// Snapshot of the practice-facing medication total. Null until every prescription has recorded submission pricing. Excludes shipping and supplies.
    /// </summary>
    [JsonPropertyName("practiceMedicationTotalCents")]
    public int? PracticeMedicationTotalCents { get; set; }

    [JsonPropertyName("externalOrderId")]
    public string? ExternalOrderId { get; set; }

    [JsonPropertyName("metadata")]
    public required ListOrdersResponseDataItemMetadata Metadata { get; set; }

    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("fulfillments")]
    public IEnumerable<ListOrdersResponseDataItemFulfillmentsItem> Fulfillments { get; set; } =
        new List<ListOrdersResponseDataItemFulfillmentsItem>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("lifecycleEvents")]
    public IEnumerable<ListOrdersResponseDataItemLifecycleEventsItem> LifecycleEvents { get; set; } =
        new List<ListOrdersResponseDataItemLifecycleEventsItem>();

    [JsonPropertyName("livemode")]
    public required bool Livemode { get; set; }

    [JsonPropertyName("object")]
    public required ListOrdersResponseDataItemObject Object { get; set; }

    [JsonPropertyName("patientExternalId")]
    public string? PatientExternalId { get; set; }

    [JsonPropertyName("patientId")]
    public required string PatientId { get; set; }

    [JsonPropertyName("patientName")]
    public required string PatientName { get; set; }

    /// <summary>
    /// The patient's current clinical state. This is not the saved delivery state; use each prescription's deliveryAddress for shipping.
    /// </summary>
    [JsonPropertyName("patientState")]
    public required string PatientState { get; set; }

    [JsonPropertyName("practiceId")]
    public required string PracticeId { get; set; }

    [JsonPropertyName("prescriberName")]
    public string? PrescriberName { get; set; }

    [JsonPropertyName("prescriberNpi")]
    public string? PrescriberNpi { get; set; }

    [JsonPropertyName("review")]
    public ListOrdersResponseDataItemReview? Review { get; set; }

    [JsonPropertyName("prescriptions")]
    public IEnumerable<ListOrdersResponseDataItemPrescriptionsItem> Prescriptions { get; set; } =
        new List<ListOrdersResponseDataItemPrescriptionsItem>();

    [JsonPropertyName("status")]
    public required ListOrdersResponseDataItemStatus Status { get; set; }

    [JsonPropertyName("updatedAt")]
    public required string UpdatedAt { get; set; }

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
