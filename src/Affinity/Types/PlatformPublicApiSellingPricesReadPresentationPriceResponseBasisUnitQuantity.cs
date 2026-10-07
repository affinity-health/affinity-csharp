using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantity.PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantitySerializer)
)]
[Serializable]
public readonly record struct PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantity
    : IStringEnum
{
    public static readonly PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantity One =
        new(Values.One);

    public PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantity(
        string value
    )
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
    public static PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantity FromCustom(
        string value
    )
    {
        return new PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantity(
            value
        );
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
        PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantity value
    ) => value.Value;

    public static explicit operator PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantity(
        string value
    ) => new(value);

    internal class PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantitySerializer
        : JsonConverter<PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantity>
    {
        public override PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantity Read(
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
            return new PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantity(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantity ReadAsPropertyName(
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
            return new PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantity(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadPresentationPriceResponseBasisUnitQuantity value,
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
