using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Catalog;

[JsonConverter(
    typeof(ListItemsRequestDosageFormsOneItem.ListItemsRequestDosageFormsOneItemSerializer)
)]
[Serializable]
public readonly record struct ListItemsRequestDosageFormsOneItem : IStringEnum
{
    public static readonly ListItemsRequestDosageFormsOneItem Capsule = new(Values.Capsule);

    public static readonly ListItemsRequestDosageFormsOneItem Cream = new(Values.Cream);

    public static readonly ListItemsRequestDosageFormsOneItem Gel = new(Values.Gel);

    public static readonly ListItemsRequestDosageFormsOneItem Solution = new(Values.Solution);

    public static readonly ListItemsRequestDosageFormsOneItem Spray = new(Values.Spray);

    public static readonly ListItemsRequestDosageFormsOneItem Tablet = new(Values.Tablet);

    public static readonly ListItemsRequestDosageFormsOneItem Troche = new(Values.Troche);

    public static readonly ListItemsRequestDosageFormsOneItem Unknown = new(Values.Unknown);

    public static readonly ListItemsRequestDosageFormsOneItem Vial = new(Values.Vial);

    public ListItemsRequestDosageFormsOneItem(string value)
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
    public static ListItemsRequestDosageFormsOneItem FromCustom(string value)
    {
        return new ListItemsRequestDosageFormsOneItem(value);
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

    public static bool operator ==(ListItemsRequestDosageFormsOneItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListItemsRequestDosageFormsOneItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListItemsRequestDosageFormsOneItem value) => value.Value;

    public static explicit operator ListItemsRequestDosageFormsOneItem(string value) => new(value);

    internal class ListItemsRequestDosageFormsOneItemSerializer
        : JsonConverter<ListItemsRequestDosageFormsOneItem>
    {
        public override ListItemsRequestDosageFormsOneItem Read(
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
            return new ListItemsRequestDosageFormsOneItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListItemsRequestDosageFormsOneItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListItemsRequestDosageFormsOneItem ReadAsPropertyName(
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
            return new ListItemsRequestDosageFormsOneItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListItemsRequestDosageFormsOneItem value,
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
