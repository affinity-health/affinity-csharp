using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule.ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledScheduleSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule
    : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule Ii =
        new(Values.Ii);

    public static readonly ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule Iii =
        new(Values.Iii);

    public static readonly ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule Iv =
        new(Values.Iv);

    public static readonly ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule V =
        new(Values.V);

    public ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule(string value)
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
    public static ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule FromCustom(
        string value
    )
    {
        return new ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule(
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
        ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule value
    ) => value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule(
        string value
    ) => new(value);

    internal class ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledScheduleSerializer
        : JsonConverter<ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule>
    {
        public override ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule Read(
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
            return new ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemPrescriptionRequirementsControlledSchedule value,
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
        public const string Ii = "II";

        public const string Iii = "III";

        public const string Iv = "IV";

        public const string V = "V";
    }
}
