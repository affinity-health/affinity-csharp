using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseMedicationRxnormSystem.RetrievePrescribingOptionsResponseMedicationRxnormSystemSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseMedicationRxnormSystem : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseMedicationRxnormSystem Rxnorm = new(
        Values.Rxnorm
    );

    public RetrievePrescribingOptionsResponseMedicationRxnormSystem(string value)
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
    public static RetrievePrescribingOptionsResponseMedicationRxnormSystem FromCustom(string value)
    {
        return new RetrievePrescribingOptionsResponseMedicationRxnormSystem(value);
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
        RetrievePrescribingOptionsResponseMedicationRxnormSystem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseMedicationRxnormSystem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseMedicationRxnormSystem value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseMedicationRxnormSystem(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseMedicationRxnormSystemSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseMedicationRxnormSystem>
    {
        public override RetrievePrescribingOptionsResponseMedicationRxnormSystem Read(
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
            return new RetrievePrescribingOptionsResponseMedicationRxnormSystem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseMedicationRxnormSystem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseMedicationRxnormSystem ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseMedicationRxnormSystem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseMedicationRxnormSystem value,
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
        public const string Rxnorm = "rxnorm";
    }
}
