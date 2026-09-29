using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsRequestRoutesZero.ListCatalogItemsRequestRoutesZeroSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsRequestRoutesZero : IStringEnum
{
    public static readonly ListCatalogItemsRequestRoutesZero Injectable = new(Values.Injectable);

    public static readonly ListCatalogItemsRequestRoutesZero Nasal = new(Values.Nasal);

    public static readonly ListCatalogItemsRequestRoutesZero Oral = new(Values.Oral);

    public static readonly ListCatalogItemsRequestRoutesZero Sublingual = new(Values.Sublingual);

    public static readonly ListCatalogItemsRequestRoutesZero Topical = new(Values.Topical);

    public static readonly ListCatalogItemsRequestRoutesZero Unknown = new(Values.Unknown);

    public ListCatalogItemsRequestRoutesZero(string value)
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
    public static ListCatalogItemsRequestRoutesZero FromCustom(string value)
    {
        return new ListCatalogItemsRequestRoutesZero(value);
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

    public static bool operator ==(ListCatalogItemsRequestRoutesZero value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListCatalogItemsRequestRoutesZero value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListCatalogItemsRequestRoutesZero value) => value.Value;

    public static explicit operator ListCatalogItemsRequestRoutesZero(string value) => new(value);

    internal class ListCatalogItemsRequestRoutesZeroSerializer
        : JsonConverter<ListCatalogItemsRequestRoutesZero>
    {
        public override ListCatalogItemsRequestRoutesZero Read(
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
            return new ListCatalogItemsRequestRoutesZero(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsRequestRoutesZero value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsRequestRoutesZero ReadAsPropertyName(
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
            return new ListCatalogItemsRequestRoutesZero(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsRequestRoutesZero value,
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
        public const string Injectable = "injectable";

        public const string Nasal = "nasal";

        public const string Oral = "oral";

        public const string Sublingual = "sublingual";

        public const string Topical = "topical";

        public const string Unknown = "unknown";
    }
}
