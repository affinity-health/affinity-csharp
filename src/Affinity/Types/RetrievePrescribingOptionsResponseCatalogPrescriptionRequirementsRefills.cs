using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills.RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefillsSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills NotSupported =
        new(Values.NotSupported);

    public static readonly RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills Optional =
        new(Values.Optional);

    public RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills(string value)
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
    public static RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills(value);
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
        RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefillsSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills>
    {
        public override RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills Read(
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
            return new RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsRefills value,
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
    }
}
