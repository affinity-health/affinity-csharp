using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListPatientsRequestSort.ListPatientsRequestSortSerializer))]
[Serializable]
public readonly record struct ListPatientsRequestSort : IStringEnum
{
    public static readonly ListPatientsRequestSort Created = new(Values.Created);

    public static readonly ListPatientsRequestSort Name = new(Values.Name);

    public ListPatientsRequestSort(string value)
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
    public static ListPatientsRequestSort FromCustom(string value)
    {
        return new ListPatientsRequestSort(value);
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

    public static bool operator ==(ListPatientsRequestSort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPatientsRequestSort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPatientsRequestSort value) => value.Value;

    public static explicit operator ListPatientsRequestSort(string value) => new(value);

    internal class ListPatientsRequestSortSerializer : JsonConverter<ListPatientsRequestSort>
    {
        public override ListPatientsRequestSort Read(
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
            return new ListPatientsRequestSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPatientsRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPatientsRequestSort ReadAsPropertyName(
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
            return new ListPatientsRequestSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPatientsRequestSort value,
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
        public const string Created = "created";

        public const string Name = "name";
    }
}
