using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(CreateOrderResponseStatus.CreateOrderResponseStatusSerializer))]
[Serializable]
public readonly record struct CreateOrderResponseStatus : IStringEnum
{
    public static readonly CreateOrderResponseStatus RequiresProviderSignature = new(
        Values.RequiresProviderSignature
    );

    public CreateOrderResponseStatus(string value)
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
    public static CreateOrderResponseStatus FromCustom(string value)
    {
        return new CreateOrderResponseStatus(value);
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

    public static bool operator ==(CreateOrderResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateOrderResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateOrderResponseStatus value) => value.Value;

    public static explicit operator CreateOrderResponseStatus(string value) => new(value);

    internal class CreateOrderResponseStatusSerializer : JsonConverter<CreateOrderResponseStatus>
    {
        public override CreateOrderResponseStatus Read(
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
            return new CreateOrderResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderResponseStatus ReadAsPropertyName(
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
            return new CreateOrderResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderResponseStatus value,
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
        public const string RequiresProviderSignature = "requires_provider_signature";
    }
}
