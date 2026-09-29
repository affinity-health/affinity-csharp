using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Orders;

[JsonConverter(
    typeof(CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType.CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationTypeSerializer)
)]
[Serializable]
public readonly record struct CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType
    : IStringEnum
{
    public static readonly CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType Patient =
        new(Values.Patient);

    public CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType(
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
    public static CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType FromCustom(
        string value
    )
    {
        return new CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType(
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
        CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType value
    ) => value.Value;

    public static explicit operator CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType(
        string value
    ) => new(value);

    internal class CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationTypeSerializer
        : JsonConverter<CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType>
    {
        public override CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType Read(
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
            return new CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType ReadAsPropertyName(
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
            return new CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderBatchRequestOrdersItemPrescriptionsItemDispensingShippingDestinationType value,
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
