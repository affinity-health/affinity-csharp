using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(UpdateWebhookEndpointResponsePayloadStyle.UpdateWebhookEndpointResponsePayloadStyleSerializer)
)]
[Serializable]
public readonly record struct UpdateWebhookEndpointResponsePayloadStyle : IStringEnum
{
    public static readonly UpdateWebhookEndpointResponsePayloadStyle Thin = new(Values.Thin);

    public static readonly UpdateWebhookEndpointResponsePayloadStyle Snapshot = new(
        Values.Snapshot
    );

    public UpdateWebhookEndpointResponsePayloadStyle(string value)
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
    public static UpdateWebhookEndpointResponsePayloadStyle FromCustom(string value)
    {
        return new UpdateWebhookEndpointResponsePayloadStyle(value);
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
        UpdateWebhookEndpointResponsePayloadStyle value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateWebhookEndpointResponsePayloadStyle value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UpdateWebhookEndpointResponsePayloadStyle value) =>
        value.Value;

    public static explicit operator UpdateWebhookEndpointResponsePayloadStyle(string value) =>
        new(value);

    internal class UpdateWebhookEndpointResponsePayloadStyleSerializer
        : JsonConverter<UpdateWebhookEndpointResponsePayloadStyle>
    {
        public override UpdateWebhookEndpointResponsePayloadStyle Read(
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
            return new UpdateWebhookEndpointResponsePayloadStyle(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateWebhookEndpointResponsePayloadStyle value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateWebhookEndpointResponsePayloadStyle ReadAsPropertyName(
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
            return new UpdateWebhookEndpointResponsePayloadStyle(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateWebhookEndpointResponsePayloadStyle value,
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
