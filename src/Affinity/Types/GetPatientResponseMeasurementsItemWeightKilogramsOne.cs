using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetPatientResponseMeasurementsItemWeightKilogramsOne.GetPatientResponseMeasurementsItemWeightKilogramsOneSerializer)
)]
[Serializable]
public readonly record struct GetPatientResponseMeasurementsItemWeightKilogramsOne : IStringEnum
{
    public static readonly GetPatientResponseMeasurementsItemWeightKilogramsOne Infinity = new(
        Values.Infinity
    );

    public static readonly GetPatientResponseMeasurementsItemWeightKilogramsOne NaN = new(
        Values.NaN
    );

    public GetPatientResponseMeasurementsItemWeightKilogramsOne(string value)
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
    public static GetPatientResponseMeasurementsItemWeightKilogramsOne FromCustom(string value)
    {
        return new GetPatientResponseMeasurementsItemWeightKilogramsOne(value);
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
        GetPatientResponseMeasurementsItemWeightKilogramsOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetPatientResponseMeasurementsItemWeightKilogramsOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetPatientResponseMeasurementsItemWeightKilogramsOne value
    ) => value.Value;

    public static explicit operator GetPatientResponseMeasurementsItemWeightKilogramsOne(
        string value
    ) => new(value);

    internal class GetPatientResponseMeasurementsItemWeightKilogramsOneSerializer
        : JsonConverter<GetPatientResponseMeasurementsItemWeightKilogramsOne>
    {
        public override GetPatientResponseMeasurementsItemWeightKilogramsOne Read(
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
            return new GetPatientResponseMeasurementsItemWeightKilogramsOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPatientResponseMeasurementsItemWeightKilogramsOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPatientResponseMeasurementsItemWeightKilogramsOne ReadAsPropertyName(
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
            return new GetPatientResponseMeasurementsItemWeightKilogramsOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPatientResponseMeasurementsItemWeightKilogramsOne value,
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
