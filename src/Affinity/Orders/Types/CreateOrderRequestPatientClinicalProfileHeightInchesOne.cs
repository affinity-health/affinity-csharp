using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreateOrderRequestPatientClinicalProfileHeightInchesOne.CreateOrderRequestPatientClinicalProfileHeightInchesOneSerializer)
)]
[Serializable]
public readonly record struct CreateOrderRequestPatientClinicalProfileHeightInchesOne : IStringEnum
{
    public static readonly CreateOrderRequestPatientClinicalProfileHeightInchesOne Infinity = new(
        Values.Infinity
    );

    public static readonly CreateOrderRequestPatientClinicalProfileHeightInchesOne NaN = new(
        Values.NaN
    );

    public CreateOrderRequestPatientClinicalProfileHeightInchesOne(string value)
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
    public static CreateOrderRequestPatientClinicalProfileHeightInchesOne FromCustom(string value)
    {
        return new CreateOrderRequestPatientClinicalProfileHeightInchesOne(value);
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
        CreateOrderRequestPatientClinicalProfileHeightInchesOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderRequestPatientClinicalProfileHeightInchesOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateOrderRequestPatientClinicalProfileHeightInchesOne value
    ) => value.Value;

    public static explicit operator CreateOrderRequestPatientClinicalProfileHeightInchesOne(
        string value
    ) => new(value);

    internal class CreateOrderRequestPatientClinicalProfileHeightInchesOneSerializer
        : JsonConverter<CreateOrderRequestPatientClinicalProfileHeightInchesOne>
    {
        public override CreateOrderRequestPatientClinicalProfileHeightInchesOne Read(
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
            return new CreateOrderRequestPatientClinicalProfileHeightInchesOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderRequestPatientClinicalProfileHeightInchesOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderRequestPatientClinicalProfileHeightInchesOne ReadAsPropertyName(
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
            return new CreateOrderRequestPatientClinicalProfileHeightInchesOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderRequestPatientClinicalProfileHeightInchesOne value,
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
