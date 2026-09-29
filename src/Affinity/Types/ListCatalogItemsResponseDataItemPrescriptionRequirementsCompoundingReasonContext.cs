using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext.ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContextSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext
    : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext NotSupported =
        new(Values.NotSupported);

    public static readonly ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext Optional =
        new(Values.Optional);

    public static readonly ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext Required =
        new(Values.Required);

    public ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext(
        string value
    )
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
    public static ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext FromCustom(
        string value
    )
    {
        return new ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext(
            value
        );
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
        ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext value
    ) => value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext(
        string value
    ) => new(value);

    internal class ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContextSerializer
        : JsonConverter<ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext>
    {
        public override ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext Read(
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
            return new ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPrescriptionRequirementsCompoundingReasonContext value,
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

        public const string Required = "required";
    }
}
