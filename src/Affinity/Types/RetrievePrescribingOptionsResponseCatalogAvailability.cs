using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCatalogAvailability.RetrievePrescribingOptionsResponseCatalogAvailabilitySerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseCatalogAvailability : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseCatalogAvailability Available = new(
        Values.Available
    );

    public static readonly RetrievePrescribingOptionsResponseCatalogAvailability Backordered = new(
        Values.Backordered
    );

    public static readonly RetrievePrescribingOptionsResponseCatalogAvailability Unavailable = new(
        Values.Unavailable
    );

    public static readonly RetrievePrescribingOptionsResponseCatalogAvailability Unknown = new(
        Values.Unknown
    );

    public RetrievePrescribingOptionsResponseCatalogAvailability(string value)
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
    public static RetrievePrescribingOptionsResponseCatalogAvailability FromCustom(string value)
    {
        return new RetrievePrescribingOptionsResponseCatalogAvailability(value);
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
        RetrievePrescribingOptionsResponseCatalogAvailability value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseCatalogAvailability value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseCatalogAvailability value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseCatalogAvailability(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseCatalogAvailabilitySerializer
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogAvailability>
    {
        public override RetrievePrescribingOptionsResponseCatalogAvailability Read(
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
            return new RetrievePrescribingOptionsResponseCatalogAvailability(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogAvailability value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseCatalogAvailability ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseCatalogAvailability(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogAvailability value,
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
        public const string Available = "available";

        public const string Backordered = "backordered";

        public const string Unavailable = "unavailable";

        public const string Unknown = "unknown";
    }
}
