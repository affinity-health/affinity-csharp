using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature.ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperatureSerializer)
)]
[Serializable]
public readonly record struct ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature
    : IStringEnum
{
    public static readonly ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature Ambient =
        new(Values.Ambient);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature Refrigerated =
        new(Values.Refrigerated);

    public ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature(string value)
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
    public static ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature FromCustom(
        string value
    )
    {
        return new ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature(value);
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
        ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature value
    ) => value.Value;

    public static explicit operator ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature(
        string value
    ) => new(value);

    internal class ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperatureSerializer
        : JsonConverter<ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature>
    {
        public override ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature Read(
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
            return new ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature ReadAsPropertyName(
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
            return new ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemShippingOptionTemperature value,
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
        public const string Ambient = "ambient";

        public const string Refrigerated = "refrigerated";
    }
}
