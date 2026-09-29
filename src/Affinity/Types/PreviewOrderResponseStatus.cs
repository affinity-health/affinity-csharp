using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(PreviewOrderResponseStatus.PreviewOrderResponseStatusSerializer))]
[Serializable]
public readonly record struct PreviewOrderResponseStatus : IStringEnum
{
    public static readonly PreviewOrderResponseStatus Complete = new(Values.Complete);

    public static readonly PreviewOrderResponseStatus Incomplete = new(Values.Incomplete);

    public PreviewOrderResponseStatus(string value)
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
    public static PreviewOrderResponseStatus FromCustom(string value)
    {
        return new PreviewOrderResponseStatus(value);
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

    public static bool operator ==(PreviewOrderResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PreviewOrderResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PreviewOrderResponseStatus value) => value.Value;

    public static explicit operator PreviewOrderResponseStatus(string value) => new(value);

    internal class PreviewOrderResponseStatusSerializer : JsonConverter<PreviewOrderResponseStatus>
    {
        public override PreviewOrderResponseStatus Read(
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
            return new PreviewOrderResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderResponseStatus ReadAsPropertyName(
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
            return new PreviewOrderResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderResponseStatus value,
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
        public const string Complete = "complete";

        public const string Incomplete = "incomplete";
    }
}
