using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPatientsResponseDataItemProgramsItemStatus.ListPatientsResponseDataItemProgramsItemStatusSerializer)
)]
[Serializable]
public readonly record struct ListPatientsResponseDataItemProgramsItemStatus : IStringEnum
{
    public static readonly ListPatientsResponseDataItemProgramsItemStatus Active = new(
        Values.Active
    );

    public static readonly ListPatientsResponseDataItemProgramsItemStatus Completed = new(
        Values.Completed
    );

    public static readonly ListPatientsResponseDataItemProgramsItemStatus Paused = new(
        Values.Paused
    );

    public ListPatientsResponseDataItemProgramsItemStatus(string value)
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
    public static ListPatientsResponseDataItemProgramsItemStatus FromCustom(string value)
    {
        return new ListPatientsResponseDataItemProgramsItemStatus(value);
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
        ListPatientsResponseDataItemProgramsItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPatientsResponseDataItemProgramsItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListPatientsResponseDataItemProgramsItemStatus value) =>
        value.Value;

    public static explicit operator ListPatientsResponseDataItemProgramsItemStatus(string value) =>
        new(value);

    internal class ListPatientsResponseDataItemProgramsItemStatusSerializer
        : JsonConverter<ListPatientsResponseDataItemProgramsItemStatus>
    {
        public override ListPatientsResponseDataItemProgramsItemStatus Read(
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
            return new ListPatientsResponseDataItemProgramsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPatientsResponseDataItemProgramsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPatientsResponseDataItemProgramsItemStatus ReadAsPropertyName(
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
            return new ListPatientsResponseDataItemProgramsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPatientsResponseDataItemProgramsItemStatus value,
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

        public const string Completed = "completed";

        public const string Paused = "paused";
    }
}
