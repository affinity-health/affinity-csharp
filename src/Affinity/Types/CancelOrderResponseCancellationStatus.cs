using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CancelOrderResponseCancellationStatus.CancelOrderResponseCancellationStatusSerializer)
)]
[Serializable]
public readonly record struct CancelOrderResponseCancellationStatus : IStringEnum
{
    public static readonly CancelOrderResponseCancellationStatus Confirmed = new(Values.Confirmed);

    public static readonly CancelOrderResponseCancellationStatus Pending = new(Values.Pending);

    public static readonly CancelOrderResponseCancellationStatus Partial = new(Values.Partial);

    public static readonly CancelOrderResponseCancellationStatus Failed = new(Values.Failed);

    public CancelOrderResponseCancellationStatus(string value)
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
    public static CancelOrderResponseCancellationStatus FromCustom(string value)
    {
        return new CancelOrderResponseCancellationStatus(value);
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

    public static bool operator ==(CancelOrderResponseCancellationStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CancelOrderResponseCancellationStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CancelOrderResponseCancellationStatus value) =>
        value.Value;

    public static explicit operator CancelOrderResponseCancellationStatus(string value) =>
        new(value);

    internal class CancelOrderResponseCancellationStatusSerializer
        : JsonConverter<CancelOrderResponseCancellationStatus>
    {
        public override CancelOrderResponseCancellationStatus Read(
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
            return new CancelOrderResponseCancellationStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelOrderResponseCancellationStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelOrderResponseCancellationStatus ReadAsPropertyName(
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
            return new CancelOrderResponseCancellationStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelOrderResponseCancellationStatus value,
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

        public const string Pending = "pending";

        public const string Partial = "partial";

        public const string Failed = "failed";
    }
}
