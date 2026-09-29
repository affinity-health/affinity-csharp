using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Patients;

[JsonConverter(
    typeof(ReplacePatientAllergiesRequestAllergiesItemSeverity.ReplacePatientAllergiesRequestAllergiesItemSeveritySerializer)
)]
[Serializable]
public readonly record struct ReplacePatientAllergiesRequestAllergiesItemSeverity : IStringEnum
{
    public static readonly ReplacePatientAllergiesRequestAllergiesItemSeverity Mild = new(
        Values.Mild
    );

    public static readonly ReplacePatientAllergiesRequestAllergiesItemSeverity Moderate = new(
        Values.Moderate
    );

    public static readonly ReplacePatientAllergiesRequestAllergiesItemSeverity Severe = new(
        Values.Severe
    );

    public static readonly ReplacePatientAllergiesRequestAllergiesItemSeverity Unknown = new(
        Values.Unknown
    );

    public ReplacePatientAllergiesRequestAllergiesItemSeverity(string value)
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
    public static ReplacePatientAllergiesRequestAllergiesItemSeverity FromCustom(string value)
    {
        return new ReplacePatientAllergiesRequestAllergiesItemSeverity(value);
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
        ReplacePatientAllergiesRequestAllergiesItemSeverity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReplacePatientAllergiesRequestAllergiesItemSeverity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ReplacePatientAllergiesRequestAllergiesItemSeverity value
    ) => value.Value;

    public static explicit operator ReplacePatientAllergiesRequestAllergiesItemSeverity(
        string value
    ) => new(value);

    internal class ReplacePatientAllergiesRequestAllergiesItemSeveritySerializer
        : JsonConverter<ReplacePatientAllergiesRequestAllergiesItemSeverity>
    {
        public override ReplacePatientAllergiesRequestAllergiesItemSeverity Read(
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
            return new ReplacePatientAllergiesRequestAllergiesItemSeverity(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesRequestAllergiesItemSeverity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReplacePatientAllergiesRequestAllergiesItemSeverity ReadAsPropertyName(
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
            return new ReplacePatientAllergiesRequestAllergiesItemSeverity(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesRequestAllergiesItemSeverity value,
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
        public const string Mild = "mild";

        public const string Moderate = "moderate";

        public const string Severe = "severe";

        public const string Unknown = "unknown";
    }
}
