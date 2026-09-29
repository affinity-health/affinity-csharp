using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantity.PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantitySerializer)
)]
[Serializable]
public readonly record struct PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantity
    : IStringEnum
{
    public static readonly PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantity One =
        new(Values.One);

    public PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantity(string value)
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
    public static PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantity FromCustom(
        string value
    )
    {
        return new PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantity(value);
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
        PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantity value
    ) => value.Value;

    public static explicit operator PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantity(
        string value
    ) => new(value);

    internal class PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantitySerializer
        : JsonConverter<PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantity>
    {
        public override PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantity Read(
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
            return new PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantity(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantity ReadAsPropertyName(
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
            return new PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantity(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesUpdateSellingPriceResponseBasisUnitQuantity value,
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
