using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantitySerializer)
)]
[Serializable]
public readonly record struct PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantity
    : IStringEnum
{
    public static readonly PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantity One =
        new(Values.One);

    public PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantity(string value)
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
    public static PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantity FromCustom(
        string value
    )
    {
        return new PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantity(value);
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
        PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantity value
    ) => value.Value;

    public static explicit operator PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantity(
        string value
    ) => new(value);

    internal class PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantitySerializer
        : JsonConverter<PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantity>
    {
        public override PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantity Read(
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
            return new PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantity(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantity ReadAsPropertyName(
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
            return new PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantity(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisItemQuantity value,
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
        public const string One = "1";
    }
}
