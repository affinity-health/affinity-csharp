using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponent.ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponentSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponent
    : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponent Shipping =
        new(Values.Shipping);

    public ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponent(string value)
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
    public static ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponent FromCustom(
        string value
    )
    {
        return new ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponent(value);
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
        ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponent value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponent value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponent value
    ) => value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponent(
        string value
    ) => new(value);

    internal class ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponentSerializer
        : JsonConverter<ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponent>
    {
        public override ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponent Read(
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
            return new ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponent(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponent value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponent ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponent(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemFulfillmentInclusionsItemPriceComponent value,
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
        public const string Shipping = "shipping";
    }
}
