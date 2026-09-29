using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat.RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormatSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat FreeText =
        new(Values.FreeText);

    public static readonly RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat Structured =
        new(Values.Structured);

    public RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat(string value)
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
    public static RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat(value);
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
        RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormatSerializer
        : JsonConverter<RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat>
    {
        public override RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat Read(
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
            return new RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponsePharmacyDirectionsItemFormat value,
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
