using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCatalogCompositionStatus.RetrievePrescribingOptionsResponseCatalogCompositionStatusSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseCatalogCompositionStatus
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseCatalogCompositionStatus Complete =
        new(Values.Complete);

    public static readonly RetrievePrescribingOptionsResponseCatalogCompositionStatus Partial = new(
        Values.Partial
    );

    public static readonly RetrievePrescribingOptionsResponseCatalogCompositionStatus Unresolved =
        new(Values.Unresolved);

    public RetrievePrescribingOptionsResponseCatalogCompositionStatus(string value)
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
    public static RetrievePrescribingOptionsResponseCatalogCompositionStatus FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponseCatalogCompositionStatus(value);
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
        RetrievePrescribingOptionsResponseCatalogCompositionStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseCatalogCompositionStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseCatalogCompositionStatus value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseCatalogCompositionStatus(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseCatalogCompositionStatusSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogCompositionStatus>
    {
        public override RetrievePrescribingOptionsResponseCatalogCompositionStatus Read(
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
            return new RetrievePrescribingOptionsResponseCatalogCompositionStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogCompositionStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseCatalogCompositionStatus ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseCatalogCompositionStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogCompositionStatus value,
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
        public const string Complete = "complete";

        public const string Partial = "partial";

        public const string Unresolved = "unresolved";
    }
}
