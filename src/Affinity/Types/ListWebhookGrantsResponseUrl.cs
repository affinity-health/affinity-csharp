using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListWebhookGrantsResponseUrl.ListWebhookGrantsResponseUrlSerializer))]
[Serializable]
public readonly record struct ListWebhookGrantsResponseUrl : IStringEnum
{
    public static readonly ListWebhookGrantsResponseUrl V1WebhookGrants = new(
        Values.V1WebhookGrants
    );

    public ListWebhookGrantsResponseUrl(string value)
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
    public static ListWebhookGrantsResponseUrl FromCustom(string value)
    {
        return new ListWebhookGrantsResponseUrl(value);
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

    public static bool operator ==(ListWebhookGrantsResponseUrl value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListWebhookGrantsResponseUrl value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListWebhookGrantsResponseUrl value) => value.Value;

    public static explicit operator ListWebhookGrantsResponseUrl(string value) => new(value);

    internal class ListWebhookGrantsResponseUrlSerializer
        : JsonConverter<ListWebhookGrantsResponseUrl>
    {
        public override ListWebhookGrantsResponseUrl Read(
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
            return new ListWebhookGrantsResponseUrl(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListWebhookGrantsResponseUrl value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListWebhookGrantsResponseUrl ReadAsPropertyName(
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
            return new ListWebhookGrantsResponseUrl(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListWebhookGrantsResponseUrl value,
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
        public const string V1WebhookGrants = "/v1/webhook-grants";
    }
}
