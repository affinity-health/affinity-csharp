using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(PreviewOrderResponseObject.PreviewOrderResponseObjectSerializer))]
[Serializable]
public readonly record struct PreviewOrderResponseObject : IStringEnum
{
    public static readonly PreviewOrderResponseObject OrderPreview = new(Values.OrderPreview);

    public PreviewOrderResponseObject(string value)
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
    public static PreviewOrderResponseObject FromCustom(string value)
    {
        return new PreviewOrderResponseObject(value);
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

    public static bool operator ==(PreviewOrderResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PreviewOrderResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PreviewOrderResponseObject value) => value.Value;

    public static explicit operator PreviewOrderResponseObject(string value) => new(value);

    internal class PreviewOrderResponseObjectSerializer : JsonConverter<PreviewOrderResponseObject>
    {
        public override PreviewOrderResponseObject Read(
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
            return new PreviewOrderResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderResponseObject ReadAsPropertyName(
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
            return new PreviewOrderResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderResponseObject value,
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
        public const string OrderPreview = "order_preview";
    }
}
