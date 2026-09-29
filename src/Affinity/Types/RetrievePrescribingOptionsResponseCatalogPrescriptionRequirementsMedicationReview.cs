using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview.RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReviewSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview Optional =
        new(Values.Optional);

    public static readonly RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview Required =
        new(Values.Required);

    public RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview(
        string value
    )
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
    public static RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview(
            value
        );
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
        RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReviewSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview>
    {
        public override RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview Read(
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
            return new RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsMedicationReview value,
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
        public const string Optional = "optional";

        public const string Required = "required";
    }
}
