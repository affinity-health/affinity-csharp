using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCatalogOrderingShipping.RetrievePrescribingOptionsResponseCatalogOrderingShippingSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseCatalogOrderingShipping
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseCatalogOrderingShipping Prescription =
        new(Values.Prescription);

    public static readonly RetrievePrescribingOptionsResponseCatalogOrderingShipping AccompanyingPrescription =
        new(Values.AccompanyingPrescription);

    public RetrievePrescribingOptionsResponseCatalogOrderingShipping(string value)
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
    public static RetrievePrescribingOptionsResponseCatalogOrderingShipping FromCustom(string value)
    {
        return new RetrievePrescribingOptionsResponseCatalogOrderingShipping(value);
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
        RetrievePrescribingOptionsResponseCatalogOrderingShipping value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseCatalogOrderingShipping value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseCatalogOrderingShipping value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseCatalogOrderingShipping(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseCatalogOrderingShippingSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogOrderingShipping>
    {
        public override RetrievePrescribingOptionsResponseCatalogOrderingShipping Read(
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
            return new RetrievePrescribingOptionsResponseCatalogOrderingShipping(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogOrderingShipping value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseCatalogOrderingShipping ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseCatalogOrderingShipping(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogOrderingShipping value,
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
        public const string Prescription = "prescription";

        public const string AccompanyingPrescription = "accompanying_prescription";
    }
}
