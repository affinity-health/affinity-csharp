using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(RejectOrderResponseStatus.RejectOrderResponseStatusSerializer))]
[Serializable]
public readonly record struct RejectOrderResponseStatus : IStringEnum
{
    public static readonly RejectOrderResponseStatus Rejected = new(Values.Rejected);

    public RejectOrderResponseStatus(string value)
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
    public static RejectOrderResponseStatus FromCustom(string value)
    {
        return new RejectOrderResponseStatus(value);
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

    public static bool operator ==(RejectOrderResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RejectOrderResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RejectOrderResponseStatus value) => value.Value;

    public static explicit operator RejectOrderResponseStatus(string value) => new(value);

    internal class RejectOrderResponseStatusSerializer : JsonConverter<RejectOrderResponseStatus>
    {
        public override RejectOrderResponseStatus Read(
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
            return new RejectOrderResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RejectOrderResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RejectOrderResponseStatus ReadAsPropertyName(
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
            return new RejectOrderResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RejectOrderResponseStatus value,
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
        public const string Rejected = "rejected";
    }
}
