using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListOrdersRequestRecentlyShipped.ListOrdersRequestRecentlyShippedSerializer))]
[Serializable]
public readonly record struct ListOrdersRequestRecentlyShipped : IStringEnum
{
    public static readonly ListOrdersRequestRecentlyShipped True = new(Values.True);

    public static readonly ListOrdersRequestRecentlyShipped False = new(Values.False);

    public ListOrdersRequestRecentlyShipped(string value)
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
    public static ListOrdersRequestRecentlyShipped FromCustom(string value)
    {
        return new ListOrdersRequestRecentlyShipped(value);
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

    public static bool operator ==(ListOrdersRequestRecentlyShipped value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListOrdersRequestRecentlyShipped value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListOrdersRequestRecentlyShipped value) => value.Value;

    public static explicit operator ListOrdersRequestRecentlyShipped(string value) => new(value);

    internal class ListOrdersRequestRecentlyShippedSerializer
        : JsonConverter<ListOrdersRequestRecentlyShipped>
    {
        public override ListOrdersRequestRecentlyShipped Read(
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
            return new ListOrdersRequestRecentlyShipped(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersRequestRecentlyShipped value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersRequestRecentlyShipped ReadAsPropertyName(
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
            return new ListOrdersRequestRecentlyShipped(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersRequestRecentlyShipped value,
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
        public const string True = "true";

        public const string False = "false";
    }
}
