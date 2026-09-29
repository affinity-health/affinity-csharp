using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason.ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason
    : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason NotRequired =
        new(Values.NotRequired);

    public static readonly ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason Optional =
        new(Values.Optional);

    public static readonly ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason Required =
        new(Values.Required);

    public ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason(string value)
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
    public static ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason FromCustom(
        string value
    )
    {
        return new ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason(value);
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
        ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason value
    ) => value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason(
        string value
    ) => new(value);

    internal class ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonSerializer
        : JsonConverter<ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason>
    {
        public override ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason Read(
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
            return new ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReason value,
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
        public const string NotRequired = "not_required";

        public const string Optional = "optional";

        public const string Required = "required";
    }
}
