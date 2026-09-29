using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListOrdersRequestStatus.ListOrdersRequestStatusSerializer))]
[Serializable]
public readonly record struct ListOrdersRequestStatus : IStringEnum
{
    public static readonly ListOrdersRequestStatus Blocked = new(Values.Blocked);

    public static readonly ListOrdersRequestStatus Cancelled = new(Values.Cancelled);

    public static readonly ListOrdersRequestStatus Delivered = new(Values.Delivered);

    public static readonly ListOrdersRequestStatus Draft = new(Values.Draft);

    public static readonly ListOrdersRequestStatus PartiallySubmitted = new(
        Values.PartiallySubmitted
    );

    public static readonly ListOrdersRequestStatus RequiresProviderSignature = new(
        Values.RequiresProviderSignature
    );

    public static readonly ListOrdersRequestStatus Processing = new(Values.Processing);

    public static readonly ListOrdersRequestStatus Ready = new(Values.Ready);

    public static readonly ListOrdersRequestStatus Rejected = new(Values.Rejected);

    public static readonly ListOrdersRequestStatus Shipped = new(Values.Shipped);

    public static readonly ListOrdersRequestStatus Submitted = new(Values.Submitted);

    public ListOrdersRequestStatus(string value)
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
    public static ListOrdersRequestStatus FromCustom(string value)
    {
        return new ListOrdersRequestStatus(value);
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

    public static bool operator ==(ListOrdersRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListOrdersRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListOrdersRequestStatus value) => value.Value;

    public static explicit operator ListOrdersRequestStatus(string value) => new(value);

    internal class ListOrdersRequestStatusSerializer : JsonConverter<ListOrdersRequestStatus>
    {
        public override ListOrdersRequestStatus Read(
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
            return new ListOrdersRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersRequestStatus ReadAsPropertyName(
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
            return new ListOrdersRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersRequestStatus value,
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
        public const string Blocked = "blocked";

        public const string Cancelled = "cancelled";

        public const string Delivered = "delivered";

        public const string Draft = "draft";

        public const string PartiallySubmitted = "partially_submitted";

        public const string RequiresProviderSignature = "requires_provider_signature";

        public const string Processing = "processing";

        public const string Ready = "ready";

        public const string Rejected = "rejected";

        public const string Shipped = "shipped";

        public const string Submitted = "submitted";
    }
}
