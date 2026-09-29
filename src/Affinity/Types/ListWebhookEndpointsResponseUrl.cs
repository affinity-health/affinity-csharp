using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListWebhookEndpointsResponseUrl.ListWebhookEndpointsResponseUrlSerializer))]
[Serializable]
public readonly record struct ListWebhookEndpointsResponseUrl : IStringEnum
{
    public static readonly ListWebhookEndpointsResponseUrl V1WebhookEndpoints = new(
        Values.V1WebhookEndpoints
    );

    public ListWebhookEndpointsResponseUrl(string value)
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
    public static ListWebhookEndpointsResponseUrl FromCustom(string value)
    {
        return new ListWebhookEndpointsResponseUrl(value);
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

    public static bool operator ==(ListWebhookEndpointsResponseUrl value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListWebhookEndpointsResponseUrl value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListWebhookEndpointsResponseUrl value) => value.Value;

    public static explicit operator ListWebhookEndpointsResponseUrl(string value) => new(value);

    internal class ListWebhookEndpointsResponseUrlSerializer
        : JsonConverter<ListWebhookEndpointsResponseUrl>
    {
        public override ListWebhookEndpointsResponseUrl Read(
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
            return new ListWebhookEndpointsResponseUrl(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListWebhookEndpointsResponseUrl value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListWebhookEndpointsResponseUrl ReadAsPropertyName(
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
            return new ListWebhookEndpointsResponseUrl(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListWebhookEndpointsResponseUrl value,
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
        public const string V1WebhookEndpoints = "/v1/webhook-endpoints";
    }
}
