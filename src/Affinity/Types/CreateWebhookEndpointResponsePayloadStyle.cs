using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreateWebhookEndpointResponsePayloadStyle.CreateWebhookEndpointResponsePayloadStyleSerializer)
)]
[Serializable]
public readonly record struct CreateWebhookEndpointResponsePayloadStyle : IStringEnum
{
    public static readonly CreateWebhookEndpointResponsePayloadStyle Thin = new(Values.Thin);

    public static readonly CreateWebhookEndpointResponsePayloadStyle Snapshot = new(
        Values.Snapshot
    );

    public CreateWebhookEndpointResponsePayloadStyle(string value)
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
    public static CreateWebhookEndpointResponsePayloadStyle FromCustom(string value)
    {
        return new CreateWebhookEndpointResponsePayloadStyle(value);
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
        CreateWebhookEndpointResponsePayloadStyle value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateWebhookEndpointResponsePayloadStyle value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateWebhookEndpointResponsePayloadStyle value) =>
        value.Value;

    public static explicit operator CreateWebhookEndpointResponsePayloadStyle(string value) =>
        new(value);

    internal class CreateWebhookEndpointResponsePayloadStyleSerializer
        : JsonConverter<CreateWebhookEndpointResponsePayloadStyle>
    {
        public override CreateWebhookEndpointResponsePayloadStyle Read(
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
            return new CreateWebhookEndpointResponsePayloadStyle(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateWebhookEndpointResponsePayloadStyle value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateWebhookEndpointResponsePayloadStyle ReadAsPropertyName(
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
            return new CreateWebhookEndpointResponsePayloadStyle(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateWebhookEndpointResponsePayloadStyle value,
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
