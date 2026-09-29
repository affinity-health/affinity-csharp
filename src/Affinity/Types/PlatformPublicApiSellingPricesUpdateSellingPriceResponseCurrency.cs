using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrency.PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrencySerializer)
)]
[Serializable]
public readonly record struct PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrency
    : IStringEnum
{
    public static readonly PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrency Usd =
        new(Values.Usd);

    public PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrency(string value)
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
    public static PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrency FromCustom(
        string value
    )
    {
        return new PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrency(value);
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
        PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrency value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrency value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrency value
    ) => value.Value;

    public static explicit operator PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrency(
        string value
    ) => new(value);

    internal class PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrencySerializer
        : JsonConverter<PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrency>
    {
        public override PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrency Read(
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
            return new PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrency(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrency value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrency ReadAsPropertyName(
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
            return new PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrency(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesUpdateSellingPriceResponseCurrency value,
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
