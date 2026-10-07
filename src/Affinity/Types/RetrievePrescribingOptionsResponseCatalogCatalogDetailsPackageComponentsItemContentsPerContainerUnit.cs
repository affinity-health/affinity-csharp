using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit.RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnitSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit Mg =
        new(Values.Mg);

    public static readonly RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit G =
        new(Values.G);

    public static readonly RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit Ug =
        new(Values.Ug);

    public static readonly RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit ML =
        new(Values.ML);

    public static readonly RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit L =
        new(Values.L);

    public static readonly RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit Iu =
        new(Values.Iu);

    public static readonly RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit Tablet =
        new(Values.Tablet);

    public static readonly RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit Capsule =
        new(Values.Capsule);

    public static readonly RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit Troche =
        new(Values.Troche);

    public static readonly RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit Actuation =
        new(Values.Actuation);

    public static readonly RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit Patch =
        new(Values.Patch);

    public static readonly RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit Package =
        new(Values.Package);

    public static readonly RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit Container =
        new(Values.Container);

    public RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit(
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
    public static RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit(
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
        RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnitSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit>
    {
        public override RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit Read(
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
            return new RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogCatalogDetailsPackageComponentsItemContentsPerContainerUnit value,
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
