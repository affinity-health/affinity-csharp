using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemPricingBasisUnitQuantity.ListCatalogItemsResponseDataItemPricingBasisUnitQuantitySerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemPricingBasisUnitQuantity : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemPricingBasisUnitQuantity One = new(
        Values.One
    );

    public ListCatalogItemsResponseDataItemPricingBasisUnitQuantity(string value)
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
    public static ListCatalogItemsResponseDataItemPricingBasisUnitQuantity FromCustom(string value)
    {
        return new ListCatalogItemsResponseDataItemPricingBasisUnitQuantity(value);
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
        ListCatalogItemsResponseDataItemPricingBasisUnitQuantity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemPricingBasisUnitQuantity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListCatalogItemsResponseDataItemPricingBasisUnitQuantity value
    ) => value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemPricingBasisUnitQuantity(
        string value
    ) => new(value);

    internal class ListCatalogItemsResponseDataItemPricingBasisUnitQuantitySerializer
        : JsonConverter<ListCatalogItemsResponseDataItemPricingBasisUnitQuantity>
    {
        public override ListCatalogItemsResponseDataItemPricingBasisUnitQuantity Read(
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
            return new ListCatalogItemsResponseDataItemPricingBasisUnitQuantity(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPricingBasisUnitQuantity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemPricingBasisUnitQuantity ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemPricingBasisUnitQuantity(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPricingBasisUnitQuantity value,
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
