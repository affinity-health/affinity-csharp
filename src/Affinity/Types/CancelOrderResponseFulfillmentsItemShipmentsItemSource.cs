using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CancelOrderResponseFulfillmentsItemShipmentsItemSource.CancelOrderResponseFulfillmentsItemShipmentsItemSourceSerializer)
)]
[Serializable]
public readonly record struct CancelOrderResponseFulfillmentsItemShipmentsItemSource : IStringEnum
{
    public static readonly CancelOrderResponseFulfillmentsItemShipmentsItemSource PharmacyWebhook =
        new(Values.PharmacyWebhook);

    public static readonly CancelOrderResponseFulfillmentsItemShipmentsItemSource Pharmacy = new(
        Values.Pharmacy
    );

    public static readonly CancelOrderResponseFulfillmentsItemShipmentsItemSource System = new(
        Values.System
    );

    public CancelOrderResponseFulfillmentsItemShipmentsItemSource(string value)
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
    public static CancelOrderResponseFulfillmentsItemShipmentsItemSource FromCustom(string value)
    {
        return new CancelOrderResponseFulfillmentsItemShipmentsItemSource(value);
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
        CancelOrderResponseFulfillmentsItemShipmentsItemSource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CancelOrderResponseFulfillmentsItemShipmentsItemSource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CancelOrderResponseFulfillmentsItemShipmentsItemSource value
    ) => value.Value;

    public static explicit operator CancelOrderResponseFulfillmentsItemShipmentsItemSource(
        string value
    ) => new(value);

    internal class CancelOrderResponseFulfillmentsItemShipmentsItemSourceSerializer
        : JsonConverter<CancelOrderResponseFulfillmentsItemShipmentsItemSource>
    {
        public override CancelOrderResponseFulfillmentsItemShipmentsItemSource Read(
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
            return new CancelOrderResponseFulfillmentsItemShipmentsItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelOrderResponseFulfillmentsItemShipmentsItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelOrderResponseFulfillmentsItemShipmentsItemSource ReadAsPropertyName(
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
            return new CancelOrderResponseFulfillmentsItemShipmentsItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelOrderResponseFulfillmentsItemShipmentsItemSource value,
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
