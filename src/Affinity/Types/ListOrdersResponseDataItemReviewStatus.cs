using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListOrdersResponseDataItemReviewStatus.ListOrdersResponseDataItemReviewStatusSerializer)
)]
[Serializable]
public readonly record struct ListOrdersResponseDataItemReviewStatus : IStringEnum
{
    public static readonly ListOrdersResponseDataItemReviewStatus Completed = new(Values.Completed);

    public static readonly ListOrdersResponseDataItemReviewStatus Rejected = new(Values.Rejected);

    public ListOrdersResponseDataItemReviewStatus(string value)
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
    public static ListOrdersResponseDataItemReviewStatus FromCustom(string value)
    {
        return new ListOrdersResponseDataItemReviewStatus(value);
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

    public static bool operator ==(ListOrdersResponseDataItemReviewStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListOrdersResponseDataItemReviewStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListOrdersResponseDataItemReviewStatus value) =>
        value.Value;

    public static explicit operator ListOrdersResponseDataItemReviewStatus(string value) =>
        new(value);

    internal class ListOrdersResponseDataItemReviewStatusSerializer
        : JsonConverter<ListOrdersResponseDataItemReviewStatus>
    {
        public override ListOrdersResponseDataItemReviewStatus Read(
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
            return new ListOrdersResponseDataItemReviewStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemReviewStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseDataItemReviewStatus ReadAsPropertyName(
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
            return new ListOrdersResponseDataItemReviewStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemReviewStatus value,
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
