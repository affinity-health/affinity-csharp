using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature.PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperatureSerializer)
)]
[Serializable]
public readonly record struct PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature
    : IStringEnum
{
    public static readonly PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature Ambient =
        new(Values.Ambient);

    public static readonly PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature Refrigerated =
        new(Values.Refrigerated);

    public PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature(string value)
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
    public static PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature FromCustom(
        string value
    )
    {
        return new PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature(value);
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
        PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature value
    ) => value.Value;

    public static explicit operator PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature(
        string value
    ) => new(value);

    internal class PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperatureSerializer
        : JsonConverter<PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature>
    {
        public override PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature Read(
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
            return new PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature ReadAsPropertyName(
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
            return new PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderResponsePrescriptionsItemShippingOptionsItemTemperature value,
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
        public const string Ambient = "ambient";

        public const string Refrigerated = "refrigerated";
    }
}
