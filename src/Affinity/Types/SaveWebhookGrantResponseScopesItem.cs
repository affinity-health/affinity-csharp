using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(SaveWebhookGrantResponseScopesItem.SaveWebhookGrantResponseScopesItemSerializer)
)]
[Serializable]
public readonly record struct SaveWebhookGrantResponseScopesItem : IStringEnum
{
    public static readonly SaveWebhookGrantResponseScopesItem WebhooksRead = new(
        Values.WebhooksRead
    );

    public static readonly SaveWebhookGrantResponseScopesItem WebhooksWrite = new(
        Values.WebhooksWrite
    );

    public SaveWebhookGrantResponseScopesItem(string value)
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
    public static SaveWebhookGrantResponseScopesItem FromCustom(string value)
    {
        return new SaveWebhookGrantResponseScopesItem(value);
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

    public static bool operator ==(SaveWebhookGrantResponseScopesItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SaveWebhookGrantResponseScopesItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SaveWebhookGrantResponseScopesItem value) => value.Value;

    public static explicit operator SaveWebhookGrantResponseScopesItem(string value) => new(value);

    internal class SaveWebhookGrantResponseScopesItemSerializer
        : JsonConverter<SaveWebhookGrantResponseScopesItem>
    {
        public override SaveWebhookGrantResponseScopesItem Read(
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
            return new SaveWebhookGrantResponseScopesItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SaveWebhookGrantResponseScopesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SaveWebhookGrantResponseScopesItem ReadAsPropertyName(
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
            return new SaveWebhookGrantResponseScopesItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SaveWebhookGrantResponseScopesItem value,
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
