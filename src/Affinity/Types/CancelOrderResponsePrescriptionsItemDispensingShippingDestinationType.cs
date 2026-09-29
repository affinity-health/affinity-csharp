using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType.CancelOrderResponsePrescriptionsItemDispensingShippingDestinationTypeSerializer)
)]
[Serializable]
public readonly record struct CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType
    : IStringEnum
{
    public static readonly CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType Patient =
        new(Values.Patient);

    public static readonly CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType Practice =
        new(Values.Practice);

    public CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType(string value)
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
    public static CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType FromCustom(
        string value
    )
    {
        return new CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType(value);
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
        CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType value
    ) => value.Value;

    public static explicit operator CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType(
        string value
    ) => new(value);

    internal class CancelOrderResponsePrescriptionsItemDispensingShippingDestinationTypeSerializer
        : JsonConverter<CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType>
    {
        public override CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType Read(
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
            return new CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType ReadAsPropertyName(
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
            return new CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelOrderResponsePrescriptionsItemDispensingShippingDestinationType value,
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

        public const string Practice = "practice";
    }
}
