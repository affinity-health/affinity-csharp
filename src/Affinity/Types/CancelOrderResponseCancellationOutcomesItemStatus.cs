using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CancelOrderResponseCancellationOutcomesItemStatus.CancelOrderResponseCancellationOutcomesItemStatusSerializer)
)]
[Serializable]
public readonly record struct CancelOrderResponseCancellationOutcomesItemStatus : IStringEnum
{
    public static readonly CancelOrderResponseCancellationOutcomesItemStatus Confirmed = new(
        Values.Confirmed
    );

    public static readonly CancelOrderResponseCancellationOutcomesItemStatus Failed = new(
        Values.Failed
    );

    public static readonly CancelOrderResponseCancellationOutcomesItemStatus Rejected = new(
        Values.Rejected
    );

    public static readonly CancelOrderResponseCancellationOutcomesItemStatus Requested = new(
        Values.Requested
    );

    public static readonly CancelOrderResponseCancellationOutcomesItemStatus Sent = new(
        Values.Sent
    );

    public static readonly CancelOrderResponseCancellationOutcomesItemStatus TooLate = new(
        Values.TooLate
    );

    public CancelOrderResponseCancellationOutcomesItemStatus(string value)
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
    public static CancelOrderResponseCancellationOutcomesItemStatus FromCustom(string value)
    {
        return new CancelOrderResponseCancellationOutcomesItemStatus(value);
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
        CancelOrderResponseCancellationOutcomesItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CancelOrderResponseCancellationOutcomesItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CancelOrderResponseCancellationOutcomesItemStatus value
    ) => value.Value;

    public static explicit operator CancelOrderResponseCancellationOutcomesItemStatus(
        string value
    ) => new(value);

    internal class CancelOrderResponseCancellationOutcomesItemStatusSerializer
        : JsonConverter<CancelOrderResponseCancellationOutcomesItemStatus>
    {
        public override CancelOrderResponseCancellationOutcomesItemStatus Read(
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
            return new CancelOrderResponseCancellationOutcomesItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelOrderResponseCancellationOutcomesItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelOrderResponseCancellationOutcomesItemStatus ReadAsPropertyName(
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
            return new CancelOrderResponseCancellationOutcomesItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelOrderResponseCancellationOutcomesItemStatus value,
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
        public const string Confirmed = "confirmed";

        public const string Failed = "failed";

        public const string Rejected = "rejected";

        public const string Requested = "requested";

        public const string Sent = "sent";

        public const string TooLate = "too_late";
    }
}
