using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreateOrderRequestPrescriptionsItemQuantityOne.CreateOrderRequestPrescriptionsItemQuantityOneSerializer)
)]
[Serializable]
public readonly record struct CreateOrderRequestPrescriptionsItemQuantityOne : IStringEnum
{
    public static readonly CreateOrderRequestPrescriptionsItemQuantityOne Infinity = new(
        Values.Infinity
    );

    public static readonly CreateOrderRequestPrescriptionsItemQuantityOne NaN = new(Values.NaN);

    public CreateOrderRequestPrescriptionsItemQuantityOne(string value)
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
    public static CreateOrderRequestPrescriptionsItemQuantityOne FromCustom(string value)
    {
        return new CreateOrderRequestPrescriptionsItemQuantityOne(value);
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
        CreateOrderRequestPrescriptionsItemQuantityOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderRequestPrescriptionsItemQuantityOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateOrderRequestPrescriptionsItemQuantityOne value) =>
        value.Value;

    public static explicit operator CreateOrderRequestPrescriptionsItemQuantityOne(string value) =>
        new(value);

    internal class CreateOrderRequestPrescriptionsItemQuantityOneSerializer
        : JsonConverter<CreateOrderRequestPrescriptionsItemQuantityOne>
    {
        public override CreateOrderRequestPrescriptionsItemQuantityOne Read(
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
            return new CreateOrderRequestPrescriptionsItemQuantityOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderRequestPrescriptionsItemQuantityOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderRequestPrescriptionsItemQuantityOne ReadAsPropertyName(
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
            return new CreateOrderRequestPrescriptionsItemQuantityOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderRequestPrescriptionsItemQuantityOne value,
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
