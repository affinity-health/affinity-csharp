using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne.ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOneSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne
    : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne Infinity =
        new(Values.Infinity);

    public static readonly ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne NaN =
        new(Values.NaN);

    public ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne(string value)
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
    public static ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne FromCustom(
        string value
    )
    {
        return new ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne(value);
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
        ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne value
    ) => value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne(
        string value
    ) => new(value);

    internal class ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOneSerializer
        : JsonConverter<ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne>
    {
        public override ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne Read(
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
            return new ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemMedicationGroupPharmacyCountOne value,
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
