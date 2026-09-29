using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListCatalogItemsResponseUrl.ListCatalogItemsResponseUrlSerializer))]
[Serializable]
public readonly record struct ListCatalogItemsResponseUrl : IStringEnum
{
    public static readonly ListCatalogItemsResponseUrl V1CatalogItems = new(Values.V1CatalogItems);

    public ListCatalogItemsResponseUrl(string value)
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
    public static ListCatalogItemsResponseUrl FromCustom(string value)
    {
        return new ListCatalogItemsResponseUrl(value);
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

    public static bool operator ==(ListCatalogItemsResponseUrl value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListCatalogItemsResponseUrl value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListCatalogItemsResponseUrl value) => value.Value;

    public static explicit operator ListCatalogItemsResponseUrl(string value) => new(value);

    internal class ListCatalogItemsResponseUrlSerializer
        : JsonConverter<ListCatalogItemsResponseUrl>
    {
        public override ListCatalogItemsResponseUrl Read(
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
            return new ListCatalogItemsResponseUrl(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseUrl value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseUrl ReadAsPropertyName(
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
            return new ListCatalogItemsResponseUrl(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseUrl value,
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
        public const string V1CatalogItems = "/v1/catalog/items";
    }
}
