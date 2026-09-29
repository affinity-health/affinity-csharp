using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPracticeLocationsResponseDataItemObject.ListPracticeLocationsResponseDataItemObjectSerializer)
)]
[Serializable]
public readonly record struct ListPracticeLocationsResponseDataItemObject : IStringEnum
{
    public static readonly ListPracticeLocationsResponseDataItemObject Location = new(
        Values.Location
    );

    public ListPracticeLocationsResponseDataItemObject(string value)
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
    public static ListPracticeLocationsResponseDataItemObject FromCustom(string value)
    {
        return new ListPracticeLocationsResponseDataItemObject(value);
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
        ListPracticeLocationsResponseDataItemObject value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPracticeLocationsResponseDataItemObject value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListPracticeLocationsResponseDataItemObject value) =>
        value.Value;

    public static explicit operator ListPracticeLocationsResponseDataItemObject(string value) =>
        new(value);

    internal class ListPracticeLocationsResponseDataItemObjectSerializer
        : JsonConverter<ListPracticeLocationsResponseDataItemObject>
    {
        public override ListPracticeLocationsResponseDataItemObject Read(
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
            return new ListPracticeLocationsResponseDataItemObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPracticeLocationsResponseDataItemObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPracticeLocationsResponseDataItemObject ReadAsPropertyName(
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
            return new ListPracticeLocationsResponseDataItemObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPracticeLocationsResponseDataItemObject value,
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
        public const string Location = "location";
    }
}
