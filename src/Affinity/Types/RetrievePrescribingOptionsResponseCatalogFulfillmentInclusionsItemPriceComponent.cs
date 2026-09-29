using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponent.RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponentSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponent
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponent Shipping =
        new(Values.Shipping);

    public RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponent(
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
    public static RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponent FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponent(
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
        RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponent value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponent value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponent value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponent(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponentSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponent>
    {
        public override RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponent Read(
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
            return new RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponent(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponent value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponent ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponent(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemPriceComponent value,
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
        public const string Shipping = "shipping";
    }
}
