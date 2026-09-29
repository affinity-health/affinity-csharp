using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreateOrderResponsePrescriptionsItemQuantityOne.CreateOrderResponsePrescriptionsItemQuantityOneSerializer)
)]
[Serializable]
public readonly record struct CreateOrderResponsePrescriptionsItemQuantityOne : IStringEnum
{
    public static readonly CreateOrderResponsePrescriptionsItemQuantityOne Infinity = new(
        Values.Infinity
    );

    public static readonly CreateOrderResponsePrescriptionsItemQuantityOne NaN = new(Values.NaN);

    public CreateOrderResponsePrescriptionsItemQuantityOne(string value)
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
    public static CreateOrderResponsePrescriptionsItemQuantityOne FromCustom(string value)
    {
        return new CreateOrderResponsePrescriptionsItemQuantityOne(value);
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
        CreateOrderResponsePrescriptionsItemQuantityOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderResponsePrescriptionsItemQuantityOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateOrderResponsePrescriptionsItemQuantityOne value) =>
        value.Value;

    public static explicit operator CreateOrderResponsePrescriptionsItemQuantityOne(string value) =>
        new(value);

    internal class CreateOrderResponsePrescriptionsItemQuantityOneSerializer
        : JsonConverter<CreateOrderResponsePrescriptionsItemQuantityOne>
    {
        public override CreateOrderResponsePrescriptionsItemQuantityOne Read(
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
            return new CreateOrderResponsePrescriptionsItemQuantityOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderResponsePrescriptionsItemQuantityOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderResponsePrescriptionsItemQuantityOne ReadAsPropertyName(
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
            return new CreateOrderResponsePrescriptionsItemQuantityOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderResponsePrescriptionsItemQuantityOne value,
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
