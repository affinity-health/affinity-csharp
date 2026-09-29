using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(UpdatePatientResponseClinicalProfileHeightInchesOne.UpdatePatientResponseClinicalProfileHeightInchesOneSerializer)
)]
[Serializable]
public readonly record struct UpdatePatientResponseClinicalProfileHeightInchesOne : IStringEnum
{
    public static readonly UpdatePatientResponseClinicalProfileHeightInchesOne Infinity = new(
        Values.Infinity
    );

    public static readonly UpdatePatientResponseClinicalProfileHeightInchesOne NaN = new(
        Values.NaN
    );

    public UpdatePatientResponseClinicalProfileHeightInchesOne(string value)
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
    public static UpdatePatientResponseClinicalProfileHeightInchesOne FromCustom(string value)
    {
        return new UpdatePatientResponseClinicalProfileHeightInchesOne(value);
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
        UpdatePatientResponseClinicalProfileHeightInchesOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdatePatientResponseClinicalProfileHeightInchesOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        UpdatePatientResponseClinicalProfileHeightInchesOne value
    ) => value.Value;

    public static explicit operator UpdatePatientResponseClinicalProfileHeightInchesOne(
        string value
    ) => new(value);

    internal class UpdatePatientResponseClinicalProfileHeightInchesOneSerializer
        : JsonConverter<UpdatePatientResponseClinicalProfileHeightInchesOne>
    {
        public override UpdatePatientResponseClinicalProfileHeightInchesOne Read(
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
            return new UpdatePatientResponseClinicalProfileHeightInchesOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdatePatientResponseClinicalProfileHeightInchesOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdatePatientResponseClinicalProfileHeightInchesOne ReadAsPropertyName(
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
            return new UpdatePatientResponseClinicalProfileHeightInchesOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdatePatientResponseClinicalProfileHeightInchesOne value,
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
