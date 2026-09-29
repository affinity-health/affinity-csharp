using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne.GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOneSerializer)
)]
[Serializable]
public readonly record struct GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne
    : IStringEnum
{
    public static readonly GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne Infinity =
        new(Values.Infinity);

    public static readonly GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne NaN = new(
        Values.NaN
    );

    public GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne(string value)
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
    public static GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne FromCustom(
        string value
    )
    {
        return new GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne(value);
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
        GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne value
    ) => value.Value;

    public static explicit operator GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne(
        string value
    ) => new(value);

    internal class GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOneSerializer
        : JsonConverter<GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne>
    {
        public override GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne Read(
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
            return new GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne ReadAsPropertyName(
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
            return new GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetWebhookEventResponseDeliveriesItemAutomaticAttemptCountOne value,
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
        public const string Infinity = "Infinity";

        public const string NaN = "NaN";
    }
}
