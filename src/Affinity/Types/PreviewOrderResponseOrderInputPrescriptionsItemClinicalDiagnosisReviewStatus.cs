using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus.PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatusSerializer)
)]
[Serializable]
public readonly record struct PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus
    : IStringEnum
{
    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus NotReviewed =
        new(Values.NotReviewed);

    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus None =
        new(Values.None);

    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus Recorded =
        new(Values.Recorded);

    public PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus(
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
    public static PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus FromCustom(
        string value
    )
    {
        return new PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus(
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
        PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus value
    ) => value.Value;

    public static explicit operator PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus(
        string value
    ) => new(value);

    internal class PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatusSerializer
        : JsonConverter<PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus>
    {
        public override PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus Read(
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
            return new PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus ReadAsPropertyName(
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
            return new PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderResponseOrderInputPrescriptionsItemClinicalDiagnosisReviewStatus value,
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
