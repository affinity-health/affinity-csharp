using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(OrderMode.OrderModeSerializer))]
[Serializable]
public readonly record struct OrderMode : IStringEnum
{
    public static readonly OrderMode Test = new(Values.Test);

    public static readonly OrderMode Live = new(Values.Live);

    public OrderMode(string value)
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
    public static OrderMode FromCustom(string value)
    {
        return new OrderMode(value);
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

    public static bool operator ==(OrderMode value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(OrderMode value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(OrderMode value) => value.Value;

    public static explicit operator OrderMode(string value) => new(value);

    internal class OrderModeSerializer : JsonConverter<OrderMode>
    {
        public override OrderMode Read(
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
            return new OrderMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrderMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrderMode ReadAsPropertyName(
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
            return new OrderMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrderMode value,
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
        public const string Test = "test";

        public const string Live = "live";
    }
}
