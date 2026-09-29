using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Webhooks;

[JsonConverter(
    typeof(CreateWebhookEndpointRequestPayloadStyle.CreateWebhookEndpointRequestPayloadStyleSerializer)
)]
[Serializable]
public readonly record struct CreateWebhookEndpointRequestPayloadStyle : IStringEnum
{
    public static readonly CreateWebhookEndpointRequestPayloadStyle Thin = new(Values.Thin);

    public static readonly CreateWebhookEndpointRequestPayloadStyle Snapshot = new(Values.Snapshot);

    public CreateWebhookEndpointRequestPayloadStyle(string value)
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
    public static CreateWebhookEndpointRequestPayloadStyle FromCustom(string value)
    {
        return new CreateWebhookEndpointRequestPayloadStyle(value);
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
        CreateWebhookEndpointRequestPayloadStyle value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateWebhookEndpointRequestPayloadStyle value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateWebhookEndpointRequestPayloadStyle value) =>
        value.Value;

    public static explicit operator CreateWebhookEndpointRequestPayloadStyle(string value) =>
        new(value);

    internal class CreateWebhookEndpointRequestPayloadStyleSerializer
        : JsonConverter<CreateWebhookEndpointRequestPayloadStyle>
    {
        public override CreateWebhookEndpointRequestPayloadStyle Read(
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
            return new CreateWebhookEndpointRequestPayloadStyle(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateWebhookEndpointRequestPayloadStyle value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateWebhookEndpointRequestPayloadStyle ReadAsPropertyName(
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
            return new CreateWebhookEndpointRequestPayloadStyle(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateWebhookEndpointRequestPayloadStyle value,
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
