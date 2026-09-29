using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CancelOrderResponseFulfillmentsItemShippingMethod.CancelOrderResponseFulfillmentsItemShippingMethodSerializer)
)]
[Serializable]
public readonly record struct CancelOrderResponseFulfillmentsItemShippingMethod : IStringEnum
{
    public static readonly CancelOrderResponseFulfillmentsItemShippingMethod Standard = new(
        Values.Standard
    );

    public static readonly CancelOrderResponseFulfillmentsItemShippingMethod Expedited = new(
        Values.Expedited
    );

    public static readonly CancelOrderResponseFulfillmentsItemShippingMethod Overnight = new(
        Values.Overnight
    );

    public static readonly CancelOrderResponseFulfillmentsItemShippingMethod Pickup = new(
        Values.Pickup
    );

    public static readonly CancelOrderResponseFulfillmentsItemShippingMethod LocalDelivery = new(
        Values.LocalDelivery
    );

    public CancelOrderResponseFulfillmentsItemShippingMethod(string value)
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
    public static CancelOrderResponseFulfillmentsItemShippingMethod FromCustom(string value)
    {
        return new CancelOrderResponseFulfillmentsItemShippingMethod(value);
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
        CancelOrderResponseFulfillmentsItemShippingMethod value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CancelOrderResponseFulfillmentsItemShippingMethod value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CancelOrderResponseFulfillmentsItemShippingMethod value
    ) => value.Value;

    public static explicit operator CancelOrderResponseFulfillmentsItemShippingMethod(
        string value
    ) => new(value);

    internal class CancelOrderResponseFulfillmentsItemShippingMethodSerializer
        : JsonConverter<CancelOrderResponseFulfillmentsItemShippingMethod>
    {
        public override CancelOrderResponseFulfillmentsItemShippingMethod Read(
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
            return new CancelOrderResponseFulfillmentsItemShippingMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelOrderResponseFulfillmentsItemShippingMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelOrderResponseFulfillmentsItemShippingMethod ReadAsPropertyName(
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
            return new CancelOrderResponseFulfillmentsItemShippingMethod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelOrderResponseFulfillmentsItemShippingMethod value,
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
