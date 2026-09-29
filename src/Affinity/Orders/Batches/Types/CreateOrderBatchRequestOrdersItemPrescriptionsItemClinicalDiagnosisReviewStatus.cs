using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Orders;

[JsonConverter(
    typeof(CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus.CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatusSerializer)
)]
[Serializable]
public readonly record struct CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus
    : IStringEnum
{
    public static readonly CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus NotReviewed =
        new(Values.NotReviewed);

    public static readonly CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus None =
        new(Values.None);

    public static readonly CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus Recorded =
        new(Values.Recorded);

    public CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus(
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
    public static CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus FromCustom(
        string value
    )
    {
        return new CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus(
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
        CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus value
    ) => value.Value;

    public static explicit operator CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus(
        string value
    ) => new(value);

    internal class CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatusSerializer
        : JsonConverter<CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus>
    {
        public override CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus Read(
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
            return new CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus ReadAsPropertyName(
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
            return new CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderBatchRequestOrdersItemPrescriptionsItemClinicalDiagnosisReviewStatus value,
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
