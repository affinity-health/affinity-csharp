using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CancelOrderResponseFulfillmentsItemShippingOptionCurrency.CancelOrderResponseFulfillmentsItemShippingOptionCurrencySerializer)
)]
[Serializable]
public readonly record struct CancelOrderResponseFulfillmentsItemShippingOptionCurrency
    : IStringEnum
{
    public static readonly CancelOrderResponseFulfillmentsItemShippingOptionCurrency Usd = new(
        Values.Usd
    );

    public CancelOrderResponseFulfillmentsItemShippingOptionCurrency(string value)
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
    public static CancelOrderResponseFulfillmentsItemShippingOptionCurrency FromCustom(string value)
    {
        return new CancelOrderResponseFulfillmentsItemShippingOptionCurrency(value);
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
        CancelOrderResponseFulfillmentsItemShippingOptionCurrency value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CancelOrderResponseFulfillmentsItemShippingOptionCurrency value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CancelOrderResponseFulfillmentsItemShippingOptionCurrency value
    ) => value.Value;

    public static explicit operator CancelOrderResponseFulfillmentsItemShippingOptionCurrency(
        string value
    ) => new(value);

    internal class CancelOrderResponseFulfillmentsItemShippingOptionCurrencySerializer
        : JsonConverter<CancelOrderResponseFulfillmentsItemShippingOptionCurrency>
    {
        public override CancelOrderResponseFulfillmentsItemShippingOptionCurrency Read(
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
            return new CancelOrderResponseFulfillmentsItemShippingOptionCurrency(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelOrderResponseFulfillmentsItemShippingOptionCurrency value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelOrderResponseFulfillmentsItemShippingOptionCurrency ReadAsPropertyName(
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
            return new CancelOrderResponseFulfillmentsItemShippingOptionCurrency(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelOrderResponseFulfillmentsItemShippingOptionCurrency value,
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
        public const string Usd = "USD";
    }
}
