using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(OrderStatus.OrderStatusSerializer))]
[Serializable]
public readonly record struct OrderStatus : IStringEnum
{
    public static readonly OrderStatus AwaitingApproval = new(Values.AwaitingApproval);

    public static readonly OrderStatus Submitted = new(Values.Submitted);

    public static readonly OrderStatus Processing = new(Values.Processing);

    public static readonly OrderStatus Shipped = new(Values.Shipped);

    public static readonly OrderStatus Delivered = new(Values.Delivered);

    public static readonly OrderStatus Cancelled = new(Values.Cancelled);

    public static readonly OrderStatus Failed = new(Values.Failed);

    public OrderStatus(string value)
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
    public static OrderStatus FromCustom(string value)
    {
        return new OrderStatus(value);
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

    public static bool operator ==(OrderStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrderStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderStatus value) => value.Value;

    public static explicit operator OrderStatus(string value) => new(value);

    internal class OrderStatusSerializer : JsonConverter<OrderStatus>
    {
        public override OrderStatus Read(
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
            return new OrderStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrderStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrderStatus ReadAsPropertyName(
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
            return new OrderStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrderStatus value,
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
        public const string AwaitingApproval = "awaiting_approval";

        public const string Submitted = "submitted";

        public const string Processing = "processing";

        public const string Shipped = "shipped";

        public const string Delivered = "delivered";

        public const string Cancelled = "cancelled";

        public const string Failed = "failed";
    }
}
