using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus.CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatusSerializer)
)]
[Serializable]
public readonly record struct CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus
    : IStringEnum
{
    public static readonly CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus NoKnown =
        new(Values.NoKnown);

    public static readonly CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus NotReviewed =
        new(Values.NotReviewed);

    public static readonly CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus Recorded =
        new(Values.Recorded);

    public CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus(string value)
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
    public static CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus FromCustom(
        string value
    )
    {
        return new CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus(value);
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
        CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus value
    ) => value.Value;

    public static explicit operator CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus(
        string value
    ) => new(value);

    internal class CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatusSerializer
        : JsonConverter<CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus>
    {
        public override CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus Read(
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
            return new CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus ReadAsPropertyName(
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
            return new CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelOrderResponsePrescriptionsItemPatientSnapshotAllergyReviewStatus value,
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
