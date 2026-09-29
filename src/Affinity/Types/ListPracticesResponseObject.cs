using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListPracticesResponseObject.ListPracticesResponseObjectSerializer))]
[Serializable]
public readonly record struct ListPracticesResponseObject : IStringEnum
{
    public static readonly ListPracticesResponseObject List = new(Values.List);

    public ListPracticesResponseObject(string value)
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
    public static ListPracticesResponseObject FromCustom(string value)
    {
        return new ListPracticesResponseObject(value);
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

    public static bool operator ==(ListPracticesResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPracticesResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPracticesResponseObject value) => value.Value;

    public static explicit operator ListPracticesResponseObject(string value) => new(value);

    internal class ListPracticesResponseObjectSerializer
        : JsonConverter<ListPracticesResponseObject>
    {
        public override ListPracticesResponseObject Read(
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
            return new ListPracticesResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPracticesResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPracticesResponseObject ReadAsPropertyName(
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
            return new ListPracticesResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPracticesResponseObject value,
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
        public const string List = "list";
    }
}
