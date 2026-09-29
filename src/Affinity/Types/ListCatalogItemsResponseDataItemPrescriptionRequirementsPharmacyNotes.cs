using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes.ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotesSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes
    : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes NotSupported =
        new(Values.NotSupported);

    public static readonly ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes Optional =
        new(Values.Optional);

    public ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes(string value)
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
    public static ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes FromCustom(
        string value
    )
    {
        return new ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes(value);
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
        ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes value
    ) => value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes(
        string value
    ) => new(value);

    internal class ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotesSerializer
        : JsonConverter<ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes>
    {
        public override ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes Read(
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
            return new ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPrescriptionRequirementsPharmacyNotes value,
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
        public const string NotSupported = "not_supported";

        public const string Optional = "optional";
    }
}
