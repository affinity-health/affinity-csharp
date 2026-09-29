using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Affinity;

[Serializable]
public record ListPharmaciesResponseDataItemProfile : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("effectiveAt")]
    public required string EffectiveAt { get; set; }

    [JsonPropertyName("monthlyPrescriptionVolume")]
    public int? MonthlyPrescriptionVolume { get; set; }

    [JsonPropertyName("rating")]
    public OneOf<double, ListPharmaciesResponseDataItemProfileRatingOne>? Rating { get; set; }

    [JsonPropertyName("ratingBasis")]
    public string? RatingBasis { get; set; }

    [JsonPropertyName("ratingReviewCount")]
    public int? RatingReviewCount { get; set; }

    [JsonPropertyName("recommendedRank")]
    public int? RecommendedRank { get; set; }

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
