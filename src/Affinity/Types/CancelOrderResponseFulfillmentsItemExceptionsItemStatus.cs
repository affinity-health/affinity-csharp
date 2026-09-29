using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CancelOrderResponseFulfillmentsItemExceptionsItemStatus.CancelOrderResponseFulfillmentsItemExceptionsItemStatusSerializer)
)]
[Serializable]
public readonly record struct CancelOrderResponseFulfillmentsItemExceptionsItemStatus : IStringEnum
{
    public static readonly CancelOrderResponseFulfillmentsItemExceptionsItemStatus Open = new(
        Values.Open
    );

    public static readonly CancelOrderResponseFulfillmentsItemExceptionsItemStatus Acknowledged =
        new(Values.Acknowledged);

    public static readonly CancelOrderResponseFulfillmentsItemExceptionsItemStatus Resolved = new(
        Values.Resolved
    );

    public CancelOrderResponseFulfillmentsItemExceptionsItemStatus(string value)
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
    public static CancelOrderResponseFulfillmentsItemExceptionsItemStatus FromCustom(string value)
    {
        return new CancelOrderResponseFulfillmentsItemExceptionsItemStatus(value);
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
        CancelOrderResponseFulfillmentsItemExceptionsItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CancelOrderResponseFulfillmentsItemExceptionsItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CancelOrderResponseFulfillmentsItemExceptionsItemStatus value
    ) => value.Value;

    public static explicit operator CancelOrderResponseFulfillmentsItemExceptionsItemStatus(
        string value
    ) => new(value);

    internal class CancelOrderResponseFulfillmentsItemExceptionsItemStatusSerializer
        : JsonConverter<CancelOrderResponseFulfillmentsItemExceptionsItemStatus>
    {
        public override CancelOrderResponseFulfillmentsItemExceptionsItemStatus Read(
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
            return new CancelOrderResponseFulfillmentsItemExceptionsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelOrderResponseFulfillmentsItemExceptionsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelOrderResponseFulfillmentsItemExceptionsItemStatus ReadAsPropertyName(
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
            return new CancelOrderResponseFulfillmentsItemExceptionsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelOrderResponseFulfillmentsItemExceptionsItemStatus value,
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
