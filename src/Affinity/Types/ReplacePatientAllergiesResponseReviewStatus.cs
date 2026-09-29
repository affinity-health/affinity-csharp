using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ReplacePatientAllergiesResponseReviewStatus.ReplacePatientAllergiesResponseReviewStatusSerializer)
)]
[Serializable]
public readonly record struct ReplacePatientAllergiesResponseReviewStatus : IStringEnum
{
    public static readonly ReplacePatientAllergiesResponseReviewStatus NotReviewed = new(
        Values.NotReviewed
    );

    public static readonly ReplacePatientAllergiesResponseReviewStatus NoKnown = new(
        Values.NoKnown
    );

    public static readonly ReplacePatientAllergiesResponseReviewStatus Recorded = new(
        Values.Recorded
    );

    public ReplacePatientAllergiesResponseReviewStatus(string value)
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
    public static ReplacePatientAllergiesResponseReviewStatus FromCustom(string value)
    {
        return new ReplacePatientAllergiesResponseReviewStatus(value);
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
        ReplacePatientAllergiesResponseReviewStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReplacePatientAllergiesResponseReviewStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ReplacePatientAllergiesResponseReviewStatus value) =>
        value.Value;

    public static explicit operator ReplacePatientAllergiesResponseReviewStatus(string value) =>
        new(value);

    internal class ReplacePatientAllergiesResponseReviewStatusSerializer
        : JsonConverter<ReplacePatientAllergiesResponseReviewStatus>
    {
        public override ReplacePatientAllergiesResponseReviewStatus Read(
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
            return new ReplacePatientAllergiesResponseReviewStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesResponseReviewStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReplacePatientAllergiesResponseReviewStatus ReadAsPropertyName(
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
            return new ReplacePatientAllergiesResponseReviewStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesResponseReviewStatus value,
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
