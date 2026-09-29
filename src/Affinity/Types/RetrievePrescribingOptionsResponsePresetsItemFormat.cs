using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponsePresetsItemFormat.RetrievePrescribingOptionsResponsePresetsItemFormatSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponsePresetsItemFormat : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponsePresetsItemFormat Structured = new(
        Values.Structured
    );

    public static readonly RetrievePrescribingOptionsResponsePresetsItemFormat FreeText = new(
        Values.FreeText
    );

    public RetrievePrescribingOptionsResponsePresetsItemFormat(string value)
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
    public static RetrievePrescribingOptionsResponsePresetsItemFormat FromCustom(string value)
    {
        return new RetrievePrescribingOptionsResponsePresetsItemFormat(value);
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
        RetrievePrescribingOptionsResponsePresetsItemFormat value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponsePresetsItemFormat value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponsePresetsItemFormat value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponsePresetsItemFormat(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponsePresetsItemFormatSerializer
        : JsonConverter<RetrievePrescribingOptionsResponsePresetsItemFormat>
    {
        public override RetrievePrescribingOptionsResponsePresetsItemFormat Read(
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
            return new RetrievePrescribingOptionsResponsePresetsItemFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponsePresetsItemFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponsePresetsItemFormat ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponsePresetsItemFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponsePresetsItemFormat value,
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
        public const string Structured = "structured";

        public const string FreeText = "free_text";
    }
}
