using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListWebhookEndpointsResponseDataItemPayloadStyle.ListWebhookEndpointsResponseDataItemPayloadStyleSerializer)
)]
[Serializable]
public readonly record struct ListWebhookEndpointsResponseDataItemPayloadStyle : IStringEnum
{
    public static readonly ListWebhookEndpointsResponseDataItemPayloadStyle Thin = new(Values.Thin);

    public static readonly ListWebhookEndpointsResponseDataItemPayloadStyle Snapshot = new(
        Values.Snapshot
    );

    public ListWebhookEndpointsResponseDataItemPayloadStyle(string value)
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
    public static ListWebhookEndpointsResponseDataItemPayloadStyle FromCustom(string value)
    {
        return new ListWebhookEndpointsResponseDataItemPayloadStyle(value);
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
        ListWebhookEndpointsResponseDataItemPayloadStyle value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListWebhookEndpointsResponseDataItemPayloadStyle value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListWebhookEndpointsResponseDataItemPayloadStyle value
    ) => value.Value;

    public static explicit operator ListWebhookEndpointsResponseDataItemPayloadStyle(
        string value
    ) => new(value);

    internal class ListWebhookEndpointsResponseDataItemPayloadStyleSerializer
        : JsonConverter<ListWebhookEndpointsResponseDataItemPayloadStyle>
    {
        public override ListWebhookEndpointsResponseDataItemPayloadStyle Read(
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
            return new ListWebhookEndpointsResponseDataItemPayloadStyle(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListWebhookEndpointsResponseDataItemPayloadStyle value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListWebhookEndpointsResponseDataItemPayloadStyle ReadAsPropertyName(
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
            return new ListWebhookEndpointsResponseDataItemPayloadStyle(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListWebhookEndpointsResponseDataItemPayloadStyle value,
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
