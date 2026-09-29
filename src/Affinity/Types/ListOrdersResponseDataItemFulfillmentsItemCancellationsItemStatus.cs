using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus.ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatusSerializer)
)]
[Serializable]
public readonly record struct ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus
    : IStringEnum
{
    public static readonly ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus Requested =
        new(Values.Requested);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus Sent =
        new(Values.Sent);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus Confirmed =
        new(Values.Confirmed);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus Rejected =
        new(Values.Rejected);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus Failed =
        new(Values.Failed);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus TooLate =
        new(Values.TooLate);

    public ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus(string value)
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
    public static ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus FromCustom(
        string value
    )
    {
        return new ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus(value);
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
        ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus value
    ) => value.Value;

    public static explicit operator ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus(
        string value
    ) => new(value);

    internal class ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatusSerializer
        : JsonConverter<ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus>
    {
        public override ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus Read(
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
            return new ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus ReadAsPropertyName(
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
            return new ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemCancellationsItemStatus value,
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
        public const string Requested = "requested";

        public const string Sent = "sent";

        public const string Confirmed = "confirmed";

        public const string Rejected = "rejected";

        public const string Failed = "failed";

        public const string TooLate = "too_late";
    }
}
