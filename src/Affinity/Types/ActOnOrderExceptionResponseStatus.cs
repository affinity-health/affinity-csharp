using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ActOnOrderExceptionResponseStatus.ActOnOrderExceptionResponseStatusSerializer)
)]
[Serializable]
public readonly record struct ActOnOrderExceptionResponseStatus : IStringEnum
{
    public static readonly ActOnOrderExceptionResponseStatus Open = new(Values.Open);

    public static readonly ActOnOrderExceptionResponseStatus Acknowledged = new(
        Values.Acknowledged
    );

    public static readonly ActOnOrderExceptionResponseStatus Resolved = new(Values.Resolved);

    public ActOnOrderExceptionResponseStatus(string value)
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
    public static ActOnOrderExceptionResponseStatus FromCustom(string value)
    {
        return new ActOnOrderExceptionResponseStatus(value);
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

    public static bool operator ==(ActOnOrderExceptionResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ActOnOrderExceptionResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ActOnOrderExceptionResponseStatus value) => value.Value;

    public static explicit operator ActOnOrderExceptionResponseStatus(string value) => new(value);

    internal class ActOnOrderExceptionResponseStatusSerializer
        : JsonConverter<ActOnOrderExceptionResponseStatus>
    {
        public override ActOnOrderExceptionResponseStatus Read(
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
            return new ActOnOrderExceptionResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ActOnOrderExceptionResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ActOnOrderExceptionResponseStatus ReadAsPropertyName(
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
            return new ActOnOrderExceptionResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ActOnOrderExceptionResponseStatus value,
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
        public const string Open = "open";

        public const string Acknowledged = "acknowledged";

        public const string Resolved = "resolved";
    }
}
