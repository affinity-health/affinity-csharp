using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus.CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatusSerializer)
)]
[Serializable]
public readonly record struct CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus
    : IStringEnum
{
    public static readonly CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus NotReviewed =
        new(Values.NotReviewed);

    public static readonly CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus None =
        new(Values.None);

    public static readonly CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus Recorded =
        new(Values.Recorded);

    public CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus(string value)
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
    public static CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus FromCustom(
        string value
    )
    {
        return new CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus(value);
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
        CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus value
    ) => value.Value;

    public static explicit operator CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus(
        string value
    ) => new(value);

    internal class CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatusSerializer
        : JsonConverter<CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus>
    {
        public override CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus Read(
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
            return new CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus ReadAsPropertyName(
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
            return new CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderRequestPrescriptionsItemClinicalMedicationReviewStatus value,
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
