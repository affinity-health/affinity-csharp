using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem.ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItemSerializer)
)]
[Serializable]
public readonly record struct ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem
    : IStringEnum
{
    public static readonly ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem Ambient =
        new(Values.Ambient);

    public static readonly ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem Refrigerated =
        new(Values.Refrigerated);

    public ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem(string value)
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
    public static ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem FromCustom(
        string value
    )
    {
        return new ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem(value);
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
        ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem value
    ) => value.Value;

    public static explicit operator ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem(
        string value
    ) => new(value);

    internal class ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItemSerializer
        : JsonConverter<ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem>
    {
        public override ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem Read(
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
            return new ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem ReadAsPropertyName(
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
            return new ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPharmaciesResponseDataItemShippingOptionsItemTemperaturesItem value,
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
