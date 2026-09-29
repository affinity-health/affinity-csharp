using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ReplayWebhookEventResponseAttemptsItemTrigger.ReplayWebhookEventResponseAttemptsItemTriggerSerializer)
)]
[Serializable]
public readonly record struct ReplayWebhookEventResponseAttemptsItemTrigger : IStringEnum
{
    public static readonly ReplayWebhookEventResponseAttemptsItemTrigger Automatic = new(
        Values.Automatic
    );

    public static readonly ReplayWebhookEventResponseAttemptsItemTrigger Manual = new(
        Values.Manual
    );

    public static readonly ReplayWebhookEventResponseAttemptsItemTrigger Test = new(Values.Test);

    public ReplayWebhookEventResponseAttemptsItemTrigger(string value)
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
    public static ReplayWebhookEventResponseAttemptsItemTrigger FromCustom(string value)
    {
        return new ReplayWebhookEventResponseAttemptsItemTrigger(value);
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
        ReplayWebhookEventResponseAttemptsItemTrigger value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReplayWebhookEventResponseAttemptsItemTrigger value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ReplayWebhookEventResponseAttemptsItemTrigger value) =>
        value.Value;

    public static explicit operator ReplayWebhookEventResponseAttemptsItemTrigger(string value) =>
        new(value);

    internal class ReplayWebhookEventResponseAttemptsItemTriggerSerializer
        : JsonConverter<ReplayWebhookEventResponseAttemptsItemTrigger>
    {
        public override ReplayWebhookEventResponseAttemptsItemTrigger Read(
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
            return new ReplayWebhookEventResponseAttemptsItemTrigger(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplayWebhookEventResponseAttemptsItemTrigger value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReplayWebhookEventResponseAttemptsItemTrigger ReadAsPropertyName(
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
            return new ReplayWebhookEventResponseAttemptsItemTrigger(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReplayWebhookEventResponseAttemptsItemTrigger value,
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
        public const string Automatic = "automatic";

        public const string Manual = "manual";

        public const string Test = "test";
    }
}
