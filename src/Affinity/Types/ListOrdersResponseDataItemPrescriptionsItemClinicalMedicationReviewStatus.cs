using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus.ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatusSerializer)
)]
[Serializable]
public readonly record struct ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus
    : IStringEnum
{
    public static readonly ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus NotReviewed =
        new(Values.NotReviewed);

    public static readonly ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus None =
        new(Values.None);

    public static readonly ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus Recorded =
        new(Values.Recorded);

    public ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus(string value)
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
    public static ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus FromCustom(
        string value
    )
    {
        return new ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus(value);
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
        ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus value
    ) => value.Value;

    public static explicit operator ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus(
        string value
    ) => new(value);

    internal class ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatusSerializer
        : JsonConverter<ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus>
    {
        public override ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus Read(
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
            return new ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus ReadAsPropertyName(
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
            return new ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemPrescriptionsItemClinicalMedicationReviewStatus value,
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
