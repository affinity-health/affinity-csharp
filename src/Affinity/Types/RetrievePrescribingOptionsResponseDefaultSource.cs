using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseDefaultSource.RetrievePrescribingOptionsResponseDefaultSourceSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseDefaultSource : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseDefaultSource Affinity = new(
        Values.Affinity
    );

    public static readonly RetrievePrescribingOptionsResponseDefaultSource Catalog = new(
        Values.Catalog
    );

    public static readonly RetrievePrescribingOptionsResponseDefaultSource Pharmacy = new(
        Values.Pharmacy
    );

    public RetrievePrescribingOptionsResponseDefaultSource(string value)
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
    public static RetrievePrescribingOptionsResponseDefaultSource FromCustom(string value)
    {
        return new RetrievePrescribingOptionsResponseDefaultSource(value);
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
        RetrievePrescribingOptionsResponseDefaultSource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseDefaultSource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(RetrievePrescribingOptionsResponseDefaultSource value) =>
        value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseDefaultSource(string value) =>
        new(value);

    internal class RetrievePrescribingOptionsResponseDefaultSourceSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseDefaultSource>
    {
        public override RetrievePrescribingOptionsResponseDefaultSource Read(
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
            return new RetrievePrescribingOptionsResponseDefaultSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseDefaultSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseDefaultSource ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseDefaultSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseDefaultSource value,
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

        public const string Catalog = "catalog";

        public const string Pharmacy = "pharmacy";
    }
}
