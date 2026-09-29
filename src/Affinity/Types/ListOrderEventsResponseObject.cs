using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListOrderEventsResponseObject.ListOrderEventsResponseObjectSerializer))]
[Serializable]
public readonly record struct ListOrderEventsResponseObject : IStringEnum
{
    public static readonly ListOrderEventsResponseObject List = new(Values.List);

    public ListOrderEventsResponseObject(string value)
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
    public static ListOrderEventsResponseObject FromCustom(string value)
    {
        return new ListOrderEventsResponseObject(value);
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

    public static bool operator ==(ListOrderEventsResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListOrderEventsResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListOrderEventsResponseObject value) => value.Value;

    public static explicit operator ListOrderEventsResponseObject(string value) => new(value);

    internal class ListOrderEventsResponseObjectSerializer
        : JsonConverter<ListOrderEventsResponseObject>
    {
        public override ListOrderEventsResponseObject Read(
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
            return new ListOrderEventsResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrderEventsResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrderEventsResponseObject ReadAsPropertyName(
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
            return new ListOrderEventsResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrderEventsResponseObject value,
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
        public const string List = "list";
    }
}
