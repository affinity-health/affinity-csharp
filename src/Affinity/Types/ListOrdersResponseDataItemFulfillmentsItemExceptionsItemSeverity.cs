using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity.ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeveritySerializer)
)]
[Serializable]
public readonly record struct ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity
    : IStringEnum
{
    public static readonly ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity Warning =
        new(Values.Warning);

    public static readonly ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity Critical =
        new(Values.Critical);

    public ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity(string value)
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
    public static ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity FromCustom(
        string value
    )
    {
        return new ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity(value);
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
        ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity value
    ) => value.Value;

    public static explicit operator ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity(
        string value
    ) => new(value);

    internal class ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeveritySerializer
        : JsonConverter<ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity>
    {
        public override ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity Read(
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
            return new ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity ReadAsPropertyName(
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
            return new ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemFulfillmentsItemExceptionsItemSeverity value,
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
