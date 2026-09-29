using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind.RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKindSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind Suggested =
        new(Values.Suggested);

    public static readonly RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind Template =
        new(Values.Template);

    public RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind(string value)
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
    public static RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind(value);
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
        RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKindSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind>
    {
        public override RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind Read(
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
            return new RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogCatalogDetailsDirectionsItemKind value,
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
        public const string Suggested = "suggested";

        public const string Template = "template";
    }
}
