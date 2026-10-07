using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantity.PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantitySerializer)
)]
[Serializable]
public readonly record struct PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantity
    : IStringEnum
{
    public static readonly PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantity One =
        new(Values.One);

    public PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantity(
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
    public static PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantity FromCustom(
        string value
    )
    {
        return new PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantity(
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
        PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantity value
    ) => value.Value;

    public static explicit operator PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantity(
        string value
    ) => new(value);

    internal class PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantitySerializer
        : JsonConverter<PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantity>
    {
        public override PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantity Read(
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
            return new PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantity(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantity ReadAsPropertyName(
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
            return new PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantity(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadSellingPriceResponseAffinityBasisUnitQuantity value,
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
