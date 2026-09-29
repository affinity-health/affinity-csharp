using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne.PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOneSerializer)
)]
[Serializable]
public readonly record struct PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne
    : IStringEnum
{
    public static readonly PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne Infinity =
        new(Values.Infinity);

    public static readonly PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne NaN = new(
        Values.NaN
    );

    public PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne(string value)
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
    public static PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne FromCustom(
        string value
    )
    {
        return new PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne(value);
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
        PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne value
    ) => value.Value;

    public static explicit operator PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne(
        string value
    ) => new(value);

    internal class PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOneSerializer
        : JsonConverter<PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne>
    {
        public override PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne Read(
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
            return new PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne ReadAsPropertyName(
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
            return new PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderRequestPatientMeasurementsItemWeightKilogramsOne value,
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
