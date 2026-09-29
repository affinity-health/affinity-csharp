using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne.CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOneSerializer)
)]
[Serializable]
public readonly record struct CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne
    : IStringEnum
{
    public static readonly CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne Infinity =
        new(Values.Infinity);

    public static readonly CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne NaN = new(
        Values.NaN
    );

    public CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne(string value)
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
    public static CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne FromCustom(
        string value
    )
    {
        return new CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne(value);
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
        CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne value
    ) => value.Value;

    public static explicit operator CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne(
        string value
    ) => new(value);

    internal class CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOneSerializer
        : JsonConverter<CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne>
    {
        public override CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne Read(
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
            return new CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne ReadAsPropertyName(
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
            return new CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderBatchResponseOrdersItemPrescriptionsItemQuantityOne value,
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
        public const string Infinity = "Infinity";

        public const string NaN = "NaN";
    }
}
