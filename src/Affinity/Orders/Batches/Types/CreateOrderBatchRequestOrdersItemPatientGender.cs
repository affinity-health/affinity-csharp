using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Orders;

[JsonConverter(
    typeof(CreateOrderBatchRequestOrdersItemPatientGender.CreateOrderBatchRequestOrdersItemPatientGenderSerializer)
)]
[Serializable]
public readonly record struct CreateOrderBatchRequestOrdersItemPatientGender : IStringEnum
{
    public static readonly CreateOrderBatchRequestOrdersItemPatientGender F = new(Values.F);

    public static readonly CreateOrderBatchRequestOrdersItemPatientGender M = new(Values.M);

    public static readonly CreateOrderBatchRequestOrdersItemPatientGender O = new(Values.O);

    public static readonly CreateOrderBatchRequestOrdersItemPatientGender U = new(Values.U);

    public CreateOrderBatchRequestOrdersItemPatientGender(string value)
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
    public static CreateOrderBatchRequestOrdersItemPatientGender FromCustom(string value)
    {
        return new CreateOrderBatchRequestOrdersItemPatientGender(value);
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
        CreateOrderBatchRequestOrdersItemPatientGender value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderBatchRequestOrdersItemPatientGender value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateOrderBatchRequestOrdersItemPatientGender value) =>
        value.Value;

    public static explicit operator CreateOrderBatchRequestOrdersItemPatientGender(string value) =>
        new(value);

    internal class CreateOrderBatchRequestOrdersItemPatientGenderSerializer
        : JsonConverter<CreateOrderBatchRequestOrdersItemPatientGender>
    {
        public override CreateOrderBatchRequestOrdersItemPatientGender Read(
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
            return new CreateOrderBatchRequestOrdersItemPatientGender(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderBatchRequestOrdersItemPatientGender value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderBatchRequestOrdersItemPatientGender ReadAsPropertyName(
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
            return new CreateOrderBatchRequestOrdersItemPatientGender(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderBatchRequestOrdersItemPatientGender value,
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
        public const string F = "f";

        public const string M = "m";

        public const string O = "o";

        public const string U = "u";
    }
}
