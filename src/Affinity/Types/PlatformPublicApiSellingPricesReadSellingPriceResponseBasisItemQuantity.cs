using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantity.PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantitySerializer)
)]
[Serializable]
public readonly record struct PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantity
    : IStringEnum
{
    public static readonly PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantity One =
        new(Values.One);

    public PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantity(string value)
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
    public static PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantity FromCustom(
        string value
    )
    {
        return new PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantity(value);
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
        PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantity value
    ) => value.Value;

    public static explicit operator PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantity(
        string value
    ) => new(value);

    internal class PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantitySerializer
        : JsonConverter<PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantity>
    {
        public override PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantity Read(
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
            return new PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantity(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantity ReadAsPropertyName(
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
            return new PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantity(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadSellingPriceResponseBasisItemQuantity value,
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
