using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderResponsePrescriptionsItemDaysSupplySource.PreviewOrderResponsePrescriptionsItemDaysSupplySourceSerializer)
)]
[Serializable]
public readonly record struct PreviewOrderResponsePrescriptionsItemDaysSupplySource : IStringEnum
{
    public static readonly PreviewOrderResponsePrescriptionsItemDaysSupplySource Manual = new(
        Values.Manual
    );

    public static readonly PreviewOrderResponsePrescriptionsItemDaysSupplySource Calculated = new(
        Values.Calculated
    );

    public static readonly PreviewOrderResponsePrescriptionsItemDaysSupplySource Preset = new(
        Values.Preset
    );

    public static readonly PreviewOrderResponsePrescriptionsItemDaysSupplySource Missing = new(
        Values.Missing
    );

    public PreviewOrderResponsePrescriptionsItemDaysSupplySource(string value)
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
    public static PreviewOrderResponsePrescriptionsItemDaysSupplySource FromCustom(string value)
    {
        return new PreviewOrderResponsePrescriptionsItemDaysSupplySource(value);
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
        PreviewOrderResponsePrescriptionsItemDaysSupplySource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderResponsePrescriptionsItemDaysSupplySource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PreviewOrderResponsePrescriptionsItemDaysSupplySource value
    ) => value.Value;

    public static explicit operator PreviewOrderResponsePrescriptionsItemDaysSupplySource(
        string value
    ) => new(value);

    internal class PreviewOrderResponsePrescriptionsItemDaysSupplySourceSerializer
        : JsonConverter<PreviewOrderResponsePrescriptionsItemDaysSupplySource>
    {
        public override PreviewOrderResponsePrescriptionsItemDaysSupplySource Read(
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
            return new PreviewOrderResponsePrescriptionsItemDaysSupplySource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderResponsePrescriptionsItemDaysSupplySource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderResponsePrescriptionsItemDaysSupplySource ReadAsPropertyName(
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
            return new PreviewOrderResponsePrescriptionsItemDaysSupplySource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderResponsePrescriptionsItemDaysSupplySource value,
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
        public const string Manual = "manual";

        public const string Calculated = "calculated";

        public const string Preset = "preset";

        public const string Missing = "missing";
    }
}
