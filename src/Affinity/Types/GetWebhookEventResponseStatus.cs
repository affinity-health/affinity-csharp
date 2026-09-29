using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(GetWebhookEventResponseStatus.GetWebhookEventResponseStatusSerializer))]
[Serializable]
public readonly record struct GetWebhookEventResponseStatus : IStringEnum
{
    public static readonly GetWebhookEventResponseStatus Delivered = new(Values.Delivered);

    public static readonly GetWebhookEventResponseStatus Failed = new(Values.Failed);

    public static readonly GetWebhookEventResponseStatus Pending = new(Values.Pending);

    public GetWebhookEventResponseStatus(string value)
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
    public static GetWebhookEventResponseStatus FromCustom(string value)
    {
        return new GetWebhookEventResponseStatus(value);
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

    public static bool operator ==(GetWebhookEventResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetWebhookEventResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetWebhookEventResponseStatus value) => value.Value;

    public static explicit operator GetWebhookEventResponseStatus(string value) => new(value);

    internal class GetWebhookEventResponseStatusSerializer
        : JsonConverter<GetWebhookEventResponseStatus>
    {
        public override GetWebhookEventResponseStatus Read(
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
            return new GetWebhookEventResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetWebhookEventResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetWebhookEventResponseStatus ReadAsPropertyName(
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
            return new GetWebhookEventResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetWebhookEventResponseStatus value,
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
