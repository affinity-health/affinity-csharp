using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListOrdersRequestSort.ListOrdersRequestSortSerializer))]
[Serializable]
public readonly record struct ListOrdersRequestSort : IStringEnum
{
    public static readonly ListOrdersRequestSort Newest = new(Values.Newest);

    public static readonly ListOrdersRequestSort Oldest = new(Values.Oldest);

    public ListOrdersRequestSort(string value)
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
    public static ListOrdersRequestSort FromCustom(string value)
    {
        return new ListOrdersRequestSort(value);
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

    public static bool operator ==(ListOrdersRequestSort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListOrdersRequestSort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListOrdersRequestSort value) => value.Value;

    public static explicit operator ListOrdersRequestSort(string value) => new(value);

    internal class ListOrdersRequestSortSerializer : JsonConverter<ListOrdersRequestSort>
    {
        public override ListOrdersRequestSort Read(
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
            return new ListOrdersRequestSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersRequestSort ReadAsPropertyName(
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
            return new ListOrdersRequestSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersRequestSort value,
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
        public const string Newest = "newest";

        public const string Oldest = "oldest";
    }
}
