using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(UpdatePatientResponseMeasurementsItemWeightKilogramsOne.UpdatePatientResponseMeasurementsItemWeightKilogramsOneSerializer)
)]
[Serializable]
public readonly record struct UpdatePatientResponseMeasurementsItemWeightKilogramsOne : IStringEnum
{
    public static readonly UpdatePatientResponseMeasurementsItemWeightKilogramsOne Infinity = new(
        Values.Infinity
    );

    public static readonly UpdatePatientResponseMeasurementsItemWeightKilogramsOne NaN = new(
        Values.NaN
    );

    public UpdatePatientResponseMeasurementsItemWeightKilogramsOne(string value)
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
    public static UpdatePatientResponseMeasurementsItemWeightKilogramsOne FromCustom(string value)
    {
        return new UpdatePatientResponseMeasurementsItemWeightKilogramsOne(value);
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
        UpdatePatientResponseMeasurementsItemWeightKilogramsOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdatePatientResponseMeasurementsItemWeightKilogramsOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        UpdatePatientResponseMeasurementsItemWeightKilogramsOne value
    ) => value.Value;

    public static explicit operator UpdatePatientResponseMeasurementsItemWeightKilogramsOne(
        string value
    ) => new(value);

    internal class UpdatePatientResponseMeasurementsItemWeightKilogramsOneSerializer
        : JsonConverter<UpdatePatientResponseMeasurementsItemWeightKilogramsOne>
    {
        public override UpdatePatientResponseMeasurementsItemWeightKilogramsOne Read(
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
            return new UpdatePatientResponseMeasurementsItemWeightKilogramsOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdatePatientResponseMeasurementsItemWeightKilogramsOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdatePatientResponseMeasurementsItemWeightKilogramsOne ReadAsPropertyName(
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
            return new UpdatePatientResponseMeasurementsItemWeightKilogramsOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdatePatientResponseMeasurementsItemWeightKilogramsOne value,
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
