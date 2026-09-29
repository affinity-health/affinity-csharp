using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetOrderResponseFulfillmentsItemShipmentsItemStatus.GetOrderResponseFulfillmentsItemShipmentsItemStatusSerializer)
)]
[Serializable]
public readonly record struct GetOrderResponseFulfillmentsItemShipmentsItemStatus : IStringEnum
{
    public static readonly GetOrderResponseFulfillmentsItemShipmentsItemStatus LabelCreated = new(
        Values.LabelCreated
    );

    public static readonly GetOrderResponseFulfillmentsItemShipmentsItemStatus CarrierPossession =
        new(Values.CarrierPossession);

    public static readonly GetOrderResponseFulfillmentsItemShipmentsItemStatus InTransit = new(
        Values.InTransit
    );

    public static readonly GetOrderResponseFulfillmentsItemShipmentsItemStatus OutForDelivery = new(
        Values.OutForDelivery
    );

    public static readonly GetOrderResponseFulfillmentsItemShipmentsItemStatus Delivered = new(
        Values.Delivered
    );

    public static readonly GetOrderResponseFulfillmentsItemShipmentsItemStatus Delayed = new(
        Values.Delayed
    );

    public static readonly GetOrderResponseFulfillmentsItemShipmentsItemStatus DeliveryFailed = new(
        Values.DeliveryFailed
    );

    public static readonly GetOrderResponseFulfillmentsItemShipmentsItemStatus Returned = new(
        Values.Returned
    );

    public static readonly GetOrderResponseFulfillmentsItemShipmentsItemStatus Voided = new(
        Values.Voided
    );

    public static readonly GetOrderResponseFulfillmentsItemShipmentsItemStatus Unknown = new(
        Values.Unknown
    );

    public GetOrderResponseFulfillmentsItemShipmentsItemStatus(string value)
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
    public static GetOrderResponseFulfillmentsItemShipmentsItemStatus FromCustom(string value)
    {
        return new GetOrderResponseFulfillmentsItemShipmentsItemStatus(value);
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
        GetOrderResponseFulfillmentsItemShipmentsItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetOrderResponseFulfillmentsItemShipmentsItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetOrderResponseFulfillmentsItemShipmentsItemStatus value
    ) => value.Value;

    public static explicit operator GetOrderResponseFulfillmentsItemShipmentsItemStatus(
        string value
    ) => new(value);

    internal class GetOrderResponseFulfillmentsItemShipmentsItemStatusSerializer
        : JsonConverter<GetOrderResponseFulfillmentsItemShipmentsItemStatus>
    {
        public override GetOrderResponseFulfillmentsItemShipmentsItemStatus Read(
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
            return new GetOrderResponseFulfillmentsItemShipmentsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrderResponseFulfillmentsItemShipmentsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetOrderResponseFulfillmentsItemShipmentsItemStatus ReadAsPropertyName(
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
            return new GetOrderResponseFulfillmentsItemShipmentsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrderResponseFulfillmentsItemShipmentsItemStatus value,
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
