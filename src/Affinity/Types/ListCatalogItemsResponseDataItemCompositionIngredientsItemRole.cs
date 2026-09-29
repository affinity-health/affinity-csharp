using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemCompositionIngredientsItemRole.ListCatalogItemsResponseDataItemCompositionIngredientsItemRoleSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemCompositionIngredientsItemRole
    : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemCompositionIngredientsItemRole Active =
        new(Values.Active);

    public static readonly ListCatalogItemsResponseDataItemCompositionIngredientsItemRole Inactive =
        new(Values.Inactive);

    public ListCatalogItemsResponseDataItemCompositionIngredientsItemRole(string value)
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
    public static ListCatalogItemsResponseDataItemCompositionIngredientsItemRole FromCustom(
        string value
    )
    {
        return new ListCatalogItemsResponseDataItemCompositionIngredientsItemRole(value);
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
        ListCatalogItemsResponseDataItemCompositionIngredientsItemRole value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemCompositionIngredientsItemRole value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListCatalogItemsResponseDataItemCompositionIngredientsItemRole value
    ) => value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemCompositionIngredientsItemRole(
        string value
    ) => new(value);

    internal class ListCatalogItemsResponseDataItemCompositionIngredientsItemRoleSerializer
        : JsonConverter<ListCatalogItemsResponseDataItemCompositionIngredientsItemRole>
    {
        public override ListCatalogItemsResponseDataItemCompositionIngredientsItemRole Read(
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
            return new ListCatalogItemsResponseDataItemCompositionIngredientsItemRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemCompositionIngredientsItemRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemCompositionIngredientsItemRole ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemCompositionIngredientsItemRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemCompositionIngredientsItemRole value,
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
        public const string Active = "active";

        public const string Inactive = "inactive";
    }
}
