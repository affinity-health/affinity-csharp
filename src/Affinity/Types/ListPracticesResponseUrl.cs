using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListPracticesResponseUrl.ListPracticesResponseUrlSerializer))]
[Serializable]
public readonly record struct ListPracticesResponseUrl : IStringEnum
{
    public static readonly ListPracticesResponseUrl V1Practices = new(Values.V1Practices);

    public ListPracticesResponseUrl(string value)
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
    public static ListPracticesResponseUrl FromCustom(string value)
    {
        return new ListPracticesResponseUrl(value);
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

    public static bool operator ==(ListPracticesResponseUrl value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPracticesResponseUrl value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPracticesResponseUrl value) => value.Value;

    public static explicit operator ListPracticesResponseUrl(string value) => new(value);

    internal class ListPracticesResponseUrlSerializer : JsonConverter<ListPracticesResponseUrl>
    {
        public override ListPracticesResponseUrl Read(
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
            return new ListPracticesResponseUrl(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPracticesResponseUrl value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPracticesResponseUrl ReadAsPropertyName(
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
            return new ListPracticesResponseUrl(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPracticesResponseUrl value,
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
        public const string V1Practices = "/v1/practices";
    }
}
