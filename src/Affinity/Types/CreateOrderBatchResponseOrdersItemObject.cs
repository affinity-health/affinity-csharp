using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreateOrderBatchResponseOrdersItemObject.CreateOrderBatchResponseOrdersItemObjectSerializer)
)]
[Serializable]
public readonly record struct CreateOrderBatchResponseOrdersItemObject : IStringEnum
{
    public static readonly CreateOrderBatchResponseOrdersItemObject Order = new(Values.Order);

    public CreateOrderBatchResponseOrdersItemObject(string value)
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
    public static CreateOrderBatchResponseOrdersItemObject FromCustom(string value)
    {
        return new CreateOrderBatchResponseOrdersItemObject(value);
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
        CreateOrderBatchResponseOrdersItemObject value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderBatchResponseOrdersItemObject value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateOrderBatchResponseOrdersItemObject value) =>
        value.Value;

    public static explicit operator CreateOrderBatchResponseOrdersItemObject(string value) =>
        new(value);

    internal class CreateOrderBatchResponseOrdersItemObjectSerializer
        : JsonConverter<CreateOrderBatchResponseOrdersItemObject>
    {
        public override CreateOrderBatchResponseOrdersItemObject Read(
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
            return new CreateOrderBatchResponseOrdersItemObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderBatchResponseOrdersItemObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderBatchResponseOrdersItemObject ReadAsPropertyName(
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
            return new CreateOrderBatchResponseOrdersItemObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderBatchResponseOrdersItemObject value,
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
        public const string Order = "order";
    }
}
