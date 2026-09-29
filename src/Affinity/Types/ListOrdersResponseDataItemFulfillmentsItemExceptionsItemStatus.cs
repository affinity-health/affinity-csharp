using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus.ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatusSerializer)
)]
[Serializable]
public readonly record struct ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus
    : IStringEnum
{
    public static readonly ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus Open =
        new(Values.Open);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus Acknowledged =
        new(Values.Acknowledged);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus Resolved =
        new(Values.Resolved);

    public ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus(string value)
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
    public static ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus FromCustom(
        string value
    )
    {
        return new ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus(value);
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
        ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus value
    ) => value.Value;

    public static explicit operator ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus(
        string value
    ) => new(value);

    internal class ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatusSerializer
        : JsonConverter<ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus>
    {
        public override ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus Read(
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
            return new ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus ReadAsPropertyName(
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
            return new ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemExceptionsItemStatus value,
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
