using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListOrderEventsResponseDataItemObject.ListOrderEventsResponseDataItemObjectSerializer)
)]
[Serializable]
public readonly record struct ListOrderEventsResponseDataItemObject : IStringEnum
{
    public static readonly ListOrderEventsResponseDataItemObject Event = new(Values.Event);

    public ListOrderEventsResponseDataItemObject(string value)
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
    public static ListOrderEventsResponseDataItemObject FromCustom(string value)
    {
        return new ListOrderEventsResponseDataItemObject(value);
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

    public static bool operator ==(ListOrderEventsResponseDataItemObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListOrderEventsResponseDataItemObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListOrderEventsResponseDataItemObject value) =>
        value.Value;

    public static explicit operator ListOrderEventsResponseDataItemObject(string value) =>
        new(value);

    internal class ListOrderEventsResponseDataItemObjectSerializer
        : JsonConverter<ListOrderEventsResponseDataItemObject>
    {
        public override ListOrderEventsResponseDataItemObject Read(
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
            return new ListOrderEventsResponseDataItemObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrderEventsResponseDataItemObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrderEventsResponseDataItemObject ReadAsPropertyName(
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
            return new ListOrderEventsResponseDataItemObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrderEventsResponseDataItemObject value,
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
        public const string Event = "event";
    }
}
