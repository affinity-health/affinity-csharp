using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne.PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOneSerializer)
)]
[Serializable]
public readonly record struct PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne
    : IStringEnum
{
    public static readonly PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne Infinity =
        new(Values.Infinity);

    public static readonly PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne NaN =
        new(Values.NaN);

    public PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne(string value)
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
    public static PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne FromCustom(
        string value
    )
    {
        return new PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne(value);
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
        PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne value
    ) => value.Value;

    public static explicit operator PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne(
        string value
    ) => new(value);

    internal class PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOneSerializer
        : JsonConverter<PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne>
    {
        public override PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne Read(
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
            return new PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne ReadAsPropertyName(
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
            return new PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderResponseOrderInputPatientClinicalProfileHeightInchesOne value,
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
