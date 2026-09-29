using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListShippingOptionsResponseItemCurrency.ListShippingOptionsResponseItemCurrencySerializer)
)]
[Serializable]
public readonly record struct ListShippingOptionsResponseItemCurrency : IStringEnum
{
    public static readonly ListShippingOptionsResponseItemCurrency Usd = new(Values.Usd);

    public ListShippingOptionsResponseItemCurrency(string value)
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
    public static ListShippingOptionsResponseItemCurrency FromCustom(string value)
    {
        return new ListShippingOptionsResponseItemCurrency(value);
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

    public static bool operator ==(ListShippingOptionsResponseItemCurrency value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListShippingOptionsResponseItemCurrency value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListShippingOptionsResponseItemCurrency value) =>
        value.Value;

    public static explicit operator ListShippingOptionsResponseItemCurrency(string value) =>
        new(value);

    internal class ListShippingOptionsResponseItemCurrencySerializer
        : JsonConverter<ListShippingOptionsResponseItemCurrency>
    {
        public override ListShippingOptionsResponseItemCurrency Read(
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
            return new ListShippingOptionsResponseItemCurrency(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListShippingOptionsResponseItemCurrency value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListShippingOptionsResponseItemCurrency ReadAsPropertyName(
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
            return new ListShippingOptionsResponseItemCurrency(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListShippingOptionsResponseItemCurrency value,
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
