using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(AddOrderPrescriptionResponseObject.AddOrderPrescriptionResponseObjectSerializer)
)]
[Serializable]
public readonly record struct AddOrderPrescriptionResponseObject : IStringEnum
{
    public static readonly AddOrderPrescriptionResponseObject OrderDraftUpdate = new(
        Values.OrderDraftUpdate
    );

    public AddOrderPrescriptionResponseObject(string value)
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
    public static AddOrderPrescriptionResponseObject FromCustom(string value)
    {
        return new AddOrderPrescriptionResponseObject(value);
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

    public static bool operator ==(AddOrderPrescriptionResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AddOrderPrescriptionResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AddOrderPrescriptionResponseObject value) => value.Value;

    public static explicit operator AddOrderPrescriptionResponseObject(string value) => new(value);

    internal class AddOrderPrescriptionResponseObjectSerializer
        : JsonConverter<AddOrderPrescriptionResponseObject>
    {
        public override AddOrderPrescriptionResponseObject Read(
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
            return new AddOrderPrescriptionResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddOrderPrescriptionResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AddOrderPrescriptionResponseObject ReadAsPropertyName(
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
            return new AddOrderPrescriptionResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AddOrderPrescriptionResponseObject value,
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
        public const string OrderDraftUpdate = "order_draft_update";
    }
}
