using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(UpdateOrderPrescriptionResponseObject.UpdateOrderPrescriptionResponseObjectSerializer)
)]
[Serializable]
public readonly record struct UpdateOrderPrescriptionResponseObject : IStringEnum
{
    public static readonly UpdateOrderPrescriptionResponseObject OrderDraftUpdate = new(
        Values.OrderDraftUpdate
    );

    public UpdateOrderPrescriptionResponseObject(string value)
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
    public static UpdateOrderPrescriptionResponseObject FromCustom(string value)
    {
        return new UpdateOrderPrescriptionResponseObject(value);
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

    public static bool operator ==(UpdateOrderPrescriptionResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateOrderPrescriptionResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateOrderPrescriptionResponseObject value) =>
        value.Value;

    public static explicit operator UpdateOrderPrescriptionResponseObject(string value) =>
        new(value);

    internal class UpdateOrderPrescriptionResponseObjectSerializer
        : JsonConverter<UpdateOrderPrescriptionResponseObject>
    {
        public override UpdateOrderPrescriptionResponseObject Read(
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
            return new UpdateOrderPrescriptionResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateOrderPrescriptionResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateOrderPrescriptionResponseObject ReadAsPropertyName(
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
            return new UpdateOrderPrescriptionResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateOrderPrescriptionResponseObject value,
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
