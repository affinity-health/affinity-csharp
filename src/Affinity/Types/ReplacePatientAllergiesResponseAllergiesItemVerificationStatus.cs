using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ReplacePatientAllergiesResponseAllergiesItemVerificationStatus.ReplacePatientAllergiesResponseAllergiesItemVerificationStatusSerializer)
)]
[Serializable]
public readonly record struct ReplacePatientAllergiesResponseAllergiesItemVerificationStatus
    : IStringEnum
{
    public static readonly ReplacePatientAllergiesResponseAllergiesItemVerificationStatus Unconfirmed =
        new(Values.Unconfirmed);

    public static readonly ReplacePatientAllergiesResponseAllergiesItemVerificationStatus Presumed =
        new(Values.Presumed);

    public static readonly ReplacePatientAllergiesResponseAllergiesItemVerificationStatus Confirmed =
        new(Values.Confirmed);

    public ReplacePatientAllergiesResponseAllergiesItemVerificationStatus(string value)
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
    public static ReplacePatientAllergiesResponseAllergiesItemVerificationStatus FromCustom(
        string value
    )
    {
        return new ReplacePatientAllergiesResponseAllergiesItemVerificationStatus(value);
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
        ReplacePatientAllergiesResponseAllergiesItemVerificationStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReplacePatientAllergiesResponseAllergiesItemVerificationStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ReplacePatientAllergiesResponseAllergiesItemVerificationStatus value
    ) => value.Value;

    public static explicit operator ReplacePatientAllergiesResponseAllergiesItemVerificationStatus(
        string value
    ) => new(value);

    internal class ReplacePatientAllergiesResponseAllergiesItemVerificationStatusSerializer
        : JsonConverter<ReplacePatientAllergiesResponseAllergiesItemVerificationStatus>
    {
        public override ReplacePatientAllergiesResponseAllergiesItemVerificationStatus Read(
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
            return new ReplacePatientAllergiesResponseAllergiesItemVerificationStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesResponseAllergiesItemVerificationStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReplacePatientAllergiesResponseAllergiesItemVerificationStatus ReadAsPropertyName(
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
            return new ReplacePatientAllergiesResponseAllergiesItemVerificationStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesResponseAllergiesItemVerificationStatus value,
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
        public const string Unconfirmed = "unconfirmed";

        public const string Presumed = "presumed";

        public const string Confirmed = "confirmed";
    }
}
