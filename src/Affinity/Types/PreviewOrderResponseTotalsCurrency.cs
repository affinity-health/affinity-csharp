using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderResponseTotalsCurrency.PreviewOrderResponseTotalsCurrencySerializer)
)]
[Serializable]
public readonly record struct PreviewOrderResponseTotalsCurrency : IStringEnum
{
    public static readonly PreviewOrderResponseTotalsCurrency Usd = new(Values.Usd);

    public PreviewOrderResponseTotalsCurrency(string value)
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
    public static PreviewOrderResponseTotalsCurrency FromCustom(string value)
    {
        return new PreviewOrderResponseTotalsCurrency(value);
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

    public static bool operator ==(PreviewOrderResponseTotalsCurrency value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PreviewOrderResponseTotalsCurrency value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PreviewOrderResponseTotalsCurrency value) => value.Value;

    public static explicit operator PreviewOrderResponseTotalsCurrency(string value) => new(value);

    internal class PreviewOrderResponseTotalsCurrencySerializer
        : JsonConverter<PreviewOrderResponseTotalsCurrency>
    {
        public override PreviewOrderResponseTotalsCurrency Read(
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
            return new PreviewOrderResponseTotalsCurrency(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderResponseTotalsCurrency value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderResponseTotalsCurrency ReadAsPropertyName(
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
            return new PreviewOrderResponseTotalsCurrency(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderResponseTotalsCurrency value,
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
        public const string Usd = "USD";
    }
}
