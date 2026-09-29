using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind.RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKindSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind ColdChain =
        new(Values.ColdChain);

    public static readonly RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind InjectionSupplies =
        new(Values.InjectionSupplies);

    public RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind(string value)
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
    public static RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind(value);
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
        RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKindSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind>
    {
        public override RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind Read(
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
            return new RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCatalogFulfillmentInclusionsItemKind value,
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
