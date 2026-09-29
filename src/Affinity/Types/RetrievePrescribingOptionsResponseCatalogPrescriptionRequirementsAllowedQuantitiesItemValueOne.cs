using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne.RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOneSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne Infinity =
        new(Values.Infinity);

    public static readonly RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne NaN =
        new(Values.NaN);

    public RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne(
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
    public static RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne(
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
        RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOneSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne>
    {
        public override RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne Read(
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
            return new RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogPrescriptionRequirementsAllowedQuantitiesItemValueOne value,
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
        public const string Infinity = "Infinity";

        public const string NaN = "NaN";
    }
}
