using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetWebhookEventResponseAttemptsItemResponseStatusOne.GetWebhookEventResponseAttemptsItemResponseStatusOneSerializer)
)]
[Serializable]
public readonly record struct GetWebhookEventResponseAttemptsItemResponseStatusOne : IStringEnum
{
    public static readonly GetWebhookEventResponseAttemptsItemResponseStatusOne Infinity = new(
        Values.Infinity
    );

    public static readonly GetWebhookEventResponseAttemptsItemResponseStatusOne NaN = new(
        Values.NaN
    );

    public GetWebhookEventResponseAttemptsItemResponseStatusOne(string value)
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
    public static GetWebhookEventResponseAttemptsItemResponseStatusOne FromCustom(string value)
    {
        return new GetWebhookEventResponseAttemptsItemResponseStatusOne(value);
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
        GetWebhookEventResponseAttemptsItemResponseStatusOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetWebhookEventResponseAttemptsItemResponseStatusOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetWebhookEventResponseAttemptsItemResponseStatusOne value
    ) => value.Value;

    public static explicit operator GetWebhookEventResponseAttemptsItemResponseStatusOne(
        string value
    ) => new(value);

    internal class GetWebhookEventResponseAttemptsItemResponseStatusOneSerializer
        : JsonConverter<GetWebhookEventResponseAttemptsItemResponseStatusOne>
    {
        public override GetWebhookEventResponseAttemptsItemResponseStatusOne Read(
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
            return new GetWebhookEventResponseAttemptsItemResponseStatusOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetWebhookEventResponseAttemptsItemResponseStatusOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetWebhookEventResponseAttemptsItemResponseStatusOne ReadAsPropertyName(
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
            return new GetWebhookEventResponseAttemptsItemResponseStatusOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetWebhookEventResponseAttemptsItemResponseStatusOne value,
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
