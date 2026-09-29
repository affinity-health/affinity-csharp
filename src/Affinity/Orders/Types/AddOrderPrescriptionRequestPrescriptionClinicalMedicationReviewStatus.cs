using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus.AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatusSerializer)
)]
[Serializable]
public readonly record struct AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus
    : IStringEnum
{
    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus NotReviewed =
        new(Values.NotReviewed);

    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus None =
        new(Values.None);

    public static readonly AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus Recorded =
        new(Values.Recorded);

    public AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus(string value)
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
    public static AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus FromCustom(
        string value
    )
    {
        return new AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus(value);
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
        AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus value
    ) => value.Value;

    public static explicit operator AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus(
        string value
    ) => new(value);

    internal class AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatusSerializer
        : JsonConverter<AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus>
    {
        public override AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus Read(
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
            return new AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus ReadAsPropertyName(
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
            return new AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AddOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus value,
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
        public const string NotReviewed = "not_reviewed";

        public const string None = "none";

        public const string Recorded = "recorded";
    }
}
