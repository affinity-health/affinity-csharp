using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponsePresetsItemSource.RetrievePrescribingOptionsResponsePresetsItemSourceSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponsePresetsItemSource : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponsePresetsItemSource Affinity = new(
        Values.Affinity
    );

    public static readonly RetrievePrescribingOptionsResponsePresetsItemSource Pharmacy = new(
        Values.Pharmacy
    );

    public static readonly RetrievePrescribingOptionsResponsePresetsItemSource Catalog = new(
        Values.Catalog
    );

    public RetrievePrescribingOptionsResponsePresetsItemSource(string value)
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
    public static RetrievePrescribingOptionsResponsePresetsItemSource FromCustom(string value)
    {
        return new RetrievePrescribingOptionsResponsePresetsItemSource(value);
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
        RetrievePrescribingOptionsResponsePresetsItemSource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponsePresetsItemSource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponsePresetsItemSource value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponsePresetsItemSource(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponsePresetsItemSourceSerializer
        : JsonConverter<RetrievePrescribingOptionsResponsePresetsItemSource>
    {
        public override RetrievePrescribingOptionsResponsePresetsItemSource Read(
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
            return new RetrievePrescribingOptionsResponsePresetsItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponsePresetsItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponsePresetsItemSource ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponsePresetsItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponsePresetsItemSource value,
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
        public const string Affinity = "affinity";

        public const string Pharmacy = "pharmacy";

        public const string Catalog = "catalog";
    }
}
