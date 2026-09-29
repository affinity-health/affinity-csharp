using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus.UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatusSerializer)
)]
[Serializable]
public readonly record struct UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus
    : IStringEnum
{
    public static readonly UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus NotReviewed =
        new(Values.NotReviewed);

    public static readonly UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus None =
        new(Values.None);

    public static readonly UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus Recorded =
        new(Values.Recorded);

    public UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus(string value)
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
    public static UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus FromCustom(
        string value
    )
    {
        return new UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus(value);
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
        UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus value
    ) => value.Value;

    public static explicit operator UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus(
        string value
    ) => new(value);

    internal class UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatusSerializer
        : JsonConverter<UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus>
    {
        public override UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus Read(
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
            return new UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus ReadAsPropertyName(
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
            return new UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateOrderPrescriptionRequestPrescriptionClinicalMedicationReviewStatus value,
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
