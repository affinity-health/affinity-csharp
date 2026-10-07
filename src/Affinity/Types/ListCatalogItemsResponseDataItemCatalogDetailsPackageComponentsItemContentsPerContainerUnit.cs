using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit.ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnitSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit
    : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit Mg =
        new(Values.Mg);

    public static readonly ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit G =
        new(Values.G);

    public static readonly ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit Ug =
        new(Values.Ug);

    public static readonly ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit ML =
        new(Values.ML);

    public static readonly ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit L =
        new(Values.L);

    public static readonly ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit Iu =
        new(Values.Iu);

    public static readonly ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit Tablet =
        new(Values.Tablet);

    public static readonly ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit Capsule =
        new(Values.Capsule);

    public static readonly ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit Troche =
        new(Values.Troche);

    public static readonly ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit Actuation =
        new(Values.Actuation);

    public static readonly ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit Patch =
        new(Values.Patch);

    public static readonly ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit Package =
        new(Values.Package);

    public static readonly ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit Container =
        new(Values.Container);

    public ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit(
        string value
    )
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
    public static ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit FromCustom(
        string value
    )
    {
        return new ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit(
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
        ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit value
    ) => value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit(
        string value
    ) => new(value);

    internal class ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnitSerializer
        : JsonConverter<ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit>
    {
        public override ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit Read(
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
            return new ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemCatalogDetailsPackageComponentsItemContentsPerContainerUnit value,
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
        public const string Mg = "mg";

        public const string G = "g";

        public const string Ug = "ug";

        public const string ML = "mL";

        public const string L = "L";

        public const string Iu = "[IU]";

        public const string Tablet = "tablet";

        public const string Capsule = "capsule";

        public const string Troche = "troche";

        public const string Actuation = "actuation";

        public const string Patch = "patch";

        public const string Package = "package";

        public const string Container = "container";
    }
}
