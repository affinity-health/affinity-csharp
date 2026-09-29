using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseFormulationDefaultFormat.RetrievePrescribingOptionsResponseFormulationDefaultFormatSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseFormulationDefaultFormat
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseFormulationDefaultFormat FreeText =
        new(Values.FreeText);

    public static readonly RetrievePrescribingOptionsResponseFormulationDefaultFormat Structured =
        new(Values.Structured);

    public RetrievePrescribingOptionsResponseFormulationDefaultFormat(string value)
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
    public static RetrievePrescribingOptionsResponseFormulationDefaultFormat FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponseFormulationDefaultFormat(value);
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
        RetrievePrescribingOptionsResponseFormulationDefaultFormat value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseFormulationDefaultFormat value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseFormulationDefaultFormat value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseFormulationDefaultFormat(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseFormulationDefaultFormatSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseFormulationDefaultFormat>
    {
        public override RetrievePrescribingOptionsResponseFormulationDefaultFormat Read(
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
            return new RetrievePrescribingOptionsResponseFormulationDefaultFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseFormulationDefaultFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseFormulationDefaultFormat ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseFormulationDefaultFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseFormulationDefaultFormat value,
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
        public const string FreeText = "free_text";

        public const string Structured = "structured";
    }
}
