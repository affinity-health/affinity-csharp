using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne.PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOneSerializer)
)]
[Serializable]
public readonly record struct PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne
    : IStringEnum
{
    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne Infinity =
        new(Values.Infinity);

    public static readonly PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne NaN =
        new(Values.NaN);

    public PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne(
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
    public static PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne FromCustom(
        string value
    )
    {
        return new PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne(
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
        PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne value
    ) => value.Value;

    public static explicit operator PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne(
        string value
    ) => new(value);

    internal class PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOneSerializer
        : JsonConverter<PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne>
    {
        public override PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne Read(
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
            return new PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne ReadAsPropertyName(
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
            return new PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderResponseOrderInputPrescriptionsItemClinicalObservationsItemValueOne value,
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
