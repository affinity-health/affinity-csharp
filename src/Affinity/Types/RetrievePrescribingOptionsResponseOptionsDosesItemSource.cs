using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseOptionsDosesItemSource.RetrievePrescribingOptionsResponseOptionsDosesItemSourceSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseOptionsDosesItemSource : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseOptionsDosesItemSource Catalog = new(
        Values.Catalog
    );

    public static readonly RetrievePrescribingOptionsResponseOptionsDosesItemSource Pharmacy = new(
        Values.Pharmacy
    );

    public static readonly RetrievePrescribingOptionsResponseOptionsDosesItemSource Rxnorm = new(
        Values.Rxnorm
    );

    public RetrievePrescribingOptionsResponseOptionsDosesItemSource(string value)
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
    public static RetrievePrescribingOptionsResponseOptionsDosesItemSource FromCustom(string value)
    {
        return new RetrievePrescribingOptionsResponseOptionsDosesItemSource(value);
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
        RetrievePrescribingOptionsResponseOptionsDosesItemSource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseOptionsDosesItemSource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseOptionsDosesItemSource value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseOptionsDosesItemSource(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseOptionsDosesItemSourceSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseOptionsDosesItemSource>
    {
        public override RetrievePrescribingOptionsResponseOptionsDosesItemSource Read(
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
            return new RetrievePrescribingOptionsResponseOptionsDosesItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseOptionsDosesItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseOptionsDosesItemSource ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseOptionsDosesItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseOptionsDosesItemSource value,
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
