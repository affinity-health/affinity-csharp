using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsRequestDosageFormsZero.ListCatalogItemsRequestDosageFormsZeroSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsRequestDosageFormsZero : IStringEnum
{
    public static readonly ListCatalogItemsRequestDosageFormsZero Capsule = new(Values.Capsule);

    public static readonly ListCatalogItemsRequestDosageFormsZero Cream = new(Values.Cream);

    public static readonly ListCatalogItemsRequestDosageFormsZero Gel = new(Values.Gel);

    public static readonly ListCatalogItemsRequestDosageFormsZero Solution = new(Values.Solution);

    public static readonly ListCatalogItemsRequestDosageFormsZero Spray = new(Values.Spray);

    public static readonly ListCatalogItemsRequestDosageFormsZero Tablet = new(Values.Tablet);

    public static readonly ListCatalogItemsRequestDosageFormsZero Troche = new(Values.Troche);

    public static readonly ListCatalogItemsRequestDosageFormsZero Unknown = new(Values.Unknown);

    public static readonly ListCatalogItemsRequestDosageFormsZero Vial = new(Values.Vial);

    public ListCatalogItemsRequestDosageFormsZero(string value)
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
    public static ListCatalogItemsRequestDosageFormsZero FromCustom(string value)
    {
        return new ListCatalogItemsRequestDosageFormsZero(value);
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

    public static bool operator ==(ListCatalogItemsRequestDosageFormsZero value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListCatalogItemsRequestDosageFormsZero value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListCatalogItemsRequestDosageFormsZero value) =>
        value.Value;

    public static explicit operator ListCatalogItemsRequestDosageFormsZero(string value) =>
        new(value);

    internal class ListCatalogItemsRequestDosageFormsZeroSerializer
        : JsonConverter<ListCatalogItemsRequestDosageFormsZero>
    {
        public override ListCatalogItemsRequestDosageFormsZero Read(
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
            return new ListCatalogItemsRequestDosageFormsZero(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsRequestDosageFormsZero value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsRequestDosageFormsZero ReadAsPropertyName(
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
            return new ListCatalogItemsRequestDosageFormsZero(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsRequestDosageFormsZero value,
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
        public const string Capsule = "capsule";

        public const string Cream = "cream";

        public const string Gel = "gel";

        public const string Solution = "solution";

        public const string Spray = "spray";

        public const string Tablet = "tablet";

        public const string Troche = "troche";

        public const string Unknown = "unknown";

        public const string Vial = "vial";
    }
}
