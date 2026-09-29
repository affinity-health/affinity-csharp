using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource.ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSourceSerializer)
)]
[Serializable]
public readonly record struct ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource
    : IStringEnum
{
    public static readonly ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource PharmacyWebhook =
        new(Values.PharmacyWebhook);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource Pharmacy =
        new(Values.Pharmacy);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource System =
        new(Values.System);

    public ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource(string value)
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
    public static ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource FromCustom(
        string value
    )
    {
        return new ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource(value);
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
        ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource value
    ) => value.Value;

    public static explicit operator ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource(
        string value
    ) => new(value);

    internal class ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSourceSerializer
        : JsonConverter<ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource>
    {
        public override ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource Read(
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
            return new ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource ReadAsPropertyName(
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
            return new ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemShipmentsItemSource value,
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
        public const string PharmacyWebhook = "pharmacy_webhook";

        public const string Pharmacy = "pharmacy";

        public const string System = "system";
    }
}
