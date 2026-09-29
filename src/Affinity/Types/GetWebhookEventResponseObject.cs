using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(GetWebhookEventResponseObject.GetWebhookEventResponseObjectSerializer))]
[Serializable]
public readonly record struct GetWebhookEventResponseObject : IStringEnum
{
    public static readonly GetWebhookEventResponseObject WebhookEvent = new(Values.WebhookEvent);

    public GetWebhookEventResponseObject(string value)
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
    public static GetWebhookEventResponseObject FromCustom(string value)
    {
        return new GetWebhookEventResponseObject(value);
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

    public static bool operator ==(GetWebhookEventResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetWebhookEventResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetWebhookEventResponseObject value) => value.Value;

    public static explicit operator GetWebhookEventResponseObject(string value) => new(value);

    internal class GetWebhookEventResponseObjectSerializer
        : JsonConverter<GetWebhookEventResponseObject>
    {
        public override GetWebhookEventResponseObject Read(
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
            return new GetWebhookEventResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetWebhookEventResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetWebhookEventResponseObject ReadAsPropertyName(
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
            return new GetWebhookEventResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetWebhookEventResponseObject value,
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
        public const string WebhookEvent = "webhook_event";
    }
}
