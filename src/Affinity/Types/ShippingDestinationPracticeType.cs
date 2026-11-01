using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ShippingDestinationPracticeType.ShippingDestinationPracticeTypeSerializer))]
[Serializable]
public readonly record struct ShippingDestinationPracticeType : IStringEnum
{
    public static readonly ShippingDestinationPracticeType Practice = new(Values.Practice);

    public ShippingDestinationPracticeType(string value)
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
    public static ShippingDestinationPracticeType FromCustom(string value)
    {
        return new ShippingDestinationPracticeType(value);
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

    public static bool operator ==(ShippingDestinationPracticeType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ShippingDestinationPracticeType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ShippingDestinationPracticeType value) => value.Value;

    public static explicit operator ShippingDestinationPracticeType(string value) => new(value);

    internal class ShippingDestinationPracticeTypeSerializer
        : JsonConverter<ShippingDestinationPracticeType>
    {
        public override ShippingDestinationPracticeType Read(
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
            return new ShippingDestinationPracticeType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ShippingDestinationPracticeType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ShippingDestinationPracticeType ReadAsPropertyName(
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
            return new ShippingDestinationPracticeType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ShippingDestinationPracticeType value,
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
        public const string Practice = "practice";
    }
}
