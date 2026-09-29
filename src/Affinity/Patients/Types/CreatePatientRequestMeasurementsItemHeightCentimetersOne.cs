using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreatePatientRequestMeasurementsItemHeightCentimetersOne.CreatePatientRequestMeasurementsItemHeightCentimetersOneSerializer)
)]
[Serializable]
public readonly record struct CreatePatientRequestMeasurementsItemHeightCentimetersOne : IStringEnum
{
    public static readonly CreatePatientRequestMeasurementsItemHeightCentimetersOne Infinity = new(
        Values.Infinity
    );

    public static readonly CreatePatientRequestMeasurementsItemHeightCentimetersOne NaN = new(
        Values.NaN
    );

    public CreatePatientRequestMeasurementsItemHeightCentimetersOne(string value)
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
    public static CreatePatientRequestMeasurementsItemHeightCentimetersOne FromCustom(string value)
    {
        return new CreatePatientRequestMeasurementsItemHeightCentimetersOne(value);
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
        CreatePatientRequestMeasurementsItemHeightCentimetersOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreatePatientRequestMeasurementsItemHeightCentimetersOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreatePatientRequestMeasurementsItemHeightCentimetersOne value
    ) => value.Value;

    public static explicit operator CreatePatientRequestMeasurementsItemHeightCentimetersOne(
        string value
    ) => new(value);

    internal class CreatePatientRequestMeasurementsItemHeightCentimetersOneSerializer
        : JsonConverter<CreatePatientRequestMeasurementsItemHeightCentimetersOne>
    {
        public override CreatePatientRequestMeasurementsItemHeightCentimetersOne Read(
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
            return new CreatePatientRequestMeasurementsItemHeightCentimetersOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePatientRequestMeasurementsItemHeightCentimetersOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePatientRequestMeasurementsItemHeightCentimetersOne ReadAsPropertyName(
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
            return new CreatePatientRequestMeasurementsItemHeightCentimetersOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePatientRequestMeasurementsItemHeightCentimetersOne value,
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
