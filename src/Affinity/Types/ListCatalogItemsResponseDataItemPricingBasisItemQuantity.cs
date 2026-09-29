using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemPricingBasisItemQuantity.ListCatalogItemsResponseDataItemPricingBasisItemQuantitySerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemPricingBasisItemQuantity : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemPricingBasisItemQuantity One = new(
        Values.One
    );

    public ListCatalogItemsResponseDataItemPricingBasisItemQuantity(string value)
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
    public static ListCatalogItemsResponseDataItemPricingBasisItemQuantity FromCustom(string value)
    {
        return new ListCatalogItemsResponseDataItemPricingBasisItemQuantity(value);
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
        ListCatalogItemsResponseDataItemPricingBasisItemQuantity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemPricingBasisItemQuantity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListCatalogItemsResponseDataItemPricingBasisItemQuantity value
    ) => value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemPricingBasisItemQuantity(
        string value
    ) => new(value);

    internal class ListCatalogItemsResponseDataItemPricingBasisItemQuantitySerializer
        : JsonConverter<ListCatalogItemsResponseDataItemPricingBasisItemQuantity>
    {
        public override ListCatalogItemsResponseDataItemPricingBasisItemQuantity Read(
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
            return new ListCatalogItemsResponseDataItemPricingBasisItemQuantity(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPricingBasisItemQuantity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemPricingBasisItemQuantity ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemPricingBasisItemQuantity(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPricingBasisItemQuantity value,
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
