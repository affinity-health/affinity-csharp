using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Orders;

[JsonConverter(
    typeof(CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne.CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOneSerializer)
)]
[Serializable]
public readonly record struct CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne
    : IStringEnum
{
    public static readonly CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne Infinity =
        new(Values.Infinity);

    public static readonly CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne NaN =
        new(Values.NaN);

    public CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne(
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
    public static CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne FromCustom(
        string value
    )
    {
        return new CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne(
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
        CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne value
    ) => value.Value;

    public static explicit operator CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne(
        string value
    ) => new(value);

    internal class CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOneSerializer
        : JsonConverter<CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne>
    {
        public override CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne Read(
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
            return new CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne ReadAsPropertyName(
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
            return new CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderBatchRequestOrdersItemPatientMeasurementsItemHeightCentimetersOne value,
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
