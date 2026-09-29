using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RotateWebhookEndpointSecretResponsePayloadStyle.RotateWebhookEndpointSecretResponsePayloadStyleSerializer)
)]
[Serializable]
public readonly record struct RotateWebhookEndpointSecretResponsePayloadStyle : IStringEnum
{
    public static readonly RotateWebhookEndpointSecretResponsePayloadStyle Thin = new(Values.Thin);

    public static readonly RotateWebhookEndpointSecretResponsePayloadStyle Snapshot = new(
        Values.Snapshot
    );

    public RotateWebhookEndpointSecretResponsePayloadStyle(string value)
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
    public static RotateWebhookEndpointSecretResponsePayloadStyle FromCustom(string value)
    {
        return new RotateWebhookEndpointSecretResponsePayloadStyle(value);
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
        RotateWebhookEndpointSecretResponsePayloadStyle value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RotateWebhookEndpointSecretResponsePayloadStyle value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(RotateWebhookEndpointSecretResponsePayloadStyle value) =>
        value.Value;

    public static explicit operator RotateWebhookEndpointSecretResponsePayloadStyle(string value) =>
        new(value);

    internal class RotateWebhookEndpointSecretResponsePayloadStyleSerializer
        : JsonConverter<RotateWebhookEndpointSecretResponsePayloadStyle>
    {
        public override RotateWebhookEndpointSecretResponsePayloadStyle Read(
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
            return new RotateWebhookEndpointSecretResponsePayloadStyle(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RotateWebhookEndpointSecretResponsePayloadStyle value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RotateWebhookEndpointSecretResponsePayloadStyle ReadAsPropertyName(
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
            return new RotateWebhookEndpointSecretResponsePayloadStyle(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RotateWebhookEndpointSecretResponsePayloadStyle value,
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
