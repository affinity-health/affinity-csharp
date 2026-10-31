using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListOrdersRequestCancelRequested.ListOrdersRequestCancelRequestedSerializer))]
[Serializable]
public readonly record struct ListOrdersRequestCancelRequested : IStringEnum
{
    public static readonly ListOrdersRequestCancelRequested True = new(Values.True);

    public static readonly ListOrdersRequestCancelRequested False = new(Values.False);

    public ListOrdersRequestCancelRequested(string value)
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
    public static ListOrdersRequestCancelRequested FromCustom(string value)
    {
        return new ListOrdersRequestCancelRequested(value);
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

    public static bool operator ==(ListOrdersRequestCancelRequested value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListOrdersRequestCancelRequested value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListOrdersRequestCancelRequested value) => value.Value;

    public static explicit operator ListOrdersRequestCancelRequested(string value) => new(value);

    internal class ListOrdersRequestCancelRequestedSerializer
        : JsonConverter<ListOrdersRequestCancelRequested>
    {
        public override ListOrdersRequestCancelRequested Read(
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
            return new ListOrdersRequestCancelRequested(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersRequestCancelRequested value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersRequestCancelRequested ReadAsPropertyName(
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
            return new ListOrdersRequestCancelRequested(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersRequestCancelRequested value,
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
