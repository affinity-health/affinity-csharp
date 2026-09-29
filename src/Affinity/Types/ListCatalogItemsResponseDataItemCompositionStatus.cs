using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListCatalogItemsResponseDataItemCompositionStatus.ListCatalogItemsResponseDataItemCompositionStatusSerializer)
)]
[Serializable]
public readonly record struct ListCatalogItemsResponseDataItemCompositionStatus : IStringEnum
{
    public static readonly ListCatalogItemsResponseDataItemCompositionStatus Complete = new(
        Values.Complete
    );

    public static readonly ListCatalogItemsResponseDataItemCompositionStatus Partial = new(
        Values.Partial
    );

    public static readonly ListCatalogItemsResponseDataItemCompositionStatus Unresolved = new(
        Values.Unresolved
    );

    public ListCatalogItemsResponseDataItemCompositionStatus(string value)
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
    public static ListCatalogItemsResponseDataItemCompositionStatus FromCustom(string value)
    {
        return new ListCatalogItemsResponseDataItemCompositionStatus(value);
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
        ListCatalogItemsResponseDataItemCompositionStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListCatalogItemsResponseDataItemCompositionStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListCatalogItemsResponseDataItemCompositionStatus value
    ) => value.Value;

    public static explicit operator ListCatalogItemsResponseDataItemCompositionStatus(
        string value
    ) => new(value);

    internal class ListCatalogItemsResponseDataItemCompositionStatusSerializer
        : JsonConverter<ListCatalogItemsResponseDataItemCompositionStatus>
    {
        public override ListCatalogItemsResponseDataItemCompositionStatus Read(
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
            return new ListCatalogItemsResponseDataItemCompositionStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemCompositionStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCatalogItemsResponseDataItemCompositionStatus ReadAsPropertyName(
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
            return new ListCatalogItemsResponseDataItemCompositionStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCatalogItemsResponseDataItemCompositionStatus value,
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
        public const string Complete = "complete";

        public const string Partial = "partial";

        public const string Unresolved = "unresolved";
    }
}
