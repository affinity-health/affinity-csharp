using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ReplayWebhookEventResponseStatus.ReplayWebhookEventResponseStatusSerializer))]
[Serializable]
public readonly record struct ReplayWebhookEventResponseStatus : IStringEnum
{
    public static readonly ReplayWebhookEventResponseStatus Delivered = new(Values.Delivered);

    public static readonly ReplayWebhookEventResponseStatus Failed = new(Values.Failed);

    public static readonly ReplayWebhookEventResponseStatus Pending = new(Values.Pending);

    public ReplayWebhookEventResponseStatus(string value)
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
    public static ReplayWebhookEventResponseStatus FromCustom(string value)
    {
        return new ReplayWebhookEventResponseStatus(value);
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

    public static bool operator ==(ReplayWebhookEventResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReplayWebhookEventResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReplayWebhookEventResponseStatus value) => value.Value;

    public static explicit operator ReplayWebhookEventResponseStatus(string value) => new(value);

    internal class ReplayWebhookEventResponseStatusSerializer
        : JsonConverter<ReplayWebhookEventResponseStatus>
    {
        public override ReplayWebhookEventResponseStatus Read(
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
            return new ReplayWebhookEventResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplayWebhookEventResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReplayWebhookEventResponseStatus ReadAsPropertyName(
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
            return new ReplayWebhookEventResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReplayWebhookEventResponseStatus value,
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
        public const string Delivered = "delivered";

        public const string Failed = "failed";

        public const string Pending = "pending";
    }
}
