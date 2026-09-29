using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus.PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatusSerializer)
)]
[Serializable]
public readonly record struct PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus
    : IStringEnum
{
    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus NotReviewed =
        new(Values.NotReviewed);

    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus None =
        new(Values.None);

    public static readonly PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus Recorded =
        new(Values.Recorded);

    public PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus(string value)
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
    public static PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus FromCustom(
        string value
    )
    {
        return new PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus(
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
        PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus value
    ) => value.Value;

    public static explicit operator PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus(
        string value
    ) => new(value);

    internal class PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatusSerializer
        : JsonConverter<PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus>
    {
        public override PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus Read(
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
            return new PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus ReadAsPropertyName(
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
            return new PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderRequestPrescriptionsItemOverridesClinicalDiagnosisReviewStatus value,
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
