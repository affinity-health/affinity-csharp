using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemOrderingShipping.ListCatalogItemsResponseDataItemOrderingShippingSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemOrderingShipping : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemOrderingShipping Prescription = new(
        Values.Prescription
    );

    public static readonly ListCatalogItemsResponseDataItemOrderingShipping AccompanyingPrescription =
        new(Values.AccompanyingPrescription);

    public ListCatalogItemsResponseDataItemOrderingShipping(string value)
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
    public static ListCatalogItemsResponseDataItemOrderingShipping FromCustom(string value)
    {
        return new ListCatalogItemsResponseDataItemOrderingShipping(value);
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
        ListCatalogItemsResponseDataItemOrderingShipping value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemOrderingShipping value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListCatalogItemsResponseDataItemOrderingShipping value
    ) => value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemOrderingShipping(
        string value
    ) => new(value);

    internal class ListCatalogItemsResponseDataItemOrderingShippingSerializer
        : JsonConverter<ListCatalogItemsResponseDataItemOrderingShipping>
    {
        public override ListCatalogItemsResponseDataItemOrderingShipping Read(
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
            return new ListCatalogItemsResponseDataItemOrderingShipping(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemOrderingShipping value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemOrderingShipping ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemOrderingShipping(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemOrderingShipping value,
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
        public const string Prescription = "prescription";

        public const string AccompanyingPrescription = "accompanying_prescription";
    }
}
