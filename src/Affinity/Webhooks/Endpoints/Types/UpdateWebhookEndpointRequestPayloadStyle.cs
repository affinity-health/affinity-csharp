using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Webhooks;

[JsonConverter(
    typeof(UpdateWebhookEndpointRequestPayloadStyle.UpdateWebhookEndpointRequestPayloadStyleSerializer)
)]
[Serializable]
public readonly record struct UpdateWebhookEndpointRequestPayloadStyle : IStringEnum
{
    public static readonly UpdateWebhookEndpointRequestPayloadStyle Thin = new(Values.Thin);

    public static readonly UpdateWebhookEndpointRequestPayloadStyle Snapshot = new(Values.Snapshot);

    public UpdateWebhookEndpointRequestPayloadStyle(string value)
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
    public static UpdateWebhookEndpointRequestPayloadStyle FromCustom(string value)
    {
        return new UpdateWebhookEndpointRequestPayloadStyle(value);
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
        UpdateWebhookEndpointRequestPayloadStyle value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateWebhookEndpointRequestPayloadStyle value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UpdateWebhookEndpointRequestPayloadStyle value) =>
        value.Value;

    public static explicit operator UpdateWebhookEndpointRequestPayloadStyle(string value) =>
        new(value);

    internal class UpdateWebhookEndpointRequestPayloadStyleSerializer
        : JsonConverter<UpdateWebhookEndpointRequestPayloadStyle>
    {
        public override UpdateWebhookEndpointRequestPayloadStyle Read(
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
            return new UpdateWebhookEndpointRequestPayloadStyle(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateWebhookEndpointRequestPayloadStyle value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateWebhookEndpointRequestPayloadStyle ReadAsPropertyName(
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
            return new UpdateWebhookEndpointRequestPayloadStyle(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateWebhookEndpointRequestPayloadStyle value,
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
        public const string Thin = "thin";

        public const string Snapshot = "snapshot";
    }
}
