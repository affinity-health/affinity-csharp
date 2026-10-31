using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(OrderListObject.OrderListObjectSerializer))]
[Serializable]
public readonly record struct OrderListObject : IStringEnum
{
    public static readonly OrderListObject List = new(Values.List);

    public OrderListObject(string value)
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
    public static OrderListObject FromCustom(string value)
    {
        return new OrderListObject(value);
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

    public static bool operator ==(OrderListObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrderListObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderListObject value) => value.Value;

    public static explicit operator OrderListObject(string value) => new(value);

    internal class OrderListObjectSerializer : JsonConverter<OrderListObject>
    {
        public override OrderListObject Read(
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
            return new OrderListObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrderListObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrderListObject ReadAsPropertyName(
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
            return new OrderListObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrderListObject value,
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
        public const string List = "list";
    }
}
