using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus.ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatusSerializer)
)]
[Serializable]
public readonly record struct ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus
    : IStringEnum
{
    public static readonly ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus LabelCreated =
        new(Values.LabelCreated);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus CarrierPossession =
        new(Values.CarrierPossession);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus InTransit =
        new(Values.InTransit);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus OutForDelivery =
        new(Values.OutForDelivery);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus Delivered =
        new(Values.Delivered);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus Delayed =
        new(Values.Delayed);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus DeliveryFailed =
        new(Values.DeliveryFailed);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus Returned =
        new(Values.Returned);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus Voided =
        new(Values.Voided);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus Unknown =
        new(Values.Unknown);

    public ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus(string value)
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
    public static ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus FromCustom(
        string value
    )
    {
        return new ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus(value);
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
        ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus value
    ) => value.Value;

    public static explicit operator ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus(
        string value
    ) => new(value);

    internal class ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatusSerializer
        : JsonConverter<ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus>
    {
        public override ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus Read(
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
            return new ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus ReadAsPropertyName(
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
            return new ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemShipmentsItemStatus value,
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
        public const string LabelCreated = "label_created";

        public const string CarrierPossession = "carrier_possession";

        public const string InTransit = "in_transit";

        public const string OutForDelivery = "out_for_delivery";

        public const string Delivered = "delivered";

        public const string Delayed = "delayed";

        public const string DeliveryFailed = "delivery_failed";

        public const string Returned = "returned";

        public const string Voided = "voided";

        public const string Unknown = "unknown";
    }
}
