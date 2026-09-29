using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus.ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatusSerializer)
)]
[Serializable]
public readonly record struct ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus
    : IStringEnum
{
    public static readonly ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus NoKnown =
        new(Values.NoKnown);

    public static readonly ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus NotReviewed =
        new(Values.NotReviewed);

    public static readonly ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus Recorded =
        new(Values.Recorded);

    public ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus(
        string value
    )
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus FromCustom(
        string value
    )
    {
        return new ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus(
            value
        );
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(
        ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus value
    ) => value.Value;

    public static explicit operator ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus(
        string value
    ) => new(value);

    internal class ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatusSerializer
        : JsonConverter<ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus>
    {
        public override ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotAllergyReviewStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string NoKnown = "no_known";

        public const string NotReviewed = "not_reviewed";

        public const string Recorded = "recorded";
    }
}
