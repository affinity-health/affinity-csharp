using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsRequestAvailability.ListCatalogItemsRequestAvailabilitySerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsRequestAvailability : IStringEnum
{
    public static readonly ListCatalogItemsRequestAvailability All = new(Values.All);

    public static readonly ListCatalogItemsRequestAvailability Orderable = new(Values.Orderable);

    public static readonly ListCatalogItemsRequestAvailability Unavailable = new(
        Values.Unavailable
    );

    public ListCatalogItemsRequestAvailability(string value)
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
    public static ListCatalogItemsRequestAvailability FromCustom(string value)
    {
        return new ListCatalogItemsRequestAvailability(value);
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

    public static bool operator ==(ListCatalogItemsRequestAvailability value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListCatalogItemsRequestAvailability value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListCatalogItemsRequestAvailability value) =>
        value.Value;

    public static explicit operator ListCatalogItemsRequestAvailability(string value) => new(value);

    internal class ListCatalogItemsRequestAvailabilitySerializer
        : JsonConverter<ListCatalogItemsRequestAvailability>
    {
        public override ListCatalogItemsRequestAvailability Read(
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
            return new ListCatalogItemsRequestAvailability(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsRequestAvailability value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsRequestAvailability ReadAsPropertyName(
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
            return new ListCatalogItemsRequestAvailability(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsRequestAvailability value,
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
