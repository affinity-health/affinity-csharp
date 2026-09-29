using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem.ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItemSerializer)
)]
[Serializable]
public readonly record struct ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem
    : IStringEnum
{
    public static readonly ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem Patient =
        new(Values.Patient);

    public static readonly ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem Practice =
        new(Values.Practice);

    public ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem(string value)
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
    public static ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem FromCustom(
        string value
    )
    {
        return new ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem(value);
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
        ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem value
    ) => value.Value;

    public static explicit operator ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem(
        string value
    ) => new(value);

    internal class ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItemSerializer
        : JsonConverter<ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem>
    {
        public override ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem Read(
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
            return new ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem ReadAsPropertyName(
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
            return new ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPharmaciesResponseDataItemShippingOptionsItemDestinationTypesItem value,
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
