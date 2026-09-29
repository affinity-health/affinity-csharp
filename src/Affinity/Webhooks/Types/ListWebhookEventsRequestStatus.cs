using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListWebhookEventsRequestStatus.ListWebhookEventsRequestStatusSerializer))]
[Serializable]
public readonly record struct ListWebhookEventsRequestStatus : IStringEnum
{
    public static readonly ListWebhookEventsRequestStatus All = new(Values.All);

    public static readonly ListWebhookEventsRequestStatus Delivered = new(Values.Delivered);

    public static readonly ListWebhookEventsRequestStatus Failed = new(Values.Failed);

    public static readonly ListWebhookEventsRequestStatus Pending = new(Values.Pending);

    public ListWebhookEventsRequestStatus(string value)
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
    public static ListWebhookEventsRequestStatus FromCustom(string value)
    {
        return new ListWebhookEventsRequestStatus(value);
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

    public static bool operator ==(ListWebhookEventsRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListWebhookEventsRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListWebhookEventsRequestStatus value) => value.Value;

    public static explicit operator ListWebhookEventsRequestStatus(string value) => new(value);

    internal class ListWebhookEventsRequestStatusSerializer
        : JsonConverter<ListWebhookEventsRequestStatus>
    {
        public override ListWebhookEventsRequestStatus Read(
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
            return new ListWebhookEventsRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListWebhookEventsRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListWebhookEventsRequestStatus ReadAsPropertyName(
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
            return new ListWebhookEventsRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListWebhookEventsRequestStatus value,
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
        public const string All = "all";

        public const string Delivered = "delivered";

        public const string Failed = "failed";

        public const string Pending = "pending";
    }
}
