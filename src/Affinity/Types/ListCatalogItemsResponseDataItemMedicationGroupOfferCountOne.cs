using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne.ListCatalogItemsResponseDataItemMedicationGroupOfferCountOneSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne
    : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne Infinity =
        new(Values.Infinity);

    public static readonly ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne NaN = new(
        Values.NaN
    );

    public ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne(string value)
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
    public static ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne FromCustom(
        string value
    )
    {
        return new ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne(value);
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
        ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne value
    ) => value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne(
        string value
    ) => new(value);

    internal class ListCatalogItemsResponseDataItemMedicationGroupOfferCountOneSerializer
        : JsonConverter<ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne>
    {
        public override ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne Read(
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
            return new ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemMedicationGroupOfferCountOne value,
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
