using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne.RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOneSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne Infinity =
        new(Values.Infinity);

    public static readonly RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne NaN =
        new(Values.NaN);

    public RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne(string value)
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
    public static RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne(value);
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
        RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOneSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne>
    {
        public override RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne Read(
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
            return new RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogMedicationGroupPharmacyCountOne value,
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
