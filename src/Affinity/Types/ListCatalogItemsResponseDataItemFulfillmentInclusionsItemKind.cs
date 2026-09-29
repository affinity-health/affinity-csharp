using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind.ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKindSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind
    : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind ColdChain =
        new(Values.ColdChain);

    public static readonly ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind InjectionSupplies =
        new(Values.InjectionSupplies);

    public ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind(string value)
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
    public static ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind FromCustom(
        string value
    )
    {
        return new ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind(value);
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
        ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind value
    ) => value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind(
        string value
    ) => new(value);

    internal class ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKindSerializer
        : JsonConverter<ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind>
    {
        public override ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind Read(
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
            return new ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemFulfillmentInclusionsItemKind value,
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
        public const string ColdChain = "cold_chain";

        public const string InjectionSupplies = "injection_supplies";
    }
}
