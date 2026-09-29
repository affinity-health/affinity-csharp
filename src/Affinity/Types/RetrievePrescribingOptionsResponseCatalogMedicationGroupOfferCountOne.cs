using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne.RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOneSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne Infinity =
        new(Values.Infinity);

    public static readonly RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne NaN =
        new(Values.NaN);

    public RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne(string value)
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
    public static RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne(value);
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
        RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOneSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne>
    {
        public override RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne Read(
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
            return new RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogMedicationGroupOfferCountOne value,
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
