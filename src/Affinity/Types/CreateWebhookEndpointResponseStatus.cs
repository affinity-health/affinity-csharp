using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreateWebhookEndpointResponseStatus.CreateWebhookEndpointResponseStatusSerializer)
)]
[Serializable]
public readonly record struct CreateWebhookEndpointResponseStatus : IStringEnum
{
    public static readonly CreateWebhookEndpointResponseStatus Active = new(Values.Active);

    public static readonly CreateWebhookEndpointResponseStatus Suspended = new(Values.Suspended);

    public static readonly CreateWebhookEndpointResponseStatus Disabled = new(Values.Disabled);

    public CreateWebhookEndpointResponseStatus(string value)
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
    public static CreateWebhookEndpointResponseStatus FromCustom(string value)
    {
        return new CreateWebhookEndpointResponseStatus(value);
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

    public static bool operator ==(CreateWebhookEndpointResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateWebhookEndpointResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateWebhookEndpointResponseStatus value) =>
        value.Value;

    public static explicit operator CreateWebhookEndpointResponseStatus(string value) => new(value);

    internal class CreateWebhookEndpointResponseStatusSerializer
        : JsonConverter<CreateWebhookEndpointResponseStatus>
    {
        public override CreateWebhookEndpointResponseStatus Read(
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
            return new CreateWebhookEndpointResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateWebhookEndpointResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateWebhookEndpointResponseStatus ReadAsPropertyName(
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
            return new CreateWebhookEndpointResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateWebhookEndpointResponseStatus value,
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
        public const string Active = "active";

        public const string Suspended = "suspended";

        public const string Disabled = "disabled";
    }
}
