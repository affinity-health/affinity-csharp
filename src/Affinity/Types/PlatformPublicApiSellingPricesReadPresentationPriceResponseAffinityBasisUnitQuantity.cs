using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantitySerializer)
)]
[Serializable]
public readonly record struct PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantity
    : IStringEnum
{
    public static readonly PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantity One =
        new(Values.One);

    public PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantity(
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
    public static PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantity FromCustom(
        string value
    )
    {
        return new PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantity(
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
        PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantity value
    ) => value.Value;

    public static explicit operator PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantity(
        string value
    ) => new(value);

    internal class PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantitySerializer
        : JsonConverter<PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantity>
    {
        public override PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantity Read(
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
            return new PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantity(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantity ReadAsPropertyName(
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
            return new PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantity(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisUnitQuantity value,
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
