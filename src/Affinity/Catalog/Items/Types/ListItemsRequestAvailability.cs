using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Catalog;

[JsonConverter(typeof(ListItemsRequestAvailability.ListItemsRequestAvailabilitySerializer))]
[Serializable]
public readonly record struct ListItemsRequestAvailability : IStringEnum
{
    public static readonly ListItemsRequestAvailability All = new(Values.All);

    public static readonly ListItemsRequestAvailability Orderable = new(Values.Orderable);

    public static readonly ListItemsRequestAvailability Unavailable = new(Values.Unavailable);

    public ListItemsRequestAvailability(string value)
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
    public static ListItemsRequestAvailability FromCustom(string value)
    {
        return new ListItemsRequestAvailability(value);
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

    public static bool operator ==(ListItemsRequestAvailability value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListItemsRequestAvailability value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListItemsRequestAvailability value) => value.Value;

    public static explicit operator ListItemsRequestAvailability(string value) => new(value);

    internal class ListItemsRequestAvailabilitySerializer
        : JsonConverter<ListItemsRequestAvailability>
    {
        public override ListItemsRequestAvailability Read(
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
            return new ListItemsRequestAvailability(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListItemsRequestAvailability value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListItemsRequestAvailability ReadAsPropertyName(
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
            return new ListItemsRequestAvailability(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListItemsRequestAvailability value,
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

        public const string Orderable = "orderable";

        public const string Unavailable = "unavailable";
    }
}
