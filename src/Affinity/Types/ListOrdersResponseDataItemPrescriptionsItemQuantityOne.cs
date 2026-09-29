using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListOrdersResponseDataItemPrescriptionsItemQuantityOne.ListOrdersResponseDataItemPrescriptionsItemQuantityOneSerializer)
)]
[Serializable]
public readonly record struct ListOrdersResponseDataItemPrescriptionsItemQuantityOne : IStringEnum
{
    public static readonly ListOrdersResponseDataItemPrescriptionsItemQuantityOne Infinity = new(
        Values.Infinity
    );

    public static readonly ListOrdersResponseDataItemPrescriptionsItemQuantityOne NaN = new(
        Values.NaN
    );

    public ListOrdersResponseDataItemPrescriptionsItemQuantityOne(string value)
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
    public static ListOrdersResponseDataItemPrescriptionsItemQuantityOne FromCustom(string value)
    {
        return new ListOrdersResponseDataItemPrescriptionsItemQuantityOne(value);
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
        ListOrdersResponseDataItemPrescriptionsItemQuantityOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListOrdersResponseDataItemPrescriptionsItemQuantityOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListOrdersResponseDataItemPrescriptionsItemQuantityOne value
    ) => value.Value;

    public static explicit operator ListOrdersResponseDataItemPrescriptionsItemQuantityOne(
        string value
    ) => new(value);

    internal class ListOrdersResponseDataItemPrescriptionsItemQuantityOneSerializer
        : JsonConverter<ListOrdersResponseDataItemPrescriptionsItemQuantityOne>
    {
        public override ListOrdersResponseDataItemPrescriptionsItemQuantityOne Read(
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
            return new ListOrdersResponseDataItemPrescriptionsItemQuantityOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemPrescriptionsItemQuantityOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseDataItemPrescriptionsItemQuantityOne ReadAsPropertyName(
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
            return new ListOrdersResponseDataItemPrescriptionsItemQuantityOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemPrescriptionsItemQuantityOne value,
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
        public const string Infinity = "Infinity";

        public const string NaN = "NaN";
    }
}
