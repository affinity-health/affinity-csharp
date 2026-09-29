using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsRequestCatalogKind.ListCatalogItemsRequestCatalogKindSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsRequestCatalogKind : IStringEnum
{
    public static readonly ListCatalogItemsRequestCatalogKind Prescription = new(
        Values.Prescription
    );

    public static readonly ListCatalogItemsRequestCatalogKind Otc = new(Values.Otc);

    public ListCatalogItemsRequestCatalogKind(string value)
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
    public static ListCatalogItemsRequestCatalogKind FromCustom(string value)
    {
        return new ListCatalogItemsRequestCatalogKind(value);
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

    public static bool operator ==(ListCatalogItemsRequestCatalogKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListCatalogItemsRequestCatalogKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListCatalogItemsRequestCatalogKind value) => value.Value;

    public static explicit operator ListCatalogItemsRequestCatalogKind(string value) => new(value);

    internal class ListCatalogItemsRequestCatalogKindSerializer
        : JsonConverter<ListCatalogItemsRequestCatalogKind>
    {
        public override ListCatalogItemsRequestCatalogKind Read(
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
            return new ListCatalogItemsRequestCatalogKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsRequestCatalogKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsRequestCatalogKind ReadAsPropertyName(
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
            return new ListCatalogItemsRequestCatalogKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsRequestCatalogKind value,
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
        public const string Prescription = "prescription";

        public const string Otc = "otc";
    }
}
