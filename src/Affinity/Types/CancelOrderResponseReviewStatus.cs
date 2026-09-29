using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(CancelOrderResponseReviewStatus.CancelOrderResponseReviewStatusSerializer))]
[Serializable]
public readonly record struct CancelOrderResponseReviewStatus : IStringEnum
{
    public static readonly CancelOrderResponseReviewStatus Completed = new(Values.Completed);

    public static readonly CancelOrderResponseReviewStatus Rejected = new(Values.Rejected);

    public CancelOrderResponseReviewStatus(string value)
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
    public static CancelOrderResponseReviewStatus FromCustom(string value)
    {
        return new CancelOrderResponseReviewStatus(value);
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

    public static bool operator ==(CancelOrderResponseReviewStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CancelOrderResponseReviewStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CancelOrderResponseReviewStatus value) => value.Value;

    public static explicit operator CancelOrderResponseReviewStatus(string value) => new(value);

    internal class CancelOrderResponseReviewStatusSerializer
        : JsonConverter<CancelOrderResponseReviewStatus>
    {
        public override CancelOrderResponseReviewStatus Read(
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
            return new CancelOrderResponseReviewStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelOrderResponseReviewStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelOrderResponseReviewStatus ReadAsPropertyName(
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
            return new CancelOrderResponseReviewStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelOrderResponseReviewStatus value,
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
        public const string Completed = "completed";

        public const string Rejected = "rejected";
    }
}
