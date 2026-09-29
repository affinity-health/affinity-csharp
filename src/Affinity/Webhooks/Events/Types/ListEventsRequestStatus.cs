using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Webhooks;

[JsonConverter(typeof(ListEventsRequestStatus.ListEventsRequestStatusSerializer))]
[Serializable]
public readonly record struct ListEventsRequestStatus : IStringEnum
{
    public static readonly ListEventsRequestStatus All = new(Values.All);

    public static readonly ListEventsRequestStatus Delivered = new(Values.Delivered);

    public static readonly ListEventsRequestStatus Failed = new(Values.Failed);

    public static readonly ListEventsRequestStatus Pending = new(Values.Pending);

    public ListEventsRequestStatus(string value)
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
    public static ListEventsRequestStatus FromCustom(string value)
    {
        return new ListEventsRequestStatus(value);
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

    public static bool operator ==(ListEventsRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListEventsRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListEventsRequestStatus value) => value.Value;

    public static explicit operator ListEventsRequestStatus(string value) => new(value);

    internal class ListEventsRequestStatusSerializer : JsonConverter<ListEventsRequestStatus>
    {
        public override ListEventsRequestStatus Read(
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
            return new ListEventsRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListEventsRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListEventsRequestStatus ReadAsPropertyName(
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
            return new ListEventsRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListEventsRequestStatus value,
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
        public const string All = "all";

        public const string Delivered = "delivered";

        public const string Failed = "failed";

        public const string Pending = "pending";
    }
}
