using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPatientsResponseDataItemObject.ListPatientsResponseDataItemObjectSerializer)
)]
[Serializable]
public readonly record struct ListPatientsResponseDataItemObject : IStringEnum
{
    public static readonly ListPatientsResponseDataItemObject Patient = new(Values.Patient);

    public ListPatientsResponseDataItemObject(string value)
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
    public static ListPatientsResponseDataItemObject FromCustom(string value)
    {
        return new ListPatientsResponseDataItemObject(value);
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

    public static bool operator ==(ListPatientsResponseDataItemObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPatientsResponseDataItemObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPatientsResponseDataItemObject value) => value.Value;

    public static explicit operator ListPatientsResponseDataItemObject(string value) => new(value);

    internal class ListPatientsResponseDataItemObjectSerializer
        : JsonConverter<ListPatientsResponseDataItemObject>
    {
        public override ListPatientsResponseDataItemObject Read(
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
            return new ListPatientsResponseDataItemObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPatientsResponseDataItemObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPatientsResponseDataItemObject ReadAsPropertyName(
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
            return new ListPatientsResponseDataItemObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPatientsResponseDataItemObject value,
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
        public const string Patient = "patient";
    }
}
