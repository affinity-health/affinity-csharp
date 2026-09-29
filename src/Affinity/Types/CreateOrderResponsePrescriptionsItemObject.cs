using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreateOrderResponsePrescriptionsItemObject.CreateOrderResponsePrescriptionsItemObjectSerializer)
)]
[Serializable]
public readonly record struct CreateOrderResponsePrescriptionsItemObject : IStringEnum
{
    public static readonly CreateOrderResponsePrescriptionsItemObject Prescription = new(
        Values.Prescription
    );

    public CreateOrderResponsePrescriptionsItemObject(string value)
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
    public static CreateOrderResponsePrescriptionsItemObject FromCustom(string value)
    {
        return new CreateOrderResponsePrescriptionsItemObject(value);
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
        CreateOrderResponsePrescriptionsItemObject value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderResponsePrescriptionsItemObject value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateOrderResponsePrescriptionsItemObject value) =>
        value.Value;

    public static explicit operator CreateOrderResponsePrescriptionsItemObject(string value) =>
        new(value);

    internal class CreateOrderResponsePrescriptionsItemObjectSerializer
        : JsonConverter<CreateOrderResponsePrescriptionsItemObject>
    {
        public override CreateOrderResponsePrescriptionsItemObject Read(
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
            return new CreateOrderResponsePrescriptionsItemObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderResponsePrescriptionsItemObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderResponsePrescriptionsItemObject ReadAsPropertyName(
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
            return new CreateOrderResponsePrescriptionsItemObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderResponsePrescriptionsItemObject value,
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
        public const string Prescription = "prescription";
    }
}
