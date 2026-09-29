using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(DeleteWebhookEndpointResponseObject.DeleteWebhookEndpointResponseObjectSerializer)
)]
[Serializable]
public readonly record struct DeleteWebhookEndpointResponseObject : IStringEnum
{
    public static readonly DeleteWebhookEndpointResponseObject WebhookEndpoint = new(
        Values.WebhookEndpoint
    );

    public DeleteWebhookEndpointResponseObject(string value)
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
    public static DeleteWebhookEndpointResponseObject FromCustom(string value)
    {
        return new DeleteWebhookEndpointResponseObject(value);
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

    public static bool operator ==(DeleteWebhookEndpointResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DeleteWebhookEndpointResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DeleteWebhookEndpointResponseObject value) =>
        value.Value;

    public static explicit operator DeleteWebhookEndpointResponseObject(string value) => new(value);

    internal class DeleteWebhookEndpointResponseObjectSerializer
        : JsonConverter<DeleteWebhookEndpointResponseObject>
    {
        public override DeleteWebhookEndpointResponseObject Read(
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
            return new DeleteWebhookEndpointResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DeleteWebhookEndpointResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DeleteWebhookEndpointResponseObject ReadAsPropertyName(
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
            return new DeleteWebhookEndpointResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DeleteWebhookEndpointResponseObject value,
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
