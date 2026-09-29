using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(GetOrderResponseReviewStatus.GetOrderResponseReviewStatusSerializer))]
[Serializable]
public readonly record struct GetOrderResponseReviewStatus : IStringEnum
{
    public static readonly GetOrderResponseReviewStatus Completed = new(Values.Completed);

    public static readonly GetOrderResponseReviewStatus Rejected = new(Values.Rejected);

    public GetOrderResponseReviewStatus(string value)
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
    public static GetOrderResponseReviewStatus FromCustom(string value)
    {
        return new GetOrderResponseReviewStatus(value);
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

    public static bool operator ==(GetOrderResponseReviewStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetOrderResponseReviewStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetOrderResponseReviewStatus value) => value.Value;

    public static explicit operator GetOrderResponseReviewStatus(string value) => new(value);

    internal class GetOrderResponseReviewStatusSerializer
        : JsonConverter<GetOrderResponseReviewStatus>
    {
        public override GetOrderResponseReviewStatus Read(
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
            return new GetOrderResponseReviewStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrderResponseReviewStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetOrderResponseReviewStatus ReadAsPropertyName(
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
            return new GetOrderResponseReviewStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrderResponseReviewStatus value,
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
