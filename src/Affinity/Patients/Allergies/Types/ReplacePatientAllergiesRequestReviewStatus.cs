using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Patients;

[JsonConverter(
    typeof(ReplacePatientAllergiesRequestReviewStatus.ReplacePatientAllergiesRequestReviewStatusSerializer)
)]
[Serializable]
public readonly record struct ReplacePatientAllergiesRequestReviewStatus : IStringEnum
{
    public static readonly ReplacePatientAllergiesRequestReviewStatus NotReviewed = new(
        Values.NotReviewed
    );

    public static readonly ReplacePatientAllergiesRequestReviewStatus NoKnown = new(Values.NoKnown);

    public static readonly ReplacePatientAllergiesRequestReviewStatus Recorded = new(
        Values.Recorded
    );

    public ReplacePatientAllergiesRequestReviewStatus(string value)
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
    public static ReplacePatientAllergiesRequestReviewStatus FromCustom(string value)
    {
        return new ReplacePatientAllergiesRequestReviewStatus(value);
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
        ReplacePatientAllergiesRequestReviewStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReplacePatientAllergiesRequestReviewStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ReplacePatientAllergiesRequestReviewStatus value) =>
        value.Value;

    public static explicit operator ReplacePatientAllergiesRequestReviewStatus(string value) =>
        new(value);

    internal class ReplacePatientAllergiesRequestReviewStatusSerializer
        : JsonConverter<ReplacePatientAllergiesRequestReviewStatus>
    {
        public override ReplacePatientAllergiesRequestReviewStatus Read(
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
            return new ReplacePatientAllergiesRequestReviewStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesRequestReviewStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReplacePatientAllergiesRequestReviewStatus ReadAsPropertyName(
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
            return new ReplacePatientAllergiesRequestReviewStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesRequestReviewStatus value,
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
        public const string NotReviewed = "not_reviewed";

        public const string NoKnown = "no_known";

        public const string Recorded = "recorded";
    }
}
