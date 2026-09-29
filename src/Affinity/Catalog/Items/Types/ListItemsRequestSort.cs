using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Catalog;

[JsonConverter(typeof(ListItemsRequestSort.ListItemsRequestSortSerializer))]
[Serializable]
public readonly record struct ListItemsRequestSort : IStringEnum
{
    public static readonly ListItemsRequestSort Relevance = new(Values.Relevance);

    public static readonly ListItemsRequestSort NameAsc = new(Values.NameAsc);

    public static readonly ListItemsRequestSort NameDesc = new(Values.NameDesc);

    public ListItemsRequestSort(string value)
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
    public static ListItemsRequestSort FromCustom(string value)
    {
        return new ListItemsRequestSort(value);
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

    public static bool operator ==(ListItemsRequestSort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListItemsRequestSort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListItemsRequestSort value) => value.Value;

    public static explicit operator ListItemsRequestSort(string value) => new(value);

    internal class ListItemsRequestSortSerializer : JsonConverter<ListItemsRequestSort>
    {
        public override ListItemsRequestSort Read(
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
            return new ListItemsRequestSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListItemsRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListItemsRequestSort ReadAsPropertyName(
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
            return new ListItemsRequestSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListItemsRequestSort value,
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
        public const string Relevance = "relevance";

        public const string NameAsc = "name_asc";

        public const string NameDesc = "name_desc";
    }
}
