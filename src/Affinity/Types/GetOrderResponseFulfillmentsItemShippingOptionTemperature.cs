using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetOrderResponseFulfillmentsItemShippingOptionTemperature.GetOrderResponseFulfillmentsItemShippingOptionTemperatureSerializer)
)]
[Serializable]
public readonly record struct GetOrderResponseFulfillmentsItemShippingOptionTemperature
    : IStringEnum
{
    public static readonly GetOrderResponseFulfillmentsItemShippingOptionTemperature Ambient = new(
        Values.Ambient
    );

    public static readonly GetOrderResponseFulfillmentsItemShippingOptionTemperature Refrigerated =
        new(Values.Refrigerated);

    public GetOrderResponseFulfillmentsItemShippingOptionTemperature(string value)
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
    public static GetOrderResponseFulfillmentsItemShippingOptionTemperature FromCustom(string value)
    {
        return new GetOrderResponseFulfillmentsItemShippingOptionTemperature(value);
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
        GetOrderResponseFulfillmentsItemShippingOptionTemperature value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetOrderResponseFulfillmentsItemShippingOptionTemperature value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetOrderResponseFulfillmentsItemShippingOptionTemperature value
    ) => value.Value;

    public static explicit operator GetOrderResponseFulfillmentsItemShippingOptionTemperature(
        string value
    ) => new(value);

    internal class GetOrderResponseFulfillmentsItemShippingOptionTemperatureSerializer
        : JsonConverter<GetOrderResponseFulfillmentsItemShippingOptionTemperature>
    {
        public override GetOrderResponseFulfillmentsItemShippingOptionTemperature Read(
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
            return new GetOrderResponseFulfillmentsItemShippingOptionTemperature(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrderResponseFulfillmentsItemShippingOptionTemperature value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetOrderResponseFulfillmentsItemShippingOptionTemperature ReadAsPropertyName(
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
            return new GetOrderResponseFulfillmentsItemShippingOptionTemperature(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrderResponseFulfillmentsItemShippingOptionTemperature value,
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
