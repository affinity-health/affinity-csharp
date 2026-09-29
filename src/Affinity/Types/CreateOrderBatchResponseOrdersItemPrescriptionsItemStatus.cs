using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus.CreateOrderBatchResponseOrdersItemPrescriptionsItemStatusSerializer)
)]
[Serializable]
public readonly record struct CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus
    : IStringEnum
{
    public static readonly CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus RequiresProviderSignature =
        new(Values.RequiresProviderSignature);

    public CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus(string value)
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
    public static CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus FromCustom(string value)
    {
        return new CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus(value);
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
        CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus value
    ) => value.Value;

    public static explicit operator CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus(
        string value
    ) => new(value);

    internal class CreateOrderBatchResponseOrdersItemPrescriptionsItemStatusSerializer
        : JsonConverter<CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus>
    {
        public override CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus Read(
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
            return new CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus ReadAsPropertyName(
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
            return new CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderBatchResponseOrdersItemPrescriptionsItemStatus value,
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
        public const string RequiresProviderSignature = "requires_provider_signature";
    }
}
