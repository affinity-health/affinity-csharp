using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ReplacePatientAllergiesResponseAllergiesItemSeverity.ReplacePatientAllergiesResponseAllergiesItemSeveritySerializer)
)]
[Serializable]
public readonly record struct ReplacePatientAllergiesResponseAllergiesItemSeverity : IStringEnum
{
    public static readonly ReplacePatientAllergiesResponseAllergiesItemSeverity Mild = new(
        Values.Mild
    );

    public static readonly ReplacePatientAllergiesResponseAllergiesItemSeverity Moderate = new(
        Values.Moderate
    );

    public static readonly ReplacePatientAllergiesResponseAllergiesItemSeverity Severe = new(
        Values.Severe
    );

    public static readonly ReplacePatientAllergiesResponseAllergiesItemSeverity Unknown = new(
        Values.Unknown
    );

    public ReplacePatientAllergiesResponseAllergiesItemSeverity(string value)
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
    public static ReplacePatientAllergiesResponseAllergiesItemSeverity FromCustom(string value)
    {
        return new ReplacePatientAllergiesResponseAllergiesItemSeverity(value);
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
        ReplacePatientAllergiesResponseAllergiesItemSeverity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReplacePatientAllergiesResponseAllergiesItemSeverity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ReplacePatientAllergiesResponseAllergiesItemSeverity value
    ) => value.Value;

    public static explicit operator ReplacePatientAllergiesResponseAllergiesItemSeverity(
        string value
    ) => new(value);

    internal class ReplacePatientAllergiesResponseAllergiesItemSeveritySerializer
        : JsonConverter<ReplacePatientAllergiesResponseAllergiesItemSeverity>
    {
        public override ReplacePatientAllergiesResponseAllergiesItemSeverity Read(
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
            return new ReplacePatientAllergiesResponseAllergiesItemSeverity(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesResponseAllergiesItemSeverity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReplacePatientAllergiesResponseAllergiesItemSeverity ReadAsPropertyName(
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
            return new ReplacePatientAllergiesResponseAllergiesItemSeverity(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesResponseAllergiesItemSeverity value,
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
