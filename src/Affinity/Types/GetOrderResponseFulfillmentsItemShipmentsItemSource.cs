using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetOrderResponseFulfillmentsItemShipmentsItemSource.GetOrderResponseFulfillmentsItemShipmentsItemSourceSerializer)
)]
[Serializable]
public readonly record struct GetOrderResponseFulfillmentsItemShipmentsItemSource : IStringEnum
{
    public static readonly GetOrderResponseFulfillmentsItemShipmentsItemSource PharmacyWebhook =
        new(Values.PharmacyWebhook);

    public static readonly GetOrderResponseFulfillmentsItemShipmentsItemSource Pharmacy = new(
        Values.Pharmacy
    );

    public static readonly GetOrderResponseFulfillmentsItemShipmentsItemSource System = new(
        Values.System
    );

    public GetOrderResponseFulfillmentsItemShipmentsItemSource(string value)
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
    public static GetOrderResponseFulfillmentsItemShipmentsItemSource FromCustom(string value)
    {
        return new GetOrderResponseFulfillmentsItemShipmentsItemSource(value);
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
        GetOrderResponseFulfillmentsItemShipmentsItemSource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetOrderResponseFulfillmentsItemShipmentsItemSource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetOrderResponseFulfillmentsItemShipmentsItemSource value
    ) => value.Value;

    public static explicit operator GetOrderResponseFulfillmentsItemShipmentsItemSource(
        string value
    ) => new(value);

    internal class GetOrderResponseFulfillmentsItemShipmentsItemSourceSerializer
        : JsonConverter<GetOrderResponseFulfillmentsItemShipmentsItemSource>
    {
        public override GetOrderResponseFulfillmentsItemShipmentsItemSource Read(
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
            return new GetOrderResponseFulfillmentsItemShipmentsItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrderResponseFulfillmentsItemShipmentsItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetOrderResponseFulfillmentsItemShipmentsItemSource ReadAsPropertyName(
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
            return new GetOrderResponseFulfillmentsItemShipmentsItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrderResponseFulfillmentsItemShipmentsItemSource value,
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
