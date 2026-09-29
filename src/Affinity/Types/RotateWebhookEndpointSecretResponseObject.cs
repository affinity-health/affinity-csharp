using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RotateWebhookEndpointSecretResponseObject.RotateWebhookEndpointSecretResponseObjectSerializer)
)]
[Serializable]
public readonly record struct RotateWebhookEndpointSecretResponseObject : IStringEnum
{
    public static readonly RotateWebhookEndpointSecretResponseObject WebhookEndpoint = new(
        Values.WebhookEndpoint
    );

    public RotateWebhookEndpointSecretResponseObject(string value)
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
    public static RotateWebhookEndpointSecretResponseObject FromCustom(string value)
    {
        return new RotateWebhookEndpointSecretResponseObject(value);
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
        RotateWebhookEndpointSecretResponseObject value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RotateWebhookEndpointSecretResponseObject value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(RotateWebhookEndpointSecretResponseObject value) =>
        value.Value;

    public static explicit operator RotateWebhookEndpointSecretResponseObject(string value) =>
        new(value);

    internal class RotateWebhookEndpointSecretResponseObjectSerializer
        : JsonConverter<RotateWebhookEndpointSecretResponseObject>
    {
        public override RotateWebhookEndpointSecretResponseObject Read(
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
            return new RotateWebhookEndpointSecretResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RotateWebhookEndpointSecretResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RotateWebhookEndpointSecretResponseObject ReadAsPropertyName(
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
            return new RotateWebhookEndpointSecretResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RotateWebhookEndpointSecretResponseObject value,
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
