using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(DeleteWebhookEndpointResponseStatus.DeleteWebhookEndpointResponseStatusSerializer)
)]
[Serializable]
public readonly record struct DeleteWebhookEndpointResponseStatus : IStringEnum
{
    public static readonly DeleteWebhookEndpointResponseStatus Active = new(Values.Active);

    public static readonly DeleteWebhookEndpointResponseStatus Suspended = new(Values.Suspended);

    public static readonly DeleteWebhookEndpointResponseStatus Disabled = new(Values.Disabled);

    public DeleteWebhookEndpointResponseStatus(string value)
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
    public static DeleteWebhookEndpointResponseStatus FromCustom(string value)
    {
        return new DeleteWebhookEndpointResponseStatus(value);
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

    public static bool operator ==(DeleteWebhookEndpointResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DeleteWebhookEndpointResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DeleteWebhookEndpointResponseStatus value) =>
        value.Value;

    public static explicit operator DeleteWebhookEndpointResponseStatus(string value) => new(value);

    internal class DeleteWebhookEndpointResponseStatusSerializer
        : JsonConverter<DeleteWebhookEndpointResponseStatus>
    {
        public override DeleteWebhookEndpointResponseStatus Read(
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
            return new DeleteWebhookEndpointResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DeleteWebhookEndpointResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DeleteWebhookEndpointResponseStatus ReadAsPropertyName(
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
            return new DeleteWebhookEndpointResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DeleteWebhookEndpointResponseStatus value,
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
