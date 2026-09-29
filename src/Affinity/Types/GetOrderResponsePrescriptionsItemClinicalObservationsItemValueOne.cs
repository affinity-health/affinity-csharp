using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne.GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOneSerializer)
)]
[Serializable]
public readonly record struct GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne
    : IStringEnum
{
    public static readonly GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne Infinity =
        new(Values.Infinity);

    public static readonly GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne NaN =
        new(Values.NaN);

    public GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne(string value)
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
    public static GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne FromCustom(
        string value
    )
    {
        return new GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne(value);
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
        GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne value
    ) => value.Value;

    public static explicit operator GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne(
        string value
    ) => new(value);

    internal class GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOneSerializer
        : JsonConverter<GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne>
    {
        public override GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne Read(
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
            return new GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne ReadAsPropertyName(
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
            return new GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrderResponsePrescriptionsItemClinicalObservationsItemValueOne value,
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
