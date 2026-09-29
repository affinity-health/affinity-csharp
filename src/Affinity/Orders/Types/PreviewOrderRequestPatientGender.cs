using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(PreviewOrderRequestPatientGender.PreviewOrderRequestPatientGenderSerializer))]
[Serializable]
public readonly record struct PreviewOrderRequestPatientGender : IStringEnum
{
    public static readonly PreviewOrderRequestPatientGender F = new(Values.F);

    public static readonly PreviewOrderRequestPatientGender M = new(Values.M);

    public static readonly PreviewOrderRequestPatientGender O = new(Values.O);

    public static readonly PreviewOrderRequestPatientGender U = new(Values.U);

    public PreviewOrderRequestPatientGender(string value)
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
    public static PreviewOrderRequestPatientGender FromCustom(string value)
    {
        return new PreviewOrderRequestPatientGender(value);
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

    public static bool operator ==(PreviewOrderRequestPatientGender value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PreviewOrderRequestPatientGender value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PreviewOrderRequestPatientGender value) => value.Value;

    public static explicit operator PreviewOrderRequestPatientGender(string value) => new(value);

    internal class PreviewOrderRequestPatientGenderSerializer
        : JsonConverter<PreviewOrderRequestPatientGender>
    {
        public override PreviewOrderRequestPatientGender Read(
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
            return new PreviewOrderRequestPatientGender(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderRequestPatientGender value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderRequestPatientGender ReadAsPropertyName(
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
            return new PreviewOrderRequestPatientGender(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderRequestPatientGender value,
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
        public const string F = "f";

        public const string M = "m";

        public const string O = "o";

        public const string U = "u";
    }
}
