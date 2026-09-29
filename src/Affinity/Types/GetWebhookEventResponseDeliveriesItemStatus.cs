using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetWebhookEventResponseDeliveriesItemStatus.GetWebhookEventResponseDeliveriesItemStatusSerializer)
)]
[Serializable]
public readonly record struct GetWebhookEventResponseDeliveriesItemStatus : IStringEnum
{
    public static readonly GetWebhookEventResponseDeliveriesItemStatus Delivered = new(
        Values.Delivered
    );

    public static readonly GetWebhookEventResponseDeliveriesItemStatus Failed = new(Values.Failed);

    public static readonly GetWebhookEventResponseDeliveriesItemStatus Pending = new(
        Values.Pending
    );

    public static readonly GetWebhookEventResponseDeliveriesItemStatus Retrying = new(
        Values.Retrying
    );

    public GetWebhookEventResponseDeliveriesItemStatus(string value)
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
    public static GetWebhookEventResponseDeliveriesItemStatus FromCustom(string value)
    {
        return new GetWebhookEventResponseDeliveriesItemStatus(value);
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
        GetWebhookEventResponseDeliveriesItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetWebhookEventResponseDeliveriesItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GetWebhookEventResponseDeliveriesItemStatus value) =>
        value.Value;

    public static explicit operator GetWebhookEventResponseDeliveriesItemStatus(string value) =>
        new(value);

    internal class GetWebhookEventResponseDeliveriesItemStatusSerializer
        : JsonConverter<GetWebhookEventResponseDeliveriesItemStatus>
    {
        public override GetWebhookEventResponseDeliveriesItemStatus Read(
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
            return new GetWebhookEventResponseDeliveriesItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetWebhookEventResponseDeliveriesItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetWebhookEventResponseDeliveriesItemStatus ReadAsPropertyName(
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
            return new GetWebhookEventResponseDeliveriesItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetWebhookEventResponseDeliveriesItemStatus value,
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

        public const string Retrying = "retrying";
    }
}
