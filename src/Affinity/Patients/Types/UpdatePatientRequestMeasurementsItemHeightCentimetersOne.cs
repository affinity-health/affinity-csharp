using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(UpdatePatientRequestMeasurementsItemHeightCentimetersOne.UpdatePatientRequestMeasurementsItemHeightCentimetersOneSerializer)
)]
[Serializable]
public readonly record struct UpdatePatientRequestMeasurementsItemHeightCentimetersOne : IStringEnum
{
    public static readonly UpdatePatientRequestMeasurementsItemHeightCentimetersOne Infinity = new(
        Values.Infinity
    );

    public static readonly UpdatePatientRequestMeasurementsItemHeightCentimetersOne NaN = new(
        Values.NaN
    );

    public UpdatePatientRequestMeasurementsItemHeightCentimetersOne(string value)
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
    public static UpdatePatientRequestMeasurementsItemHeightCentimetersOne FromCustom(string value)
    {
        return new UpdatePatientRequestMeasurementsItemHeightCentimetersOne(value);
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
        UpdatePatientRequestMeasurementsItemHeightCentimetersOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdatePatientRequestMeasurementsItemHeightCentimetersOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        UpdatePatientRequestMeasurementsItemHeightCentimetersOne value
    ) => value.Value;

    public static explicit operator UpdatePatientRequestMeasurementsItemHeightCentimetersOne(
        string value
    ) => new(value);

    internal class UpdatePatientRequestMeasurementsItemHeightCentimetersOneSerializer
        : JsonConverter<UpdatePatientRequestMeasurementsItemHeightCentimetersOne>
    {
        public override UpdatePatientRequestMeasurementsItemHeightCentimetersOne Read(
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
            return new UpdatePatientRequestMeasurementsItemHeightCentimetersOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdatePatientRequestMeasurementsItemHeightCentimetersOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdatePatientRequestMeasurementsItemHeightCentimetersOne ReadAsPropertyName(
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
            return new UpdatePatientRequestMeasurementsItemHeightCentimetersOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdatePatientRequestMeasurementsItemHeightCentimetersOne value,
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
