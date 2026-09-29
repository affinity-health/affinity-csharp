using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantitySerializer)
)]
[Serializable]
public readonly record struct PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantity
    : IStringEnum
{
    public static readonly PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantity One =
        new(Values.One);

    public PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantity(string value)
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
    public static PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantity FromCustom(
        string value
    )
    {
        return new PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantity(value);
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
        PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantity value
    ) => value.Value;

    public static explicit operator PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantity(
        string value
    ) => new(value);

    internal class PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantitySerializer
        : JsonConverter<PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantity>
    {
        public override PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantity Read(
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
            return new PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantity(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantity ReadAsPropertyName(
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
            return new PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantity(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadSellingPriceResponseBasisUnitQuantity value,
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
