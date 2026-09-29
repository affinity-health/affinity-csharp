using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem.RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItemSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem Patient =
        new(Values.Patient);

    public static readonly RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem Practice =
        new(Values.Practice);

    public RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem(
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
    public static RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem(
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
        RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItemSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem>
    {
        public override RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem Read(
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
            return new RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogShippingOptionsItemDestinationTypesItem value,
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
        public const string Patient = "patient";

        public const string Practice = "practice";
    }
}
