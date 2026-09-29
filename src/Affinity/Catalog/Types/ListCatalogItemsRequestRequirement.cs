using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsRequestRequirement.ListCatalogItemsRequestRequirementSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsRequestRequirement : IStringEnum
{
    public static readonly ListCatalogItemsRequestRequirement All = new(Values.All);

    public static readonly ListCatalogItemsRequestRequirement OfficeUse = new(Values.OfficeUse);

    public static readonly ListCatalogItemsRequestRequirement PatientSpecific = new(
        Values.PatientSpecific
    );

    public ListCatalogItemsRequestRequirement(string value)
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
    public static ListCatalogItemsRequestRequirement FromCustom(string value)
    {
        return new ListCatalogItemsRequestRequirement(value);
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

    public static bool operator ==(ListCatalogItemsRequestRequirement value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListCatalogItemsRequestRequirement value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListCatalogItemsRequestRequirement value) => value.Value;

    public static explicit operator ListCatalogItemsRequestRequirement(string value) => new(value);

    internal class ListCatalogItemsRequestRequirementSerializer
        : JsonConverter<ListCatalogItemsRequestRequirement>
    {
        public override ListCatalogItemsRequestRequirement Read(
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
            return new ListCatalogItemsRequestRequirement(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsRequestRequirement value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsRequestRequirement ReadAsPropertyName(
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
            return new ListCatalogItemsRequestRequirement(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsRequestRequirement value,
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
        public const string All = "all";

        public const string OfficeUse = "office_use";

        public const string PatientSpecific = "patient_specific";
    }
}
