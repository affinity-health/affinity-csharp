using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem.ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItemSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem
    : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem Ambient =
        new(Values.Ambient);

    public static readonly ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem Refrigerated =
        new(Values.Refrigerated);

    public ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem(string value)
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
    public static ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem FromCustom(
        string value
    )
    {
        return new ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem(value);
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
        ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem value
    ) => value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem(
        string value
    ) => new(value);

    internal class ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItemSerializer
        : JsonConverter<ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem>
    {
        public override ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem Read(
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
            return new ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemShippingOptionsItemTemperaturesItem value,
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
        public const string Ambient = "ambient";

        public const string Refrigerated = "refrigerated";
    }
}
