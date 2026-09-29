using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderResponseClinicalRequirementsItemType.PreviewOrderResponseClinicalRequirementsItemTypeSerializer)
)]
[Serializable]
public readonly record struct PreviewOrderResponseClinicalRequirementsItemType : IStringEnum
{
    public static readonly PreviewOrderResponseClinicalRequirementsItemType AllergyReview = new(
        Values.AllergyReview
    );

    public static readonly PreviewOrderResponseClinicalRequirementsItemType MedicationReview = new(
        Values.MedicationReview
    );

    public static readonly PreviewOrderResponseClinicalRequirementsItemType DiagnosisReview = new(
        Values.DiagnosisReview
    );

    public static readonly PreviewOrderResponseClinicalRequirementsItemType Diagnosis = new(
        Values.Diagnosis
    );

    public PreviewOrderResponseClinicalRequirementsItemType(string value)
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
    public static PreviewOrderResponseClinicalRequirementsItemType FromCustom(string value)
    {
        return new PreviewOrderResponseClinicalRequirementsItemType(value);
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
        PreviewOrderResponseClinicalRequirementsItemType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderResponseClinicalRequirementsItemType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PreviewOrderResponseClinicalRequirementsItemType value
    ) => value.Value;

    public static explicit operator PreviewOrderResponseClinicalRequirementsItemType(
        string value
    ) => new(value);

    internal class PreviewOrderResponseClinicalRequirementsItemTypeSerializer
        : JsonConverter<PreviewOrderResponseClinicalRequirementsItemType>
    {
        public override PreviewOrderResponseClinicalRequirementsItemType Read(
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
            return new PreviewOrderResponseClinicalRequirementsItemType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderResponseClinicalRequirementsItemType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderResponseClinicalRequirementsItemType ReadAsPropertyName(
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
            return new PreviewOrderResponseClinicalRequirementsItemType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderResponseClinicalRequirementsItemType value,
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
        public const string AllergyReview = "allergy_review";

        public const string MedicationReview = "medication_review";

        public const string DiagnosisReview = "diagnosis_review";

        public const string Diagnosis = "diagnosis";
    }
}
