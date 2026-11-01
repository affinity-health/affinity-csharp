using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(StatusHistoryEntryStatus.StatusHistoryEntryStatusSerializer))]
[Serializable]
public readonly record struct StatusHistoryEntryStatus : IStringEnum
{
    public static readonly StatusHistoryEntryStatus AwaitingApproval = new(Values.AwaitingApproval);

    public static readonly StatusHistoryEntryStatus Submitted = new(Values.Submitted);

    public static readonly StatusHistoryEntryStatus Processing = new(Values.Processing);

    public static readonly StatusHistoryEntryStatus Shipped = new(Values.Shipped);

    public static readonly StatusHistoryEntryStatus Delivered = new(Values.Delivered);

    public static readonly StatusHistoryEntryStatus Cancelled = new(Values.Cancelled);

    public static readonly StatusHistoryEntryStatus Failed = new(Values.Failed);

    public StatusHistoryEntryStatus(string value)
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
    public static StatusHistoryEntryStatus FromCustom(string value)
    {
        return new StatusHistoryEntryStatus(value);
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

    public static bool operator ==(StatusHistoryEntryStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StatusHistoryEntryStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StatusHistoryEntryStatus value) => value.Value;

    public static explicit operator StatusHistoryEntryStatus(string value) => new(value);

    internal class StatusHistoryEntryStatusSerializer : JsonConverter<StatusHistoryEntryStatus>
    {
        public override StatusHistoryEntryStatus Read(
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
            return new StatusHistoryEntryStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StatusHistoryEntryStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StatusHistoryEntryStatus ReadAsPropertyName(
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
            return new StatusHistoryEntryStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StatusHistoryEntryStatus value,
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
        public const string AwaitingApproval = "awaiting_approval";

        public const string Submitted = "submitted";

        public const string Processing = "processing";

        public const string Shipped = "shipped";

        public const string Delivered = "delivered";

        public const string Cancelled = "cancelled";

        public const string Failed = "failed";
    }
}
