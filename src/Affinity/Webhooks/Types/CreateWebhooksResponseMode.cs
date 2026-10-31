using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(CreateWebhooksResponseMode.CreateWebhooksResponseModeSerializer))]
[Serializable]
public readonly record struct CreateWebhooksResponseMode : IStringEnum
{
    public static readonly CreateWebhooksResponseMode Test = new(Values.Test);

    public static readonly CreateWebhooksResponseMode Live = new(Values.Live);

    public CreateWebhooksResponseMode(string value)
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
    public static CreateWebhooksResponseMode FromCustom(string value)
    {
        return new CreateWebhooksResponseMode(value);
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

    public static bool operator ==(CreateWebhooksResponseMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateWebhooksResponseMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateWebhooksResponseMode value) => value.Value;

    public static explicit operator CreateWebhooksResponseMode(string value) => new(value);

    internal class CreateWebhooksResponseModeSerializer : JsonConverter<CreateWebhooksResponseMode>
    {
        public override CreateWebhooksResponseMode Read(
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
            return new CreateWebhooksResponseMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateWebhooksResponseMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateWebhooksResponseMode ReadAsPropertyName(
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
            return new CreateWebhooksResponseMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateWebhooksResponseMode value,
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
        public const string Test = "test";

        public const string Live = "live";
    }
}
