using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListWebhookEndpointsResponseDataItemStatus.ListWebhookEndpointsResponseDataItemStatusSerializer)
)]
[Serializable]
public readonly record struct ListWebhookEndpointsResponseDataItemStatus : IStringEnum
{
    public static readonly ListWebhookEndpointsResponseDataItemStatus Active = new(Values.Active);

    public static readonly ListWebhookEndpointsResponseDataItemStatus Suspended = new(
        Values.Suspended
    );

    public static readonly ListWebhookEndpointsResponseDataItemStatus Disabled = new(
        Values.Disabled
    );

    public ListWebhookEndpointsResponseDataItemStatus(string value)
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
    public static ListWebhookEndpointsResponseDataItemStatus FromCustom(string value)
    {
        return new ListWebhookEndpointsResponseDataItemStatus(value);
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

    public static bool operator ==(
        ListWebhookEndpointsResponseDataItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListWebhookEndpointsResponseDataItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListWebhookEndpointsResponseDataItemStatus value) =>
        value.Value;

    public static explicit operator ListWebhookEndpointsResponseDataItemStatus(string value) =>
        new(value);

    internal class ListWebhookEndpointsResponseDataItemStatusSerializer
        : JsonConverter<ListWebhookEndpointsResponseDataItemStatus>
    {
        public override ListWebhookEndpointsResponseDataItemStatus Read(
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
            return new ListWebhookEndpointsResponseDataItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListWebhookEndpointsResponseDataItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListWebhookEndpointsResponseDataItemStatus ReadAsPropertyName(
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
            return new ListWebhookEndpointsResponseDataItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListWebhookEndpointsResponseDataItemStatus value,
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
        public const string Active = "active";

        public const string Suspended = "suspended";

        public const string Disabled = "disabled";
    }
}
