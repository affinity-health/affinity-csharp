using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne.CreateOrderRequestPatientMeasurementsItemWeightKilogramsOneSerializer)
)]
[Serializable]
public readonly record struct CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne
    : IStringEnum
{
    public static readonly CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne Infinity =
        new(Values.Infinity);

    public static readonly CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne NaN = new(
        Values.NaN
    );

    public CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne(string value)
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
    public static CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne FromCustom(
        string value
    )
    {
        return new CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne(value);
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
        CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne value
    ) => value.Value;

    public static explicit operator CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne(
        string value
    ) => new(value);

    internal class CreateOrderRequestPatientMeasurementsItemWeightKilogramsOneSerializer
        : JsonConverter<CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne>
    {
        public override CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne Read(
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
            return new CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne ReadAsPropertyName(
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
            return new CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderRequestPatientMeasurementsItemWeightKilogramsOne value,
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
