using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus.GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatusSerializer)
)]
[Serializable]
public readonly record struct GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus
    : IStringEnum
{
    public static readonly GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus NotReviewed =
        new(Values.NotReviewed);

    public static readonly GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus None =
        new(Values.None);

    public static readonly GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus Recorded =
        new(Values.Recorded);

    public GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus(string value)
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
    public static GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus FromCustom(
        string value
    )
    {
        return new GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus(value);
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
        GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus value
    ) => value.Value;

    public static explicit operator GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus(
        string value
    ) => new(value);

    internal class GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatusSerializer
        : JsonConverter<GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus>
    {
        public override GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus Read(
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
            return new GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus ReadAsPropertyName(
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
            return new GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrderResponsePrescriptionsItemClinicalDiagnosisReviewStatus value,
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
