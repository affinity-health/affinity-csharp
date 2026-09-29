using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemAvailability.ListCatalogItemsResponseDataItemAvailabilitySerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemAvailability : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemAvailability Available = new(
        Values.Available
    );

    public static readonly ListCatalogItemsResponseDataItemAvailability Backordered = new(
        Values.Backordered
    );

    public static readonly ListCatalogItemsResponseDataItemAvailability Unavailable = new(
        Values.Unavailable
    );

    public static readonly ListCatalogItemsResponseDataItemAvailability Unknown = new(
        Values.Unknown
    );

    public ListCatalogItemsResponseDataItemAvailability(string value)
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
    public static ListCatalogItemsResponseDataItemAvailability FromCustom(string value)
    {
        return new ListCatalogItemsResponseDataItemAvailability(value);
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
        ListCatalogItemsResponseDataItemAvailability value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemAvailability value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListCatalogItemsResponseDataItemAvailability value) =>
        value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemAvailability(string value) =>
        new(value);

    internal class ListCatalogItemsResponseDataItemAvailabilitySerializer
        : JsonConverter<ListCatalogItemsResponseDataItemAvailability>
    {
        public override ListCatalogItemsResponseDataItemAvailability Read(
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
            return new ListCatalogItemsResponseDataItemAvailability(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemAvailability value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemAvailability ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemAvailability(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemAvailability value,
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
        public const string Available = "available";

        public const string Backordered = "backordered";

        public const string Unavailable = "unavailable";

        public const string Unknown = "unknown";
    }
}
