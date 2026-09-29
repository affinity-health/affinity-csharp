using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListWebhookEventsResponseDataItemObject.ListWebhookEventsResponseDataItemObjectSerializer)
)]
[Serializable]
public readonly record struct ListWebhookEventsResponseDataItemObject : IStringEnum
{
    public static readonly ListWebhookEventsResponseDataItemObject WebhookEvent = new(
        Values.WebhookEvent
    );

    public ListWebhookEventsResponseDataItemObject(string value)
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
    public static ListWebhookEventsResponseDataItemObject FromCustom(string value)
    {
        return new ListWebhookEventsResponseDataItemObject(value);
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

    public static bool operator ==(ListWebhookEventsResponseDataItemObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListWebhookEventsResponseDataItemObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListWebhookEventsResponseDataItemObject value) =>
        value.Value;

    public static explicit operator ListWebhookEventsResponseDataItemObject(string value) =>
        new(value);

    internal class ListWebhookEventsResponseDataItemObjectSerializer
        : JsonConverter<ListWebhookEventsResponseDataItemObject>
    {
        public override ListWebhookEventsResponseDataItemObject Read(
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
            return new ListWebhookEventsResponseDataItemObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListWebhookEventsResponseDataItemObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListWebhookEventsResponseDataItemObject ReadAsPropertyName(
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
            return new ListWebhookEventsResponseDataItemObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListWebhookEventsResponseDataItemObject value,
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
        public const string WebhookEvent = "webhook_event";
    }
}
