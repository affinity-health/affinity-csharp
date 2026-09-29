using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Catalog;

[JsonConverter(typeof(ListItemsRequestCatalogKind.ListItemsRequestCatalogKindSerializer))]
[Serializable]
public readonly record struct ListItemsRequestCatalogKind : IStringEnum
{
    public static readonly ListItemsRequestCatalogKind Prescription = new(Values.Prescription);

    public static readonly ListItemsRequestCatalogKind Otc = new(Values.Otc);

    public ListItemsRequestCatalogKind(string value)
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
    public static ListItemsRequestCatalogKind FromCustom(string value)
    {
        return new ListItemsRequestCatalogKind(value);
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

    public static bool operator ==(ListItemsRequestCatalogKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListItemsRequestCatalogKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListItemsRequestCatalogKind value) => value.Value;

    public static explicit operator ListItemsRequestCatalogKind(string value) => new(value);

    internal class ListItemsRequestCatalogKindSerializer
        : JsonConverter<ListItemsRequestCatalogKind>
    {
        public override ListItemsRequestCatalogKind Read(
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
            return new ListItemsRequestCatalogKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListItemsRequestCatalogKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListItemsRequestCatalogKind ReadAsPropertyName(
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
            return new ListItemsRequestCatalogKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListItemsRequestCatalogKind value,
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
        public const string Prescription = "prescription";

        public const string Otc = "otc";
    }
}
