using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListWebhookEventsResponseDataItemStatus.ListWebhookEventsResponseDataItemStatusSerializer)
)]
[Serializable]
public readonly record struct ListWebhookEventsResponseDataItemStatus : IStringEnum
{
    public static readonly ListWebhookEventsResponseDataItemStatus Delivered = new(
        Values.Delivered
    );

    public static readonly ListWebhookEventsResponseDataItemStatus Failed = new(Values.Failed);

    public static readonly ListWebhookEventsResponseDataItemStatus Pending = new(Values.Pending);

    public ListWebhookEventsResponseDataItemStatus(string value)
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
    public static ListWebhookEventsResponseDataItemStatus FromCustom(string value)
    {
        return new ListWebhookEventsResponseDataItemStatus(value);
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

    public static bool operator ==(ListWebhookEventsResponseDataItemStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListWebhookEventsResponseDataItemStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListWebhookEventsResponseDataItemStatus value) =>
        value.Value;

    public static explicit operator ListWebhookEventsResponseDataItemStatus(string value) =>
        new(value);

    internal class ListWebhookEventsResponseDataItemStatusSerializer
        : JsonConverter<ListWebhookEventsResponseDataItemStatus>
    {
        public override ListWebhookEventsResponseDataItemStatus Read(
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
            return new ListWebhookEventsResponseDataItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListWebhookEventsResponseDataItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListWebhookEventsResponseDataItemStatus ReadAsPropertyName(
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
            return new ListWebhookEventsResponseDataItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListWebhookEventsResponseDataItemStatus value,
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
        public const string Delivered = "delivered";

        public const string Failed = "failed";

        public const string Pending = "pending";
    }
}
