using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListPatientsResponseObject.ListPatientsResponseObjectSerializer))]
[Serializable]
public readonly record struct ListPatientsResponseObject : IStringEnum
{
    public static readonly ListPatientsResponseObject List = new(Values.List);

    public ListPatientsResponseObject(string value)
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
    public static ListPatientsResponseObject FromCustom(string value)
    {
        return new ListPatientsResponseObject(value);
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

    public static bool operator ==(ListPatientsResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPatientsResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPatientsResponseObject value) => value.Value;

    public static explicit operator ListPatientsResponseObject(string value) => new(value);

    internal class ListPatientsResponseObjectSerializer : JsonConverter<ListPatientsResponseObject>
    {
        public override ListPatientsResponseObject Read(
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
            return new ListPatientsResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPatientsResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPatientsResponseObject ReadAsPropertyName(
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
            return new ListPatientsResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPatientsResponseObject value,
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
