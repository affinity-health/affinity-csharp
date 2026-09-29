using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne.ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOneSerializer)
)]
[Serializable]
public readonly record struct ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne : IStringEnum
{
    public static readonly ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne Infinity = new(
        Values.Infinity
    );

    public static readonly ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne NaN = new(
        Values.NaN
    );

    public ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne(string value)
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
    public static ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne FromCustom(string value)
    {
        return new ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne(value);
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
        ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne value
    ) => value.Value;

    public static explicit operator ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne(
        string value
    ) => new(value);

    internal class ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOneSerializer
        : JsonConverter<ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne>
    {
        public override ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne Read(
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
            return new ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne ReadAsPropertyName(
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
            return new ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemPrescriptionsItemDaysSupplyOne value,
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
