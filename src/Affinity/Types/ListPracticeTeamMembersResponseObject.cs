using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPracticeTeamMembersResponseObject.ListPracticeTeamMembersResponseObjectSerializer)
)]
[Serializable]
public readonly record struct ListPracticeTeamMembersResponseObject : IStringEnum
{
    public static readonly ListPracticeTeamMembersResponseObject List = new(Values.List);

    public ListPracticeTeamMembersResponseObject(string value)
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
    public static ListPracticeTeamMembersResponseObject FromCustom(string value)
    {
        return new ListPracticeTeamMembersResponseObject(value);
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

    public static bool operator ==(ListPracticeTeamMembersResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPracticeTeamMembersResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPracticeTeamMembersResponseObject value) =>
        value.Value;

    public static explicit operator ListPracticeTeamMembersResponseObject(string value) =>
        new(value);

    internal class ListPracticeTeamMembersResponseObjectSerializer
        : JsonConverter<ListPracticeTeamMembersResponseObject>
    {
        public override ListPracticeTeamMembersResponseObject Read(
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
            return new ListPracticeTeamMembersResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPracticeTeamMembersResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPracticeTeamMembersResponseObject ReadAsPropertyName(
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
            return new ListPracticeTeamMembersResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPracticeTeamMembersResponseObject value,
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
