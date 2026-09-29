using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListOrdersResponseDataItemStatus.ListOrdersResponseDataItemStatusSerializer))]
[Serializable]
public readonly record struct ListOrdersResponseDataItemStatus : IStringEnum
{
    public static readonly ListOrdersResponseDataItemStatus Blocked = new(Values.Blocked);

    public static readonly ListOrdersResponseDataItemStatus Cancelled = new(Values.Cancelled);

    public static readonly ListOrdersResponseDataItemStatus Delivered = new(Values.Delivered);

    public static readonly ListOrdersResponseDataItemStatus Draft = new(Values.Draft);

    public static readonly ListOrdersResponseDataItemStatus PartiallySubmitted = new(
        Values.PartiallySubmitted
    );

    public static readonly ListOrdersResponseDataItemStatus RequiresProviderSignature = new(
        Values.RequiresProviderSignature
    );

    public static readonly ListOrdersResponseDataItemStatus Processing = new(Values.Processing);

    public static readonly ListOrdersResponseDataItemStatus Ready = new(Values.Ready);

    public static readonly ListOrdersResponseDataItemStatus Rejected = new(Values.Rejected);

    public static readonly ListOrdersResponseDataItemStatus Shipped = new(Values.Shipped);

    public static readonly ListOrdersResponseDataItemStatus Submitted = new(Values.Submitted);

    public ListOrdersResponseDataItemStatus(string value)
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
    public static ListOrdersResponseDataItemStatus FromCustom(string value)
    {
        return new ListOrdersResponseDataItemStatus(value);
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

    public static bool operator ==(ListOrdersResponseDataItemStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListOrdersResponseDataItemStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListOrdersResponseDataItemStatus value) => value.Value;

    public static explicit operator ListOrdersResponseDataItemStatus(string value) => new(value);

    internal class ListOrdersResponseDataItemStatusSerializer
        : JsonConverter<ListOrdersResponseDataItemStatus>
    {
        public override ListOrdersResponseDataItemStatus Read(
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
            return new ListOrdersResponseDataItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseDataItemStatus ReadAsPropertyName(
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
            return new ListOrdersResponseDataItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemStatus value,
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
