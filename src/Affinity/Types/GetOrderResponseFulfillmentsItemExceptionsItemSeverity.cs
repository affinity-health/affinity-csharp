using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetOrderResponseFulfillmentsItemExceptionsItemSeverity.GetOrderResponseFulfillmentsItemExceptionsItemSeveritySerializer)
)]
[Serializable]
public readonly record struct GetOrderResponseFulfillmentsItemExceptionsItemSeverity : IStringEnum
{
    public static readonly GetOrderResponseFulfillmentsItemExceptionsItemSeverity Warning = new(
        Values.Warning
    );

    public static readonly GetOrderResponseFulfillmentsItemExceptionsItemSeverity Critical = new(
        Values.Critical
    );

    public GetOrderResponseFulfillmentsItemExceptionsItemSeverity(string value)
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
    public static GetOrderResponseFulfillmentsItemExceptionsItemSeverity FromCustom(string value)
    {
        return new GetOrderResponseFulfillmentsItemExceptionsItemSeverity(value);
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
        GetOrderResponseFulfillmentsItemExceptionsItemSeverity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetOrderResponseFulfillmentsItemExceptionsItemSeverity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetOrderResponseFulfillmentsItemExceptionsItemSeverity value
    ) => value.Value;

    public static explicit operator GetOrderResponseFulfillmentsItemExceptionsItemSeverity(
        string value
    ) => new(value);

    internal class GetOrderResponseFulfillmentsItemExceptionsItemSeveritySerializer
        : JsonConverter<GetOrderResponseFulfillmentsItemExceptionsItemSeverity>
    {
        public override GetOrderResponseFulfillmentsItemExceptionsItemSeverity Read(
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
            return new GetOrderResponseFulfillmentsItemExceptionsItemSeverity(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrderResponseFulfillmentsItemExceptionsItemSeverity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetOrderResponseFulfillmentsItemExceptionsItemSeverity ReadAsPropertyName(
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
            return new GetOrderResponseFulfillmentsItemExceptionsItemSeverity(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrderResponseFulfillmentsItemExceptionsItemSeverity value,
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
