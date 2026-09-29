using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListOrdersResponseDataItemFulfillmentsItemShippingMethod.ListOrdersResponseDataItemFulfillmentsItemShippingMethodSerializer)
)]
[Serializable]
public readonly record struct ListOrdersResponseDataItemFulfillmentsItemShippingMethod : IStringEnum
{
    public static readonly ListOrdersResponseDataItemFulfillmentsItemShippingMethod Standard = new(
        Values.Standard
    );

    public static readonly ListOrdersResponseDataItemFulfillmentsItemShippingMethod Expedited = new(
        Values.Expedited
    );

    public static readonly ListOrdersResponseDataItemFulfillmentsItemShippingMethod Overnight = new(
        Values.Overnight
    );

    public static readonly ListOrdersResponseDataItemFulfillmentsItemShippingMethod Pickup = new(
        Values.Pickup
    );

    public static readonly ListOrdersResponseDataItemFulfillmentsItemShippingMethod LocalDelivery =
        new(Values.LocalDelivery);

    public ListOrdersResponseDataItemFulfillmentsItemShippingMethod(string value)
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
    public static ListOrdersResponseDataItemFulfillmentsItemShippingMethod FromCustom(string value)
    {
        return new ListOrdersResponseDataItemFulfillmentsItemShippingMethod(value);
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
        ListOrdersResponseDataItemFulfillmentsItemShippingMethod value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListOrdersResponseDataItemFulfillmentsItemShippingMethod value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListOrdersResponseDataItemFulfillmentsItemShippingMethod value
    ) => value.Value;

    public static explicit operator ListOrdersResponseDataItemFulfillmentsItemShippingMethod(
        string value
    ) => new(value);

    internal class ListOrdersResponseDataItemFulfillmentsItemShippingMethodSerializer
        : JsonConverter<ListOrdersResponseDataItemFulfillmentsItemShippingMethod>
    {
        public override ListOrdersResponseDataItemFulfillmentsItemShippingMethod Read(
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
            return new ListOrdersResponseDataItemFulfillmentsItemShippingMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemShippingMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseDataItemFulfillmentsItemShippingMethod ReadAsPropertyName(
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
            return new ListOrdersResponseDataItemFulfillmentsItemShippingMethod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemShippingMethod value,
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
        public const string Standard = "standard";

        public const string Expedited = "expedited";

        public const string Overnight = "overnight";

        public const string Pickup = "pickup";

        public const string LocalDelivery = "local_delivery";
    }
}
