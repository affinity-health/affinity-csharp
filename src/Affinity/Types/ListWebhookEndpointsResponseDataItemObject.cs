using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListWebhookEndpointsResponseDataItemObject.ListWebhookEndpointsResponseDataItemObjectSerializer)
)]
[Serializable]
public readonly record struct ListWebhookEndpointsResponseDataItemObject : IStringEnum
{
    public static readonly ListWebhookEndpointsResponseDataItemObject WebhookEndpoint = new(
        Values.WebhookEndpoint
    );

    public ListWebhookEndpointsResponseDataItemObject(string value)
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
    public static ListWebhookEndpointsResponseDataItemObject FromCustom(string value)
    {
        return new ListWebhookEndpointsResponseDataItemObject(value);
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
        ListWebhookEndpointsResponseDataItemObject value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListWebhookEndpointsResponseDataItemObject value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListWebhookEndpointsResponseDataItemObject value) =>
        value.Value;

    public static explicit operator ListWebhookEndpointsResponseDataItemObject(string value) =>
        new(value);

    internal class ListWebhookEndpointsResponseDataItemObjectSerializer
        : JsonConverter<ListWebhookEndpointsResponseDataItemObject>
    {
        public override ListWebhookEndpointsResponseDataItemObject Read(
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
            return new ListWebhookEndpointsResponseDataItemObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListWebhookEndpointsResponseDataItemObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListWebhookEndpointsResponseDataItemObject ReadAsPropertyName(
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
            return new ListWebhookEndpointsResponseDataItemObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListWebhookEndpointsResponseDataItemObject value,
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
        public const string WebhookEndpoint = "webhook_endpoint";
    }
}
