using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreateOrderResponsePrescriptionsItemStatus.CreateOrderResponsePrescriptionsItemStatusSerializer)
)]
[Serializable]
public readonly record struct CreateOrderResponsePrescriptionsItemStatus : IStringEnum
{
    public static readonly CreateOrderResponsePrescriptionsItemStatus RequiresProviderSignature =
        new(Values.RequiresProviderSignature);

    public CreateOrderResponsePrescriptionsItemStatus(string value)
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
    public static CreateOrderResponsePrescriptionsItemStatus FromCustom(string value)
    {
        return new CreateOrderResponsePrescriptionsItemStatus(value);
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
        CreateOrderResponsePrescriptionsItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderResponsePrescriptionsItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateOrderResponsePrescriptionsItemStatus value) =>
        value.Value;

    public static explicit operator CreateOrderResponsePrescriptionsItemStatus(string value) =>
        new(value);

    internal class CreateOrderResponsePrescriptionsItemStatusSerializer
        : JsonConverter<CreateOrderResponsePrescriptionsItemStatus>
    {
        public override CreateOrderResponsePrescriptionsItemStatus Read(
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
            return new CreateOrderResponsePrescriptionsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderResponsePrescriptionsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderResponsePrescriptionsItemStatus ReadAsPropertyName(
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
            return new CreateOrderResponsePrescriptionsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderResponsePrescriptionsItemStatus value,
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
