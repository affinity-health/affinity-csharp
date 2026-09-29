using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(UpdatePatientRequestMeasurementsItemWeightKilogramsOne.UpdatePatientRequestMeasurementsItemWeightKilogramsOneSerializer)
)]
[Serializable]
public readonly record struct UpdatePatientRequestMeasurementsItemWeightKilogramsOne : IStringEnum
{
    public static readonly UpdatePatientRequestMeasurementsItemWeightKilogramsOne Infinity = new(
        Values.Infinity
    );

    public static readonly UpdatePatientRequestMeasurementsItemWeightKilogramsOne NaN = new(
        Values.NaN
    );

    public UpdatePatientRequestMeasurementsItemWeightKilogramsOne(string value)
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
    public static UpdatePatientRequestMeasurementsItemWeightKilogramsOne FromCustom(string value)
    {
        return new UpdatePatientRequestMeasurementsItemWeightKilogramsOne(value);
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
        UpdatePatientRequestMeasurementsItemWeightKilogramsOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdatePatientRequestMeasurementsItemWeightKilogramsOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        UpdatePatientRequestMeasurementsItemWeightKilogramsOne value
    ) => value.Value;

    public static explicit operator UpdatePatientRequestMeasurementsItemWeightKilogramsOne(
        string value
    ) => new(value);

    internal class UpdatePatientRequestMeasurementsItemWeightKilogramsOneSerializer
        : JsonConverter<UpdatePatientRequestMeasurementsItemWeightKilogramsOne>
    {
        public override UpdatePatientRequestMeasurementsItemWeightKilogramsOne Read(
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
            return new UpdatePatientRequestMeasurementsItemWeightKilogramsOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdatePatientRequestMeasurementsItemWeightKilogramsOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdatePatientRequestMeasurementsItemWeightKilogramsOne ReadAsPropertyName(
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
            return new UpdatePatientRequestMeasurementsItemWeightKilogramsOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdatePatientRequestMeasurementsItemWeightKilogramsOne value,
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
