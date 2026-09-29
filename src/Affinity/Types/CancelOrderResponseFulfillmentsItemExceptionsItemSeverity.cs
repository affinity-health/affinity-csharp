using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CancelOrderResponseFulfillmentsItemExceptionsItemSeverity.CancelOrderResponseFulfillmentsItemExceptionsItemSeveritySerializer)
)]
[Serializable]
public readonly record struct CancelOrderResponseFulfillmentsItemExceptionsItemSeverity
    : IStringEnum
{
    public static readonly CancelOrderResponseFulfillmentsItemExceptionsItemSeverity Warning = new(
        Values.Warning
    );

    public static readonly CancelOrderResponseFulfillmentsItemExceptionsItemSeverity Critical = new(
        Values.Critical
    );

    public CancelOrderResponseFulfillmentsItemExceptionsItemSeverity(string value)
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
    public static CancelOrderResponseFulfillmentsItemExceptionsItemSeverity FromCustom(string value)
    {
        return new CancelOrderResponseFulfillmentsItemExceptionsItemSeverity(value);
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
        CancelOrderResponseFulfillmentsItemExceptionsItemSeverity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CancelOrderResponseFulfillmentsItemExceptionsItemSeverity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CancelOrderResponseFulfillmentsItemExceptionsItemSeverity value
    ) => value.Value;

    public static explicit operator CancelOrderResponseFulfillmentsItemExceptionsItemSeverity(
        string value
    ) => new(value);

    internal class CancelOrderResponseFulfillmentsItemExceptionsItemSeveritySerializer
        : JsonConverter<CancelOrderResponseFulfillmentsItemExceptionsItemSeverity>
    {
        public override CancelOrderResponseFulfillmentsItemExceptionsItemSeverity Read(
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
            return new CancelOrderResponseFulfillmentsItemExceptionsItemSeverity(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelOrderResponseFulfillmentsItemExceptionsItemSeverity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelOrderResponseFulfillmentsItemExceptionsItemSeverity ReadAsPropertyName(
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
            return new CancelOrderResponseFulfillmentsItemExceptionsItemSeverity(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelOrderResponseFulfillmentsItemExceptionsItemSeverity value,
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
        public const string Warning = "warning";

        public const string Critical = "critical";
    }
}
