using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne.PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOneSerializer)
)]
[Serializable]
public readonly record struct PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne
    : IStringEnum
{
    public static readonly PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne Infinity =
        new(Values.Infinity);

    public static readonly PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne NaN =
        new(Values.NaN);

    public PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne(string value)
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
    public static PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne FromCustom(
        string value
    )
    {
        return new PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne(value);
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
        PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne value
    ) => value.Value;

    public static explicit operator PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne(
        string value
    ) => new(value);

    internal class PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOneSerializer
        : JsonConverter<PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne>
    {
        public override PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne Read(
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
            return new PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne ReadAsPropertyName(
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
            return new PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderResponseOrderInputPatientMeasurementsItemWeightKilogramsOne value,
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
