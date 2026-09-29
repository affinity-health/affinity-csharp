using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Catalog;

[JsonConverter(typeof(ListItemsRequestRequirement.ListItemsRequestRequirementSerializer))]
[Serializable]
public readonly record struct ListItemsRequestRequirement : IStringEnum
{
    public static readonly ListItemsRequestRequirement All = new(Values.All);

    public static readonly ListItemsRequestRequirement OfficeUse = new(Values.OfficeUse);

    public static readonly ListItemsRequestRequirement PatientSpecific = new(
        Values.PatientSpecific
    );

    public ListItemsRequestRequirement(string value)
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
    public static ListItemsRequestRequirement FromCustom(string value)
    {
        return new ListItemsRequestRequirement(value);
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

    public static bool operator ==(ListItemsRequestRequirement value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListItemsRequestRequirement value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListItemsRequestRequirement value) => value.Value;

    public static explicit operator ListItemsRequestRequirement(string value) => new(value);

    internal class ListItemsRequestRequirementSerializer
        : JsonConverter<ListItemsRequestRequirement>
    {
        public override ListItemsRequestRequirement Read(
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
            return new ListItemsRequestRequirement(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListItemsRequestRequirement value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListItemsRequestRequirement ReadAsPropertyName(
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
            return new ListItemsRequestRequirement(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListItemsRequestRequirement value,
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
