using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CancelOrderResponsePrescriptionsItemQuantityOne.CancelOrderResponsePrescriptionsItemQuantityOneSerializer)
)]
[Serializable]
public readonly record struct CancelOrderResponsePrescriptionsItemQuantityOne : IStringEnum
{
    public static readonly CancelOrderResponsePrescriptionsItemQuantityOne Infinity = new(
        Values.Infinity
    );

    public static readonly CancelOrderResponsePrescriptionsItemQuantityOne NaN = new(Values.NaN);

    public CancelOrderResponsePrescriptionsItemQuantityOne(string value)
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
    public static CancelOrderResponsePrescriptionsItemQuantityOne FromCustom(string value)
    {
        return new CancelOrderResponsePrescriptionsItemQuantityOne(value);
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
        CancelOrderResponsePrescriptionsItemQuantityOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CancelOrderResponsePrescriptionsItemQuantityOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CancelOrderResponsePrescriptionsItemQuantityOne value) =>
        value.Value;

    public static explicit operator CancelOrderResponsePrescriptionsItemQuantityOne(string value) =>
        new(value);

    internal class CancelOrderResponsePrescriptionsItemQuantityOneSerializer
        : JsonConverter<CancelOrderResponsePrescriptionsItemQuantityOne>
    {
        public override CancelOrderResponsePrescriptionsItemQuantityOne Read(
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
            return new CancelOrderResponsePrescriptionsItemQuantityOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelOrderResponsePrescriptionsItemQuantityOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelOrderResponsePrescriptionsItemQuantityOne ReadAsPropertyName(
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
            return new CancelOrderResponsePrescriptionsItemQuantityOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelOrderResponsePrescriptionsItemQuantityOne value,
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
