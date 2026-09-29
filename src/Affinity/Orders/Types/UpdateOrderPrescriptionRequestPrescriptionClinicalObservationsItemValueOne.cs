using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne.UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOneSerializer)
)]
[Serializable]
public readonly record struct UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne
    : IStringEnum
{
    public static readonly UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne Infinity =
        new(Values.Infinity);

    public static readonly UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne NaN =
        new(Values.NaN);

    public UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne(string value)
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
    public static UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne FromCustom(
        string value
    )
    {
        return new UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne(
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
        UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne value
    ) => value.Value;

    public static explicit operator UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne(
        string value
    ) => new(value);

    internal class UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOneSerializer
        : JsonConverter<UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne>
    {
        public override UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne Read(
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
            return new UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne ReadAsPropertyName(
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
            return new UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateOrderPrescriptionRequestPrescriptionClinicalObservationsItemValueOne value,
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
