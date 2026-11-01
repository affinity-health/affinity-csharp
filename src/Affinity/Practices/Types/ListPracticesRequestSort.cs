using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListPracticesRequestSort.ListPracticesRequestSortSerializer))]
[Serializable]
public readonly record struct ListPracticesRequestSort : IStringEnum
{
    public static readonly ListPracticesRequestSort Name = new(Values.Name);

    public static readonly ListPracticesRequestSort NameDesc = new(Values.NameDesc);

    public static readonly ListPracticesRequestSort Location = new(Values.Location);

    public static readonly ListPracticesRequestSort LocationDesc = new(Values.LocationDesc);

    public static readonly ListPracticesRequestSort Mode = new(Values.Mode);

    public static readonly ListPracticesRequestSort ModeDesc = new(Values.ModeDesc);

    public static readonly ListPracticesRequestSort Created = new(Values.Created);

    public static readonly ListPracticesRequestSort CreatedDesc = new(Values.CreatedDesc);

    public ListPracticesRequestSort(string value)
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
    public static ListPracticesRequestSort FromCustom(string value)
    {
        return new ListPracticesRequestSort(value);
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

    public static bool operator ==(ListPracticesRequestSort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPracticesRequestSort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPracticesRequestSort value) => value.Value;

    public static explicit operator ListPracticesRequestSort(string value) => new(value);

    internal class ListPracticesRequestSortSerializer : JsonConverter<ListPracticesRequestSort>
    {
        public override ListPracticesRequestSort Read(
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
            return new ListPracticesRequestSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPracticesRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPracticesRequestSort ReadAsPropertyName(
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
            return new ListPracticesRequestSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPracticesRequestSort value,
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
        public const string Name = "name";

        public const string NameDesc = "name_desc";

        public const string Location = "location";

        public const string LocationDesc = "location_desc";

        public const string Mode = "mode";

        public const string ModeDesc = "mode_desc";

        public const string Created = "created";

        public const string CreatedDesc = "created_desc";
    }
}
