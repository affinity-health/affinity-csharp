using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(OrderEventType.OrderEventTypeSerializer))]
[Serializable]
public readonly record struct OrderEventType : IStringEnum
{
    public static readonly OrderEventType OrderCancelled = new(Values.OrderCancelled);

    public static readonly OrderEventType OrderDelivered = new(Values.OrderDelivered);

    public static readonly OrderEventType OrderFailed = new(Values.OrderFailed);

    public static readonly OrderEventType OrderProcessing = new(Values.OrderProcessing);

    public static readonly OrderEventType OrderShipped = new(Values.OrderShipped);

    public static readonly OrderEventType OrderSubmitted = new(Values.OrderSubmitted);

    public static readonly OrderEventType OrderUpdated = new(Values.OrderUpdated);

    public OrderEventType(string value)
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
    public static OrderEventType FromCustom(string value)
    {
        return new OrderEventType(value);
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

    public static bool operator ==(OrderEventType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrderEventType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderEventType value) => value.Value;

    public static explicit operator OrderEventType(string value) => new(value);

    internal class OrderEventTypeSerializer : JsonConverter<OrderEventType>
    {
        public override OrderEventType Read(
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
            return new OrderEventType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrderEventType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrderEventType ReadAsPropertyName(
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
            return new OrderEventType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrderEventType value,
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
        public const string OrderCancelled = "order.cancelled";

        public const string OrderDelivered = "order.delivered";

        public const string OrderFailed = "order.failed";

        public const string OrderProcessing = "order.processing";

        public const string OrderShipped = "order.shipped";

        public const string OrderSubmitted = "order.submitted";

        public const string OrderUpdated = "order.updated";
    }
}
