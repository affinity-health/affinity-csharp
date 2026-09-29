using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Catalog;

[JsonConverter(typeof(ListItemsRequestView.ListItemsRequestViewSerializer))]
[Serializable]
public readonly record struct ListItemsRequestView : IStringEnum
{
    public static readonly ListItemsRequestView Offers = new(Values.Offers);

    public static readonly ListItemsRequestView Medications = new(Values.Medications);

    public ListItemsRequestView(string value)
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
    public static ListItemsRequestView FromCustom(string value)
    {
        return new ListItemsRequestView(value);
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

    public static bool operator ==(ListItemsRequestView value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListItemsRequestView value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListItemsRequestView value) => value.Value;

    public static explicit operator ListItemsRequestView(string value) => new(value);

    internal class ListItemsRequestViewSerializer : JsonConverter<ListItemsRequestView>
    {
        public override ListItemsRequestView Read(
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
            return new ListItemsRequestView(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListItemsRequestView value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListItemsRequestView ReadAsPropertyName(
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
            return new ListItemsRequestView(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListItemsRequestView value,
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
        public const string Offers = "offers";

        public const string Medications = "medications";
    }
}
