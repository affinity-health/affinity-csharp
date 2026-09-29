using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationType.AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationTypeSerializer)
)]
[Serializable]
public readonly record struct AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationType
    : IStringEnum
{
    public static readonly AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationType Patient =
        new(Values.Patient);

    public AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationType(string value)
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
    public static AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationType FromCustom(
        string value
    )
    {
        return new AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationType(value);
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
        AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationType value
    ) => value.Value;

    public static explicit operator AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationType(
        string value
    ) => new(value);

    internal class AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationTypeSerializer
        : JsonConverter<AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationType>
    {
        public override AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationType Read(
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
            return new AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationType(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationType ReadAsPropertyName(
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
            return new AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationType(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AddOrderPrescriptionRequestPrescriptionDispensingShippingDestinationType value,
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
        public const string Patient = "patient";
    }
}
