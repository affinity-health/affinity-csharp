using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsRequestDosageFormsOneItem.ListCatalogItemsRequestDosageFormsOneItemSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsRequestDosageFormsOneItem : IStringEnum
{
    public static readonly ListCatalogItemsRequestDosageFormsOneItem Capsule = new(Values.Capsule);

    public static readonly ListCatalogItemsRequestDosageFormsOneItem Cream = new(Values.Cream);

    public static readonly ListCatalogItemsRequestDosageFormsOneItem Gel = new(Values.Gel);

    public static readonly ListCatalogItemsRequestDosageFormsOneItem Solution = new(
        Values.Solution
    );

    public static readonly ListCatalogItemsRequestDosageFormsOneItem Spray = new(Values.Spray);

    public static readonly ListCatalogItemsRequestDosageFormsOneItem Tablet = new(Values.Tablet);

    public static readonly ListCatalogItemsRequestDosageFormsOneItem Troche = new(Values.Troche);

    public static readonly ListCatalogItemsRequestDosageFormsOneItem Unknown = new(Values.Unknown);

    public static readonly ListCatalogItemsRequestDosageFormsOneItem Vial = new(Values.Vial);

    public ListCatalogItemsRequestDosageFormsOneItem(string value)
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
    public static ListCatalogItemsRequestDosageFormsOneItem FromCustom(string value)
    {
        return new ListCatalogItemsRequestDosageFormsOneItem(value);
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
        ListCatalogItemsRequestDosageFormsOneItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsRequestDosageFormsOneItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListCatalogItemsRequestDosageFormsOneItem value) =>
        value.Value;

    public static explicit operator ListCatalogItemsRequestDosageFormsOneItem(string value) =>
        new(value);

    internal class ListCatalogItemsRequestDosageFormsOneItemSerializer
        : JsonConverter<ListCatalogItemsRequestDosageFormsOneItem>
    {
        public override ListCatalogItemsRequestDosageFormsOneItem Read(
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
            return new ListCatalogItemsRequestDosageFormsOneItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsRequestDosageFormsOneItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsRequestDosageFormsOneItem ReadAsPropertyName(
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
            return new ListCatalogItemsRequestDosageFormsOneItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsRequestDosageFormsOneItem value,
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
