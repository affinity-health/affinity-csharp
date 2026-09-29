using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CancelOrderResponseFulfillmentsItemShipmentsItemStatus.CancelOrderResponseFulfillmentsItemShipmentsItemStatusSerializer)
)]
[Serializable]
public readonly record struct CancelOrderResponseFulfillmentsItemShipmentsItemStatus : IStringEnum
{
    public static readonly CancelOrderResponseFulfillmentsItemShipmentsItemStatus LabelCreated =
        new(Values.LabelCreated);

    public static readonly CancelOrderResponseFulfillmentsItemShipmentsItemStatus CarrierPossession =
        new(Values.CarrierPossession);

    public static readonly CancelOrderResponseFulfillmentsItemShipmentsItemStatus InTransit = new(
        Values.InTransit
    );

    public static readonly CancelOrderResponseFulfillmentsItemShipmentsItemStatus OutForDelivery =
        new(Values.OutForDelivery);

    public static readonly CancelOrderResponseFulfillmentsItemShipmentsItemStatus Delivered = new(
        Values.Delivered
    );

    public static readonly CancelOrderResponseFulfillmentsItemShipmentsItemStatus Delayed = new(
        Values.Delayed
    );

    public static readonly CancelOrderResponseFulfillmentsItemShipmentsItemStatus DeliveryFailed =
        new(Values.DeliveryFailed);

    public static readonly CancelOrderResponseFulfillmentsItemShipmentsItemStatus Returned = new(
        Values.Returned
    );

    public static readonly CancelOrderResponseFulfillmentsItemShipmentsItemStatus Voided = new(
        Values.Voided
    );

    public static readonly CancelOrderResponseFulfillmentsItemShipmentsItemStatus Unknown = new(
        Values.Unknown
    );

    public CancelOrderResponseFulfillmentsItemShipmentsItemStatus(string value)
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
    public static CancelOrderResponseFulfillmentsItemShipmentsItemStatus FromCustom(string value)
    {
        return new CancelOrderResponseFulfillmentsItemShipmentsItemStatus(value);
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
        CancelOrderResponseFulfillmentsItemShipmentsItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CancelOrderResponseFulfillmentsItemShipmentsItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CancelOrderResponseFulfillmentsItemShipmentsItemStatus value
    ) => value.Value;

    public static explicit operator CancelOrderResponseFulfillmentsItemShipmentsItemStatus(
        string value
    ) => new(value);

    internal class CancelOrderResponseFulfillmentsItemShipmentsItemStatusSerializer
        : JsonConverter<CancelOrderResponseFulfillmentsItemShipmentsItemStatus>
    {
        public override CancelOrderResponseFulfillmentsItemShipmentsItemStatus Read(
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
            return new CancelOrderResponseFulfillmentsItemShipmentsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelOrderResponseFulfillmentsItemShipmentsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelOrderResponseFulfillmentsItemShipmentsItemStatus ReadAsPropertyName(
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
            return new CancelOrderResponseFulfillmentsItemShipmentsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelOrderResponseFulfillmentsItemShipmentsItemStatus value,
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
