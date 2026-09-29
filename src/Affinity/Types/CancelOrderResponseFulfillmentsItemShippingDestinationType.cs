using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CancelOrderResponseFulfillmentsItemShippingDestinationType.CancelOrderResponseFulfillmentsItemShippingDestinationTypeSerializer)
)]
[Serializable]
public readonly record struct CancelOrderResponseFulfillmentsItemShippingDestinationType
    : IStringEnum
{
    public static readonly CancelOrderResponseFulfillmentsItemShippingDestinationType Patient = new(
        Values.Patient
    );

    public static readonly CancelOrderResponseFulfillmentsItemShippingDestinationType Practice =
        new(Values.Practice);

    public CancelOrderResponseFulfillmentsItemShippingDestinationType(string value)
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
    public static CancelOrderResponseFulfillmentsItemShippingDestinationType FromCustom(
        string value
    )
    {
        return new CancelOrderResponseFulfillmentsItemShippingDestinationType(value);
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
        CancelOrderResponseFulfillmentsItemShippingDestinationType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CancelOrderResponseFulfillmentsItemShippingDestinationType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CancelOrderResponseFulfillmentsItemShippingDestinationType value
    ) => value.Value;

    public static explicit operator CancelOrderResponseFulfillmentsItemShippingDestinationType(
        string value
    ) => new(value);

    internal class CancelOrderResponseFulfillmentsItemShippingDestinationTypeSerializer
        : JsonConverter<CancelOrderResponseFulfillmentsItemShippingDestinationType>
    {
        public override CancelOrderResponseFulfillmentsItemShippingDestinationType Read(
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
            return new CancelOrderResponseFulfillmentsItemShippingDestinationType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelOrderResponseFulfillmentsItemShippingDestinationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelOrderResponseFulfillmentsItemShippingDestinationType ReadAsPropertyName(
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
            return new CancelOrderResponseFulfillmentsItemShippingDestinationType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelOrderResponseFulfillmentsItemShippingDestinationType value,
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
