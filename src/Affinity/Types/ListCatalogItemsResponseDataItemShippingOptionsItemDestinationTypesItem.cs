using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem.ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItemSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem
    : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem Patient =
        new(Values.Patient);

    public static readonly ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem Practice =
        new(Values.Practice);

    public ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem(string value)
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
    public static ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem FromCustom(
        string value
    )
    {
        return new ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem(value);
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
        ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem value
    ) => value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem(
        string value
    ) => new(value);

    internal class ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItemSerializer
        : JsonConverter<ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem>
    {
        public override ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem Read(
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
            return new ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemShippingOptionsItemDestinationTypesItem value,
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
        public const string Patient = "patient";

        public const string Practice = "practice";
    }
}
