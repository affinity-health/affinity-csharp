using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreatePatientResponseMeasurementsItemHeightCentimetersOne.CreatePatientResponseMeasurementsItemHeightCentimetersOneSerializer)
)]
[Serializable]
public readonly record struct CreatePatientResponseMeasurementsItemHeightCentimetersOne
    : IStringEnum
{
    public static readonly CreatePatientResponseMeasurementsItemHeightCentimetersOne Infinity = new(
        Values.Infinity
    );

    public static readonly CreatePatientResponseMeasurementsItemHeightCentimetersOne NaN = new(
        Values.NaN
    );

    public CreatePatientResponseMeasurementsItemHeightCentimetersOne(string value)
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
    public static CreatePatientResponseMeasurementsItemHeightCentimetersOne FromCustom(string value)
    {
        return new CreatePatientResponseMeasurementsItemHeightCentimetersOne(value);
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
        CreatePatientResponseMeasurementsItemHeightCentimetersOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreatePatientResponseMeasurementsItemHeightCentimetersOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreatePatientResponseMeasurementsItemHeightCentimetersOne value
    ) => value.Value;

    public static explicit operator CreatePatientResponseMeasurementsItemHeightCentimetersOne(
        string value
    ) => new(value);

    internal class CreatePatientResponseMeasurementsItemHeightCentimetersOneSerializer
        : JsonConverter<CreatePatientResponseMeasurementsItemHeightCentimetersOne>
    {
        public override CreatePatientResponseMeasurementsItemHeightCentimetersOne Read(
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
            return new CreatePatientResponseMeasurementsItemHeightCentimetersOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePatientResponseMeasurementsItemHeightCentimetersOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePatientResponseMeasurementsItemHeightCentimetersOne ReadAsPropertyName(
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
            return new CreatePatientResponseMeasurementsItemHeightCentimetersOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePatientResponseMeasurementsItemHeightCentimetersOne value,
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
