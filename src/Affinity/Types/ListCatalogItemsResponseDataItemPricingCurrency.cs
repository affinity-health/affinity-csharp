using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemPricingCurrency.ListCatalogItemsResponseDataItemPricingCurrencySerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemPricingCurrency : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemPricingCurrency Usd = new(Values.Usd);

    public ListCatalogItemsResponseDataItemPricingCurrency(string value)
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
    public static ListCatalogItemsResponseDataItemPricingCurrency FromCustom(string value)
    {
        return new ListCatalogItemsResponseDataItemPricingCurrency(value);
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
        ListCatalogItemsResponseDataItemPricingCurrency value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemPricingCurrency value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListCatalogItemsResponseDataItemPricingCurrency value) =>
        value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemPricingCurrency(string value) =>
        new(value);

    internal class ListCatalogItemsResponseDataItemPricingCurrencySerializer
        : JsonConverter<ListCatalogItemsResponseDataItemPricingCurrency>
    {
        public override ListCatalogItemsResponseDataItemPricingCurrency Read(
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
            return new ListCatalogItemsResponseDataItemPricingCurrency(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPricingCurrency value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemPricingCurrency ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemPricingCurrency(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPricingCurrency value,
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
        public const string Usd = "USD";
    }
}
