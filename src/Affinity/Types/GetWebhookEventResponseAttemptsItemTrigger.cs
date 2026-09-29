using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetWebhookEventResponseAttemptsItemTrigger.GetWebhookEventResponseAttemptsItemTriggerSerializer)
)]
[Serializable]
public readonly record struct GetWebhookEventResponseAttemptsItemTrigger : IStringEnum
{
    public static readonly GetWebhookEventResponseAttemptsItemTrigger Automatic = new(
        Values.Automatic
    );

    public static readonly GetWebhookEventResponseAttemptsItemTrigger Manual = new(Values.Manual);

    public static readonly GetWebhookEventResponseAttemptsItemTrigger Test = new(Values.Test);

    public GetWebhookEventResponseAttemptsItemTrigger(string value)
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
    public static GetWebhookEventResponseAttemptsItemTrigger FromCustom(string value)
    {
        return new GetWebhookEventResponseAttemptsItemTrigger(value);
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
        GetWebhookEventResponseAttemptsItemTrigger value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetWebhookEventResponseAttemptsItemTrigger value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GetWebhookEventResponseAttemptsItemTrigger value) =>
        value.Value;

    public static explicit operator GetWebhookEventResponseAttemptsItemTrigger(string value) =>
        new(value);

    internal class GetWebhookEventResponseAttemptsItemTriggerSerializer
        : JsonConverter<GetWebhookEventResponseAttemptsItemTrigger>
    {
        public override GetWebhookEventResponseAttemptsItemTrigger Read(
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
            return new GetWebhookEventResponseAttemptsItemTrigger(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetWebhookEventResponseAttemptsItemTrigger value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetWebhookEventResponseAttemptsItemTrigger ReadAsPropertyName(
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
            return new GetWebhookEventResponseAttemptsItemTrigger(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetWebhookEventResponseAttemptsItemTrigger value,
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
