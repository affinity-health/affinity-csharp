using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(UpdatePatientResponseMeasurementsItemHeightCentimetersOne.UpdatePatientResponseMeasurementsItemHeightCentimetersOneSerializer)
)]
[Serializable]
public readonly record struct UpdatePatientResponseMeasurementsItemHeightCentimetersOne
    : IStringEnum
{
    public static readonly UpdatePatientResponseMeasurementsItemHeightCentimetersOne Infinity = new(
        Values.Infinity
    );

    public static readonly UpdatePatientResponseMeasurementsItemHeightCentimetersOne NaN = new(
        Values.NaN
    );

    public UpdatePatientResponseMeasurementsItemHeightCentimetersOne(string value)
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
    public static UpdatePatientResponseMeasurementsItemHeightCentimetersOne FromCustom(string value)
    {
        return new UpdatePatientResponseMeasurementsItemHeightCentimetersOne(value);
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
        UpdatePatientResponseMeasurementsItemHeightCentimetersOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdatePatientResponseMeasurementsItemHeightCentimetersOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        UpdatePatientResponseMeasurementsItemHeightCentimetersOne value
    ) => value.Value;

    public static explicit operator UpdatePatientResponseMeasurementsItemHeightCentimetersOne(
        string value
    ) => new(value);

    internal class UpdatePatientResponseMeasurementsItemHeightCentimetersOneSerializer
        : JsonConverter<UpdatePatientResponseMeasurementsItemHeightCentimetersOne>
    {
        public override UpdatePatientResponseMeasurementsItemHeightCentimetersOne Read(
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
            return new UpdatePatientResponseMeasurementsItemHeightCentimetersOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdatePatientResponseMeasurementsItemHeightCentimetersOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdatePatientResponseMeasurementsItemHeightCentimetersOne ReadAsPropertyName(
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
            return new UpdatePatientResponseMeasurementsItemHeightCentimetersOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdatePatientResponseMeasurementsItemHeightCentimetersOne value,
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
