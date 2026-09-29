using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution.ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitutionSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution
    : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution NotSupported =
        new(Values.NotSupported);

    public static readonly ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution Optional =
        new(Values.Optional);

    public ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution(string value)
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
    public static ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution FromCustom(
        string value
    )
    {
        return new ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution(value);
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
        ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution value
    ) => value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution(
        string value
    ) => new(value);

    internal class ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitutionSerializer
        : JsonConverter<ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution>
    {
        public override ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution Read(
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
            return new ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPrescriptionRequirementsSubstitution value,
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
