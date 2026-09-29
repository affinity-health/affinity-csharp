using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListOrdersResponseUrl.ListOrdersResponseUrlSerializer))]
[Serializable]
public readonly record struct ListOrdersResponseUrl : IStringEnum
{
    public static readonly ListOrdersResponseUrl V1Orders = new(Values.V1Orders);

    public ListOrdersResponseUrl(string value)
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
    public static ListOrdersResponseUrl FromCustom(string value)
    {
        return new ListOrdersResponseUrl(value);
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

    public static bool operator ==(ListOrdersResponseUrl value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListOrdersResponseUrl value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListOrdersResponseUrl value) => value.Value;

    public static explicit operator ListOrdersResponseUrl(string value) => new(value);

    internal class ListOrdersResponseUrlSerializer : JsonConverter<ListOrdersResponseUrl>
    {
        public override ListOrdersResponseUrl Read(
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
            return new ListOrdersResponseUrl(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseUrl value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseUrl ReadAsPropertyName(
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
            return new ListOrdersResponseUrl(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseUrl value,
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
        public const string V1Orders = "/v1/orders";
    }
}
