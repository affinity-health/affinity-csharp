using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(PatientSex.PatientSexSerializer))]
[Serializable]
public readonly record struct PatientSex : IStringEnum
{
    public static readonly PatientSex Female = new(Values.Female);

    public static readonly PatientSex Male = new(Values.Male);

    public static readonly PatientSex Unknown = new(Values.Unknown);

    public PatientSex(string value)
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
    public static PatientSex FromCustom(string value)
    {
        return new PatientSex(value);
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

    public static bool operator ==(PatientSex value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(PatientSex value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PatientSex value) => value.Value;

    public static explicit operator PatientSex(string value) => new(value);

    internal class PatientSexSerializer : JsonConverter<PatientSex>
    {
        public override PatientSex Read(
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
            return new PatientSex(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PatientSex value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PatientSex ReadAsPropertyName(
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
            return new PatientSex(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PatientSex value,
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
