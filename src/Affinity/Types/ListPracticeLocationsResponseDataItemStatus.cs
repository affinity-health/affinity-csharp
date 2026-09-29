using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPracticeLocationsResponseDataItemStatus.ListPracticeLocationsResponseDataItemStatusSerializer)
)]
[Serializable]
public readonly record struct ListPracticeLocationsResponseDataItemStatus : IStringEnum
{
    public static readonly ListPracticeLocationsResponseDataItemStatus Active = new(Values.Active);

    public static readonly ListPracticeLocationsResponseDataItemStatus Archived = new(
        Values.Archived
    );

    public ListPracticeLocationsResponseDataItemStatus(string value)
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
    public static ListPracticeLocationsResponseDataItemStatus FromCustom(string value)
    {
        return new ListPracticeLocationsResponseDataItemStatus(value);
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
        ListPracticeLocationsResponseDataItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPracticeLocationsResponseDataItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListPracticeLocationsResponseDataItemStatus value) =>
        value.Value;

    public static explicit operator ListPracticeLocationsResponseDataItemStatus(string value) =>
        new(value);

    internal class ListPracticeLocationsResponseDataItemStatusSerializer
        : JsonConverter<ListPracticeLocationsResponseDataItemStatus>
    {
        public override ListPracticeLocationsResponseDataItemStatus Read(
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
            return new ListPracticeLocationsResponseDataItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPracticeLocationsResponseDataItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPracticeLocationsResponseDataItemStatus ReadAsPropertyName(
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
            return new ListPracticeLocationsResponseDataItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPracticeLocationsResponseDataItemStatus value,
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
        public const string Active = "active";

        public const string Archived = "archived";
    }
}
