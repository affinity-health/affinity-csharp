using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne.CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOneSerializer)
)]
[Serializable]
public readonly record struct CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne
    : IStringEnum
{
    public static readonly CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne Infinity =
        new(Values.Infinity);

    public static readonly CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne NaN = new(
        Values.NaN
    );

    public CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne(string value)
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
    public static CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne FromCustom(
        string value
    )
    {
        return new CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne(value);
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
        CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne value
    ) => value.Value;

    public static explicit operator CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne(
        string value
    ) => new(value);

    internal class CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOneSerializer
        : JsonConverter<CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne>
    {
        public override CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne Read(
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
            return new CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne ReadAsPropertyName(
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
            return new CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderBatchRequestOrdersItemPrescriptionsItemQuantityOne value,
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
