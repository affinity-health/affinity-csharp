using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseDefaultFormat.RetrievePrescribingOptionsResponseDefaultFormatSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseDefaultFormat : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseDefaultFormat FreeText = new(
        Values.FreeText
    );

    public static readonly RetrievePrescribingOptionsResponseDefaultFormat Structured = new(
        Values.Structured
    );

    public RetrievePrescribingOptionsResponseDefaultFormat(string value)
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
    public static RetrievePrescribingOptionsResponseDefaultFormat FromCustom(string value)
    {
        return new RetrievePrescribingOptionsResponseDefaultFormat(value);
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
        RetrievePrescribingOptionsResponseDefaultFormat value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseDefaultFormat value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(RetrievePrescribingOptionsResponseDefaultFormat value) =>
        value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseDefaultFormat(string value) =>
        new(value);

    internal class RetrievePrescribingOptionsResponseDefaultFormatSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseDefaultFormat>
    {
        public override RetrievePrescribingOptionsResponseDefaultFormat Read(
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
            return new RetrievePrescribingOptionsResponseDefaultFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseDefaultFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseDefaultFormat ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseDefaultFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseDefaultFormat value,
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
