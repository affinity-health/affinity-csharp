using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Patients;

[JsonConverter(
    typeof(ReplacePatientAllergiesRequestAllergiesItemVerificationStatus.ReplacePatientAllergiesRequestAllergiesItemVerificationStatusSerializer)
)]
[Serializable]
public readonly record struct ReplacePatientAllergiesRequestAllergiesItemVerificationStatus
    : IStringEnum
{
    public static readonly ReplacePatientAllergiesRequestAllergiesItemVerificationStatus Unconfirmed =
        new(Values.Unconfirmed);

    public static readonly ReplacePatientAllergiesRequestAllergiesItemVerificationStatus Presumed =
        new(Values.Presumed);

    public static readonly ReplacePatientAllergiesRequestAllergiesItemVerificationStatus Confirmed =
        new(Values.Confirmed);

    public ReplacePatientAllergiesRequestAllergiesItemVerificationStatus(string value)
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
    public static ReplacePatientAllergiesRequestAllergiesItemVerificationStatus FromCustom(
        string value
    )
    {
        return new ReplacePatientAllergiesRequestAllergiesItemVerificationStatus(value);
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
        ReplacePatientAllergiesRequestAllergiesItemVerificationStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReplacePatientAllergiesRequestAllergiesItemVerificationStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ReplacePatientAllergiesRequestAllergiesItemVerificationStatus value
    ) => value.Value;

    public static explicit operator ReplacePatientAllergiesRequestAllergiesItemVerificationStatus(
        string value
    ) => new(value);

    internal class ReplacePatientAllergiesRequestAllergiesItemVerificationStatusSerializer
        : JsonConverter<ReplacePatientAllergiesRequestAllergiesItemVerificationStatus>
    {
        public override ReplacePatientAllergiesRequestAllergiesItemVerificationStatus Read(
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
            return new ReplacePatientAllergiesRequestAllergiesItemVerificationStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesRequestAllergiesItemVerificationStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReplacePatientAllergiesRequestAllergiesItemVerificationStatus ReadAsPropertyName(
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
            return new ReplacePatientAllergiesRequestAllergiesItemVerificationStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesRequestAllergiesItemVerificationStatus value,
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
