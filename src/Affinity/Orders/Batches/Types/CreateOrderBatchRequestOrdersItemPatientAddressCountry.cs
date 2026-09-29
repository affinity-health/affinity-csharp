using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Orders;

[JsonConverter(
    typeof(CreateOrderBatchRequestOrdersItemPatientAddressCountry.CreateOrderBatchRequestOrdersItemPatientAddressCountrySerializer)
)]
[Serializable]
public readonly record struct CreateOrderBatchRequestOrdersItemPatientAddressCountry : IStringEnum
{
    public static readonly CreateOrderBatchRequestOrdersItemPatientAddressCountry Us = new(
        Values.Us
    );

    public CreateOrderBatchRequestOrdersItemPatientAddressCountry(string value)
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
    public static CreateOrderBatchRequestOrdersItemPatientAddressCountry FromCustom(string value)
    {
        return new CreateOrderBatchRequestOrdersItemPatientAddressCountry(value);
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
        CreateOrderBatchRequestOrdersItemPatientAddressCountry value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderBatchRequestOrdersItemPatientAddressCountry value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateOrderBatchRequestOrdersItemPatientAddressCountry value
    ) => value.Value;

    public static explicit operator CreateOrderBatchRequestOrdersItemPatientAddressCountry(
        string value
    ) => new(value);

    internal class CreateOrderBatchRequestOrdersItemPatientAddressCountrySerializer
        : JsonConverter<CreateOrderBatchRequestOrdersItemPatientAddressCountry>
    {
        public override CreateOrderBatchRequestOrdersItemPatientAddressCountry Read(
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
            return new CreateOrderBatchRequestOrdersItemPatientAddressCountry(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderBatchRequestOrdersItemPatientAddressCountry value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderBatchRequestOrdersItemPatientAddressCountry ReadAsPropertyName(
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
            return new CreateOrderBatchRequestOrdersItemPatientAddressCountry(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderBatchRequestOrdersItemPatientAddressCountry value,
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
        public const string Us = "US";
    }
}
