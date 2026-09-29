using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPharmaciesResponseDataItemShippingOptionsItemCurrency.ListPharmaciesResponseDataItemShippingOptionsItemCurrencySerializer)
)]
[Serializable]
public readonly record struct ListPharmaciesResponseDataItemShippingOptionsItemCurrency
    : IStringEnum
{
    public static readonly ListPharmaciesResponseDataItemShippingOptionsItemCurrency Usd = new(
        Values.Usd
    );

    public ListPharmaciesResponseDataItemShippingOptionsItemCurrency(string value)
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
    public static ListPharmaciesResponseDataItemShippingOptionsItemCurrency FromCustom(string value)
    {
        return new ListPharmaciesResponseDataItemShippingOptionsItemCurrency(value);
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
        ListPharmaciesResponseDataItemShippingOptionsItemCurrency value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPharmaciesResponseDataItemShippingOptionsItemCurrency value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListPharmaciesResponseDataItemShippingOptionsItemCurrency value
    ) => value.Value;

    public static explicit operator ListPharmaciesResponseDataItemShippingOptionsItemCurrency(
        string value
    ) => new(value);

    internal class ListPharmaciesResponseDataItemShippingOptionsItemCurrencySerializer
        : JsonConverter<ListPharmaciesResponseDataItemShippingOptionsItemCurrency>
    {
        public override ListPharmaciesResponseDataItemShippingOptionsItemCurrency Read(
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
            return new ListPharmaciesResponseDataItemShippingOptionsItemCurrency(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPharmaciesResponseDataItemShippingOptionsItemCurrency value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPharmaciesResponseDataItemShippingOptionsItemCurrency ReadAsPropertyName(
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
            return new ListPharmaciesResponseDataItemShippingOptionsItemCurrency(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPharmaciesResponseDataItemShippingOptionsItemCurrency value,
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
        public const string Usd = "USD";
    }
}
