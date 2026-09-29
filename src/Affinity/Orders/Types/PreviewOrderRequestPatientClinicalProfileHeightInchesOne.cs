using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderRequestPatientClinicalProfileHeightInchesOne.PreviewOrderRequestPatientClinicalProfileHeightInchesOneSerializer)
)]
[Serializable]
public readonly record struct PreviewOrderRequestPatientClinicalProfileHeightInchesOne : IStringEnum
{
    public static readonly PreviewOrderRequestPatientClinicalProfileHeightInchesOne Infinity = new(
        Values.Infinity
    );

    public static readonly PreviewOrderRequestPatientClinicalProfileHeightInchesOne NaN = new(
        Values.NaN
    );

    public PreviewOrderRequestPatientClinicalProfileHeightInchesOne(string value)
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
    public static PreviewOrderRequestPatientClinicalProfileHeightInchesOne FromCustom(string value)
    {
        return new PreviewOrderRequestPatientClinicalProfileHeightInchesOne(value);
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
        PreviewOrderRequestPatientClinicalProfileHeightInchesOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderRequestPatientClinicalProfileHeightInchesOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PreviewOrderRequestPatientClinicalProfileHeightInchesOne value
    ) => value.Value;

    public static explicit operator PreviewOrderRequestPatientClinicalProfileHeightInchesOne(
        string value
    ) => new(value);

    internal class PreviewOrderRequestPatientClinicalProfileHeightInchesOneSerializer
        : JsonConverter<PreviewOrderRequestPatientClinicalProfileHeightInchesOne>
    {
        public override PreviewOrderRequestPatientClinicalProfileHeightInchesOne Read(
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
            return new PreviewOrderRequestPatientClinicalProfileHeightInchesOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderRequestPatientClinicalProfileHeightInchesOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderRequestPatientClinicalProfileHeightInchesOne ReadAsPropertyName(
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
            return new PreviewOrderRequestPatientClinicalProfileHeightInchesOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderRequestPatientClinicalProfileHeightInchesOne value,
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
