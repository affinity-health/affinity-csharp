using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetOrderResponseFulfillmentsItemCancellationsItemStatus.GetOrderResponseFulfillmentsItemCancellationsItemStatusSerializer)
)]
[Serializable]
public readonly record struct GetOrderResponseFulfillmentsItemCancellationsItemStatus : IStringEnum
{
    public static readonly GetOrderResponseFulfillmentsItemCancellationsItemStatus Requested = new(
        Values.Requested
    );

    public static readonly GetOrderResponseFulfillmentsItemCancellationsItemStatus Sent = new(
        Values.Sent
    );

    public static readonly GetOrderResponseFulfillmentsItemCancellationsItemStatus Confirmed = new(
        Values.Confirmed
    );

    public static readonly GetOrderResponseFulfillmentsItemCancellationsItemStatus Rejected = new(
        Values.Rejected
    );

    public static readonly GetOrderResponseFulfillmentsItemCancellationsItemStatus Failed = new(
        Values.Failed
    );

    public static readonly GetOrderResponseFulfillmentsItemCancellationsItemStatus TooLate = new(
        Values.TooLate
    );

    public GetOrderResponseFulfillmentsItemCancellationsItemStatus(string value)
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
    public static GetOrderResponseFulfillmentsItemCancellationsItemStatus FromCustom(string value)
    {
        return new GetOrderResponseFulfillmentsItemCancellationsItemStatus(value);
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
        GetOrderResponseFulfillmentsItemCancellationsItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetOrderResponseFulfillmentsItemCancellationsItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetOrderResponseFulfillmentsItemCancellationsItemStatus value
    ) => value.Value;

    public static explicit operator GetOrderResponseFulfillmentsItemCancellationsItemStatus(
        string value
    ) => new(value);

    internal class GetOrderResponseFulfillmentsItemCancellationsItemStatusSerializer
        : JsonConverter<GetOrderResponseFulfillmentsItemCancellationsItemStatus>
    {
        public override GetOrderResponseFulfillmentsItemCancellationsItemStatus Read(
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
            return new GetOrderResponseFulfillmentsItemCancellationsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrderResponseFulfillmentsItemCancellationsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetOrderResponseFulfillmentsItemCancellationsItemStatus ReadAsPropertyName(
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
            return new GetOrderResponseFulfillmentsItemCancellationsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrderResponseFulfillmentsItemCancellationsItemStatus value,
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
