using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPracticeTeamInvitationsResponseObject.ListPracticeTeamInvitationsResponseObjectSerializer)
)]
[Serializable]
public readonly record struct ListPracticeTeamInvitationsResponseObject : IStringEnum
{
    public static readonly ListPracticeTeamInvitationsResponseObject List = new(Values.List);

    public ListPracticeTeamInvitationsResponseObject(string value)
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
    public static ListPracticeTeamInvitationsResponseObject FromCustom(string value)
    {
        return new ListPracticeTeamInvitationsResponseObject(value);
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
        ListPracticeTeamInvitationsResponseObject value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPracticeTeamInvitationsResponseObject value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListPracticeTeamInvitationsResponseObject value) =>
        value.Value;

    public static explicit operator ListPracticeTeamInvitationsResponseObject(string value) =>
        new(value);

    internal class ListPracticeTeamInvitationsResponseObjectSerializer
        : JsonConverter<ListPracticeTeamInvitationsResponseObject>
    {
        public override ListPracticeTeamInvitationsResponseObject Read(
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
            return new ListPracticeTeamInvitationsResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPracticeTeamInvitationsResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPracticeTeamInvitationsResponseObject ReadAsPropertyName(
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
            return new ListPracticeTeamInvitationsResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPracticeTeamInvitationsResponseObject value,
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
