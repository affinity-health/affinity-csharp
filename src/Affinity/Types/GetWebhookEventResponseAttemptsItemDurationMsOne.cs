using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetWebhookEventResponseAttemptsItemDurationMsOne.GetWebhookEventResponseAttemptsItemDurationMsOneSerializer)
)]
[Serializable]
public readonly record struct GetWebhookEventResponseAttemptsItemDurationMsOne : IStringEnum
{
    public static readonly GetWebhookEventResponseAttemptsItemDurationMsOne Infinity = new(
        Values.Infinity
    );

    public static readonly GetWebhookEventResponseAttemptsItemDurationMsOne NaN = new(Values.NaN);

    public GetWebhookEventResponseAttemptsItemDurationMsOne(string value)
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
    public static GetWebhookEventResponseAttemptsItemDurationMsOne FromCustom(string value)
    {
        return new GetWebhookEventResponseAttemptsItemDurationMsOne(value);
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
        GetWebhookEventResponseAttemptsItemDurationMsOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetWebhookEventResponseAttemptsItemDurationMsOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetWebhookEventResponseAttemptsItemDurationMsOne value
    ) => value.Value;

    public static explicit operator GetWebhookEventResponseAttemptsItemDurationMsOne(
        string value
    ) => new(value);

    internal class GetWebhookEventResponseAttemptsItemDurationMsOneSerializer
        : JsonConverter<GetWebhookEventResponseAttemptsItemDurationMsOne>
    {
        public override GetWebhookEventResponseAttemptsItemDurationMsOne Read(
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
            return new GetWebhookEventResponseAttemptsItemDurationMsOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetWebhookEventResponseAttemptsItemDurationMsOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetWebhookEventResponseAttemptsItemDurationMsOne ReadAsPropertyName(
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
            return new GetWebhookEventResponseAttemptsItemDurationMsOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetWebhookEventResponseAttemptsItemDurationMsOne value,
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
