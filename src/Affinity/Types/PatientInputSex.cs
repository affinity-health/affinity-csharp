using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(PatientInputSex.PatientInputSexSerializer))]
[Serializable]
public readonly record struct PatientInputSex : IStringEnum
{
    public static readonly PatientInputSex Female = new(Values.Female);

    public static readonly PatientInputSex Male = new(Values.Male);

    public static readonly PatientInputSex Unknown = new(Values.Unknown);

    public PatientInputSex(string value)
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
    public static PatientInputSex FromCustom(string value)
    {
        return new PatientInputSex(value);
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

    public static bool operator ==(PatientInputSex value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PatientInputSex value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PatientInputSex value) => value.Value;

    public static explicit operator PatientInputSex(string value) => new(value);

    internal class PatientInputSexSerializer : JsonConverter<PatientInputSex>
    {
        public override PatientInputSex Read(
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
            return new PatientInputSex(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PatientInputSex value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PatientInputSex ReadAsPropertyName(
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
            return new PatientInputSex(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PatientInputSex value,
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
        public const string Female = "female";

        public const string Male = "male";

        public const string Unknown = "unknown";
    }
}
