using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext.RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContextSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext NotSupported =
        new(Values.NotSupported);

    public static readonly RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext Optional =
        new(Values.Optional);

    public static readonly RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext Required =
        new(Values.Required);

    public RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext(
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
    public static RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext(
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
        RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContextSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext>
    {
        public override RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext Read(
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
            return new RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsCompoundingReasonContext value,
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
        public const string NotSupported = "not_supported";

        public const string Optional = "optional";

        public const string Required = "required";
    }
}
