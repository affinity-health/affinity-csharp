using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantity.PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantitySerializer)
)]
[Serializable]
public readonly record struct PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantity
    : IStringEnum
{
    public static readonly PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantity One =
        new(Values.One);

    public PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantity(
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
    public static PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantity FromCustom(
        string value
    )
    {
        return new PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantity(
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
        PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantity value
    ) => value.Value;

    public static explicit operator PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantity(
        string value
    ) => new(value);

    internal class PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantitySerializer
        : JsonConverter<PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantity>
    {
        public override PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantity Read(
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
            return new PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantity(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantity ReadAsPropertyName(
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
            return new PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantity(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlatformPublicApiSellingPricesReadPresentationPriceResponseAffinityBasisItemQuantity value,
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
