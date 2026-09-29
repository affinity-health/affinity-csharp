using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseOptionsRoutesItemSource.RetrievePrescribingOptionsResponseOptionsRoutesItemSourceSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseOptionsRoutesItemSource
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseOptionsRoutesItemSource Catalog = new(
        Values.Catalog
    );

    public static readonly RetrievePrescribingOptionsResponseOptionsRoutesItemSource Pharmacy = new(
        Values.Pharmacy
    );

    public static readonly RetrievePrescribingOptionsResponseOptionsRoutesItemSource Rxnorm = new(
        Values.Rxnorm
    );

    public RetrievePrescribingOptionsResponseOptionsRoutesItemSource(string value)
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
    public static RetrievePrescribingOptionsResponseOptionsRoutesItemSource FromCustom(string value)
    {
        return new RetrievePrescribingOptionsResponseOptionsRoutesItemSource(value);
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
        RetrievePrescribingOptionsResponseOptionsRoutesItemSource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseOptionsRoutesItemSource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseOptionsRoutesItemSource value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseOptionsRoutesItemSource(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseOptionsRoutesItemSourceSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseOptionsRoutesItemSource>
    {
        public override RetrievePrescribingOptionsResponseOptionsRoutesItemSource Read(
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
            return new RetrievePrescribingOptionsResponseOptionsRoutesItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseOptionsRoutesItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseOptionsRoutesItemSource ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseOptionsRoutesItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseOptionsRoutesItemSource value,
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
