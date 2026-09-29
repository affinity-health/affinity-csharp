using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetOrderResponseFulfillmentsItemShippingMethod.GetOrderResponseFulfillmentsItemShippingMethodSerializer)
)]
[Serializable]
public readonly record struct GetOrderResponseFulfillmentsItemShippingMethod : IStringEnum
{
    public static readonly GetOrderResponseFulfillmentsItemShippingMethod Standard = new(
        Values.Standard
    );

    public static readonly GetOrderResponseFulfillmentsItemShippingMethod Expedited = new(
        Values.Expedited
    );

    public static readonly GetOrderResponseFulfillmentsItemShippingMethod Overnight = new(
        Values.Overnight
    );

    public static readonly GetOrderResponseFulfillmentsItemShippingMethod Pickup = new(
        Values.Pickup
    );

    public static readonly GetOrderResponseFulfillmentsItemShippingMethod LocalDelivery = new(
        Values.LocalDelivery
    );

    public GetOrderResponseFulfillmentsItemShippingMethod(string value)
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
    public static GetOrderResponseFulfillmentsItemShippingMethod FromCustom(string value)
    {
        return new GetOrderResponseFulfillmentsItemShippingMethod(value);
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
        GetOrderResponseFulfillmentsItemShippingMethod value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetOrderResponseFulfillmentsItemShippingMethod value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GetOrderResponseFulfillmentsItemShippingMethod value) =>
        value.Value;

    public static explicit operator GetOrderResponseFulfillmentsItemShippingMethod(string value) =>
        new(value);

    internal class GetOrderResponseFulfillmentsItemShippingMethodSerializer
        : JsonConverter<GetOrderResponseFulfillmentsItemShippingMethod>
    {
        public override GetOrderResponseFulfillmentsItemShippingMethod Read(
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
            return new GetOrderResponseFulfillmentsItemShippingMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrderResponseFulfillmentsItemShippingMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetOrderResponseFulfillmentsItemShippingMethod ReadAsPropertyName(
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
            return new GetOrderResponseFulfillmentsItemShippingMethod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrderResponseFulfillmentsItemShippingMethod value,
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
