using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource.RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSourceSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource Catalog =
        new(Values.Catalog);

    public static readonly RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource Pharmacy =
        new(Values.Pharmacy);

    public static readonly RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource Rxnorm =
        new(Values.Rxnorm);

    public RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource(string value)
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
    public static RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource(value);
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
        RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSourceSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource>
    {
        public override RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource Read(
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
            return new RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseOptionsDoseUnitsItemSource value,
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
        public const string Catalog = "catalog";

        public const string Pharmacy = "pharmacy";

        public const string Rxnorm = "rxnorm";
    }
}
