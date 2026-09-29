using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(CancelOrderResponseStatus.CancelOrderResponseStatusSerializer))]
[Serializable]
public readonly record struct CancelOrderResponseStatus : IStringEnum
{
    public static readonly CancelOrderResponseStatus Blocked = new(Values.Blocked);

    public static readonly CancelOrderResponseStatus Cancelled = new(Values.Cancelled);

    public static readonly CancelOrderResponseStatus Delivered = new(Values.Delivered);

    public static readonly CancelOrderResponseStatus Draft = new(Values.Draft);

    public static readonly CancelOrderResponseStatus PartiallySubmitted = new(
        Values.PartiallySubmitted
    );

    public static readonly CancelOrderResponseStatus RequiresProviderSignature = new(
        Values.RequiresProviderSignature
    );

    public static readonly CancelOrderResponseStatus Processing = new(Values.Processing);

    public static readonly CancelOrderResponseStatus Ready = new(Values.Ready);

    public static readonly CancelOrderResponseStatus Rejected = new(Values.Rejected);

    public static readonly CancelOrderResponseStatus Shipped = new(Values.Shipped);

    public static readonly CancelOrderResponseStatus Submitted = new(Values.Submitted);

    public CancelOrderResponseStatus(string value)
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
    public static CancelOrderResponseStatus FromCustom(string value)
    {
        return new CancelOrderResponseStatus(value);
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

    public static bool operator ==(CancelOrderResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CancelOrderResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CancelOrderResponseStatus value) => value.Value;

    public static explicit operator CancelOrderResponseStatus(string value) => new(value);

    internal class CancelOrderResponseStatusSerializer : JsonConverter<CancelOrderResponseStatus>
    {
        public override CancelOrderResponseStatus Read(
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
            return new CancelOrderResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelOrderResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelOrderResponseStatus ReadAsPropertyName(
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
            return new CancelOrderResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelOrderResponseStatus value,
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
