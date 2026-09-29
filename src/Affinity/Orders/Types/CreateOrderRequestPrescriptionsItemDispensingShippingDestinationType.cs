using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreateOrderRequestPrescriptionsItemDispensingShippingDestinationType.CreateOrderRequestPrescriptionsItemDispensingShippingDestinationTypeSerializer)
)]
[Serializable]
public readonly record struct CreateOrderRequestPrescriptionsItemDispensingShippingDestinationType
    : IStringEnum
{
    public static readonly CreateOrderRequestPrescriptionsItemDispensingShippingDestinationType Patient =
        new(Values.Patient);

    public CreateOrderRequestPrescriptionsItemDispensingShippingDestinationType(string value)
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
    public static CreateOrderRequestPrescriptionsItemDispensingShippingDestinationType FromCustom(
        string value
    )
    {
        return new CreateOrderRequestPrescriptionsItemDispensingShippingDestinationType(value);
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
        CreateOrderRequestPrescriptionsItemDispensingShippingDestinationType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderRequestPrescriptionsItemDispensingShippingDestinationType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateOrderRequestPrescriptionsItemDispensingShippingDestinationType value
    ) => value.Value;

    public static explicit operator CreateOrderRequestPrescriptionsItemDispensingShippingDestinationType(
        string value
    ) => new(value);

    internal class CreateOrderRequestPrescriptionsItemDispensingShippingDestinationTypeSerializer
        : JsonConverter<CreateOrderRequestPrescriptionsItemDispensingShippingDestinationType>
    {
        public override CreateOrderRequestPrescriptionsItemDispensingShippingDestinationType Read(
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
            return new CreateOrderRequestPrescriptionsItemDispensingShippingDestinationType(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderRequestPrescriptionsItemDispensingShippingDestinationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderRequestPrescriptionsItemDispensingShippingDestinationType ReadAsPropertyName(
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
            return new CreateOrderRequestPrescriptionsItemDispensingShippingDestinationType(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderRequestPrescriptionsItemDispensingShippingDestinationType value,
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
