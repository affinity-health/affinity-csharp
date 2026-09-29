using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListWebhookGrantsResponseDataItemScopesItem.ListWebhookGrantsResponseDataItemScopesItemSerializer)
)]
[Serializable]
public readonly record struct ListWebhookGrantsResponseDataItemScopesItem : IStringEnum
{
    public static readonly ListWebhookGrantsResponseDataItemScopesItem WebhooksRead = new(
        Values.WebhooksRead
    );

    public static readonly ListWebhookGrantsResponseDataItemScopesItem WebhooksWrite = new(
        Values.WebhooksWrite
    );

    public ListWebhookGrantsResponseDataItemScopesItem(string value)
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
    public static ListWebhookGrantsResponseDataItemScopesItem FromCustom(string value)
    {
        return new ListWebhookGrantsResponseDataItemScopesItem(value);
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
        ListWebhookGrantsResponseDataItemScopesItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListWebhookGrantsResponseDataItemScopesItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListWebhookGrantsResponseDataItemScopesItem value) =>
        value.Value;

    public static explicit operator ListWebhookGrantsResponseDataItemScopesItem(string value) =>
        new(value);

    internal class ListWebhookGrantsResponseDataItemScopesItemSerializer
        : JsonConverter<ListWebhookGrantsResponseDataItemScopesItem>
    {
        public override ListWebhookGrantsResponseDataItemScopesItem Read(
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
            return new ListWebhookGrantsResponseDataItemScopesItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListWebhookGrantsResponseDataItemScopesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListWebhookGrantsResponseDataItemScopesItem ReadAsPropertyName(
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
            return new ListWebhookGrantsResponseDataItemScopesItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListWebhookGrantsResponseDataItemScopesItem value,
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
        public const string WebhooksRead = "webhooks:read";

        public const string WebhooksWrite = "webhooks:write";
    }
}
