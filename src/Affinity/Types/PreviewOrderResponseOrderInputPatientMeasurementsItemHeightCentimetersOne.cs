using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne.PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOneSerializer)
)]
[Serializable]
public readonly record struct PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne
    : IStringEnum
{
    public static readonly PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne Infinity =
        new(Values.Infinity);

    public static readonly PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne NaN =
        new(Values.NaN);

    public PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne(string value)
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
    public static PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne FromCustom(
        string value
    )
    {
        return new PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne(value);
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
        PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne value
    ) => value.Value;

    public static explicit operator PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne(
        string value
    ) => new(value);

    internal class PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOneSerializer
        : JsonConverter<PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne>
    {
        public override PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne Read(
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
            return new PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne ReadAsPropertyName(
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
            return new PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderResponseOrderInputPatientMeasurementsItemHeightCentimetersOne value,
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
