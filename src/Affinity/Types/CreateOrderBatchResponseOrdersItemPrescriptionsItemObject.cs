using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreateOrderBatchResponseOrdersItemPrescriptionsItemObject.CreateOrderBatchResponseOrdersItemPrescriptionsItemObjectSerializer)
)]
[Serializable]
public readonly record struct CreateOrderBatchResponseOrdersItemPrescriptionsItemObject
    : IStringEnum
{
    public static readonly CreateOrderBatchResponseOrdersItemPrescriptionsItemObject Prescription =
        new(Values.Prescription);

    public CreateOrderBatchResponseOrdersItemPrescriptionsItemObject(string value)
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
    public static CreateOrderBatchResponseOrdersItemPrescriptionsItemObject FromCustom(string value)
    {
        return new CreateOrderBatchResponseOrdersItemPrescriptionsItemObject(value);
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
        CreateOrderBatchResponseOrdersItemPrescriptionsItemObject value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderBatchResponseOrdersItemPrescriptionsItemObject value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateOrderBatchResponseOrdersItemPrescriptionsItemObject value
    ) => value.Value;

    public static explicit operator CreateOrderBatchResponseOrdersItemPrescriptionsItemObject(
        string value
    ) => new(value);

    internal class CreateOrderBatchResponseOrdersItemPrescriptionsItemObjectSerializer
        : JsonConverter<CreateOrderBatchResponseOrdersItemPrescriptionsItemObject>
    {
        public override CreateOrderBatchResponseOrdersItemPrescriptionsItemObject Read(
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
            return new CreateOrderBatchResponseOrdersItemPrescriptionsItemObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderBatchResponseOrdersItemPrescriptionsItemObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderBatchResponseOrdersItemPrescriptionsItemObject ReadAsPropertyName(
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
            return new CreateOrderBatchResponseOrdersItemPrescriptionsItemObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderBatchResponseOrdersItemPrescriptionsItemObject value,
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
    }
}
