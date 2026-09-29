using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[Serializable]
public record ListOrdersResponseDataItemPrescriptionsItemPatientSnapshot : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("address")]
    public Dictionary<string, object?>? Address { get; set; }

    [JsonPropertyName("allergyReviewStatus")]
    public ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus? AllergyReviewStatus { get; set; }

    [JsonPropertyName("dateOfBirth")]
    public required string DateOfBirth { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("gender")]
    public ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender? Gender { get; set; }

    [JsonPropertyName("legalName")]
    public required string LegalName { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("state")]
    public required string State { get; set; }

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
