using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType.ListOrdersResponseDataItemFulfillmentsItemShippingDestinationTypeSerializer)
)]
[Serializable]
public readonly record struct ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType
    : IStringEnum
{
    public static readonly ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType Patient =
        new(Values.Patient);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType Practice =
        new(Values.Practice);

    public ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType(string value)
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
    public static ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType FromCustom(
        string value
    )
    {
        return new ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType(value);
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
        ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType value
    ) => value.Value;

    public static explicit operator ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType(
        string value
    ) => new(value);

    internal class ListOrdersResponseDataItemFulfillmentsItemShippingDestinationTypeSerializer
        : JsonConverter<ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType>
    {
        public override ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType Read(
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
            return new ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType ReadAsPropertyName(
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
            return new ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemShippingDestinationType value,
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
        public const string Patient = "patient";

        public const string Practice = "practice";
    }
}
