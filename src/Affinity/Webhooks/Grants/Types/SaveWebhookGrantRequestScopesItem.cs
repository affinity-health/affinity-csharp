using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Webhooks;

[JsonConverter(
    typeof(SaveWebhookGrantRequestScopesItem.SaveWebhookGrantRequestScopesItemSerializer)
)]
[Serializable]
public readonly record struct SaveWebhookGrantRequestScopesItem : IStringEnum
{
    public static readonly SaveWebhookGrantRequestScopesItem WebhooksRead = new(
        Values.WebhooksRead
    );

    public static readonly SaveWebhookGrantRequestScopesItem WebhooksWrite = new(
        Values.WebhooksWrite
    );

    public SaveWebhookGrantRequestScopesItem(string value)
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
    public static SaveWebhookGrantRequestScopesItem FromCustom(string value)
    {
        return new SaveWebhookGrantRequestScopesItem(value);
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

    public static bool operator ==(SaveWebhookGrantRequestScopesItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SaveWebhookGrantRequestScopesItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SaveWebhookGrantRequestScopesItem value) => value.Value;

    public static explicit operator SaveWebhookGrantRequestScopesItem(string value) => new(value);

    internal class SaveWebhookGrantRequestScopesItemSerializer
        : JsonConverter<SaveWebhookGrantRequestScopesItem>
    {
        public override SaveWebhookGrantRequestScopesItem Read(
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
            return new SaveWebhookGrantRequestScopesItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SaveWebhookGrantRequestScopesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SaveWebhookGrantRequestScopesItem ReadAsPropertyName(
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
            return new SaveWebhookGrantRequestScopesItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SaveWebhookGrantRequestScopesItem value,
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
