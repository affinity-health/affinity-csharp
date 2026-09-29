using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListWebhookGrantsResponseObject.ListWebhookGrantsResponseObjectSerializer))]
[Serializable]
public readonly record struct ListWebhookGrantsResponseObject : IStringEnum
{
    public static readonly ListWebhookGrantsResponseObject List = new(Values.List);

    public ListWebhookGrantsResponseObject(string value)
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
    public static ListWebhookGrantsResponseObject FromCustom(string value)
    {
        return new ListWebhookGrantsResponseObject(value);
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

    public static bool operator ==(ListWebhookGrantsResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListWebhookGrantsResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListWebhookGrantsResponseObject value) => value.Value;

    public static explicit operator ListWebhookGrantsResponseObject(string value) => new(value);

    internal class ListWebhookGrantsResponseObjectSerializer
        : JsonConverter<ListWebhookGrantsResponseObject>
    {
        public override ListWebhookGrantsResponseObject Read(
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
            return new ListWebhookGrantsResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListWebhookGrantsResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListWebhookGrantsResponseObject ReadAsPropertyName(
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
            return new ListWebhookGrantsResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListWebhookGrantsResponseObject value,
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
