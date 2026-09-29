using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem.RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItemSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem Ambient =
        new(Values.Ambient);

    public static readonly RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem Refrigerated =
        new(Values.Refrigerated);

    public RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem(
        string value
    )
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
    public static RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem(
            value
        );
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
        RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItemSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem>
    {
        public override RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem Read(
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
            return new RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogShippingOptionsItemTemperaturesItem value,
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
