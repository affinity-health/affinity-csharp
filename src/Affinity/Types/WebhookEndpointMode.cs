using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(WebhookEndpointMode.WebhookEndpointModeSerializer))]
[Serializable]
public readonly record struct WebhookEndpointMode : IStringEnum
{
    public static readonly WebhookEndpointMode Test = new(Values.Test);

    public static readonly WebhookEndpointMode Live = new(Values.Live);

    public WebhookEndpointMode(string value)
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
    public static WebhookEndpointMode FromCustom(string value)
    {
        return new WebhookEndpointMode(value);
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

    public static bool operator ==(WebhookEndpointMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookEndpointMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookEndpointMode value) => value.Value;

    public static explicit operator WebhookEndpointMode(string value) => new(value);

    internal class WebhookEndpointModeSerializer : JsonConverter<WebhookEndpointMode>
    {
        public override WebhookEndpointMode Read(
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
            return new WebhookEndpointMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookEndpointMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebhookEndpointMode ReadAsPropertyName(
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
            return new WebhookEndpointMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookEndpointMode value,
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
        public const string Test = "test";

        public const string Live = "live";
    }
}
