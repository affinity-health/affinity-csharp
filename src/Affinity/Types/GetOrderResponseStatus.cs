using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(GetOrderResponseStatus.GetOrderResponseStatusSerializer))]
[Serializable]
public readonly record struct GetOrderResponseStatus : IStringEnum
{
    public static readonly GetOrderResponseStatus Blocked = new(Values.Blocked);

    public static readonly GetOrderResponseStatus Cancelled = new(Values.Cancelled);

    public static readonly GetOrderResponseStatus Delivered = new(Values.Delivered);

    public static readonly GetOrderResponseStatus Draft = new(Values.Draft);

    public static readonly GetOrderResponseStatus PartiallySubmitted = new(
        Values.PartiallySubmitted
    );

    public static readonly GetOrderResponseStatus RequiresProviderSignature = new(
        Values.RequiresProviderSignature
    );

    public static readonly GetOrderResponseStatus Processing = new(Values.Processing);

    public static readonly GetOrderResponseStatus Ready = new(Values.Ready);

    public static readonly GetOrderResponseStatus Rejected = new(Values.Rejected);

    public static readonly GetOrderResponseStatus Shipped = new(Values.Shipped);

    public static readonly GetOrderResponseStatus Submitted = new(Values.Submitted);

    public GetOrderResponseStatus(string value)
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
    public static GetOrderResponseStatus FromCustom(string value)
    {
        return new GetOrderResponseStatus(value);
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

    public static bool operator ==(GetOrderResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetOrderResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetOrderResponseStatus value) => value.Value;

    public static explicit operator GetOrderResponseStatus(string value) => new(value);

    internal class GetOrderResponseStatusSerializer : JsonConverter<GetOrderResponseStatus>
    {
        public override GetOrderResponseStatus Read(
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
            return new GetOrderResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrderResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetOrderResponseStatus ReadAsPropertyName(
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
            return new GetOrderResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrderResponseStatus value,
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
