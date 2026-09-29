using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListWebhookEndpointsResponseObject.ListWebhookEndpointsResponseObjectSerializer)
)]
[Serializable]
public readonly record struct ListWebhookEndpointsResponseObject : IStringEnum
{
    public static readonly ListWebhookEndpointsResponseObject List = new(Values.List);

    public ListWebhookEndpointsResponseObject(string value)
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
    public static ListWebhookEndpointsResponseObject FromCustom(string value)
    {
        return new ListWebhookEndpointsResponseObject(value);
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

    public static bool operator ==(ListWebhookEndpointsResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListWebhookEndpointsResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListWebhookEndpointsResponseObject value) => value.Value;

    public static explicit operator ListWebhookEndpointsResponseObject(string value) => new(value);

    internal class ListWebhookEndpointsResponseObjectSerializer
        : JsonConverter<ListWebhookEndpointsResponseObject>
    {
        public override ListWebhookEndpointsResponseObject Read(
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
            return new ListWebhookEndpointsResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListWebhookEndpointsResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListWebhookEndpointsResponseObject ReadAsPropertyName(
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
            return new ListWebhookEndpointsResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListWebhookEndpointsResponseObject value,
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
        public const string List = "list";
    }
}
