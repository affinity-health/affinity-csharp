using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderResponsePrescriptionsItemFormat.PreviewOrderResponsePrescriptionsItemFormatSerializer)
)]
[Serializable]
public readonly record struct PreviewOrderResponsePrescriptionsItemFormat : IStringEnum
{
    public static readonly PreviewOrderResponsePrescriptionsItemFormat Structured = new(
        Values.Structured
    );

    public static readonly PreviewOrderResponsePrescriptionsItemFormat FreeText = new(
        Values.FreeText
    );

    public PreviewOrderResponsePrescriptionsItemFormat(string value)
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
    public static PreviewOrderResponsePrescriptionsItemFormat FromCustom(string value)
    {
        return new PreviewOrderResponsePrescriptionsItemFormat(value);
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
        PreviewOrderResponsePrescriptionsItemFormat value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderResponsePrescriptionsItemFormat value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(PreviewOrderResponsePrescriptionsItemFormat value) =>
        value.Value;

    public static explicit operator PreviewOrderResponsePrescriptionsItemFormat(string value) =>
        new(value);

    internal class PreviewOrderResponsePrescriptionsItemFormatSerializer
        : JsonConverter<PreviewOrderResponsePrescriptionsItemFormat>
    {
        public override PreviewOrderResponsePrescriptionsItemFormat Read(
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
            return new PreviewOrderResponsePrescriptionsItemFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderResponsePrescriptionsItemFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderResponsePrescriptionsItemFormat ReadAsPropertyName(
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
            return new PreviewOrderResponsePrescriptionsItemFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderResponsePrescriptionsItemFormat value,
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
        public const string Structured = "structured";

        public const string FreeText = "free_text";
    }
}
