using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListWebhookEventsResponseUrl.ListWebhookEventsResponseUrlSerializer))]
[Serializable]
public readonly record struct ListWebhookEventsResponseUrl : IStringEnum
{
    public static readonly ListWebhookEventsResponseUrl V1WebhookEvents = new(
        Values.V1WebhookEvents
    );

    public ListWebhookEventsResponseUrl(string value)
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
    public static ListWebhookEventsResponseUrl FromCustom(string value)
    {
        return new ListWebhookEventsResponseUrl(value);
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

    public static bool operator ==(ListWebhookEventsResponseUrl value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListWebhookEventsResponseUrl value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListWebhookEventsResponseUrl value) => value.Value;

    public static explicit operator ListWebhookEventsResponseUrl(string value) => new(value);

    internal class ListWebhookEventsResponseUrlSerializer
        : JsonConverter<ListWebhookEventsResponseUrl>
    {
        public override ListWebhookEventsResponseUrl Read(
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
            return new ListWebhookEventsResponseUrl(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListWebhookEventsResponseUrl value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListWebhookEventsResponseUrl ReadAsPropertyName(
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
            return new ListWebhookEventsResponseUrl(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListWebhookEventsResponseUrl value,
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
        public const string V1WebhookEvents = "/v1/webhook-events";
    }
}
