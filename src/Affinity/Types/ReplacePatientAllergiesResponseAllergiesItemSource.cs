using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ReplacePatientAllergiesResponseAllergiesItemSource.ReplacePatientAllergiesResponseAllergiesItemSourceSerializer)
)]
[Serializable]
public readonly record struct ReplacePatientAllergiesResponseAllergiesItemSource : IStringEnum
{
    public static readonly ReplacePatientAllergiesResponseAllergiesItemSource Doctor = new(
        Values.Doctor
    );

    public static readonly ReplacePatientAllergiesResponseAllergiesItemSource Patient = new(
        Values.Patient
    );

    public static readonly ReplacePatientAllergiesResponseAllergiesItemSource PatientAgentGuardian =
        new(Values.PatientAgentGuardian);

    public static readonly ReplacePatientAllergiesResponseAllergiesItemSource Pharmacist = new(
        Values.Pharmacist
    );

    public ReplacePatientAllergiesResponseAllergiesItemSource(string value)
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
    public static ReplacePatientAllergiesResponseAllergiesItemSource FromCustom(string value)
    {
        return new ReplacePatientAllergiesResponseAllergiesItemSource(value);
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
        ReplacePatientAllergiesResponseAllergiesItemSource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReplacePatientAllergiesResponseAllergiesItemSource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ReplacePatientAllergiesResponseAllergiesItemSource value
    ) => value.Value;

    public static explicit operator ReplacePatientAllergiesResponseAllergiesItemSource(
        string value
    ) => new(value);

    internal class ReplacePatientAllergiesResponseAllergiesItemSourceSerializer
        : JsonConverter<ReplacePatientAllergiesResponseAllergiesItemSource>
    {
        public override ReplacePatientAllergiesResponseAllergiesItemSource Read(
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
            return new ReplacePatientAllergiesResponseAllergiesItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesResponseAllergiesItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReplacePatientAllergiesResponseAllergiesItemSource ReadAsPropertyName(
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
            return new ReplacePatientAllergiesResponseAllergiesItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesResponseAllergiesItemSource value,
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
        public const string Doctor = "Doctor";

        public const string Patient = "Patient";

        public const string PatientAgentGuardian = "Patient Agent/Guardian";

        public const string Pharmacist = "Pharmacist";
    }
}
