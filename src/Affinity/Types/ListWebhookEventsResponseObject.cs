using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListWebhookEventsResponseObject.ListWebhookEventsResponseObjectSerializer))]
[Serializable]
public readonly record struct ListWebhookEventsResponseObject : IStringEnum
{
    public static readonly ListWebhookEventsResponseObject List = new(Values.List);

    public ListWebhookEventsResponseObject(string value)
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
    public static ListWebhookEventsResponseObject FromCustom(string value)
    {
        return new ListWebhookEventsResponseObject(value);
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

    public static bool operator ==(ListWebhookEventsResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListWebhookEventsResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListWebhookEventsResponseObject value) => value.Value;

    public static explicit operator ListWebhookEventsResponseObject(string value) => new(value);

    internal class ListWebhookEventsResponseObjectSerializer
        : JsonConverter<ListWebhookEventsResponseObject>
    {
        public override ListWebhookEventsResponseObject Read(
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
            return new ListWebhookEventsResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListWebhookEventsResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListWebhookEventsResponseObject ReadAsPropertyName(
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
            return new ListWebhookEventsResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListWebhookEventsResponseObject value,
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
