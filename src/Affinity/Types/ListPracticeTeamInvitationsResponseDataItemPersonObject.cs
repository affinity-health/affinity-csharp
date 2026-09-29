using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPracticeTeamInvitationsResponseDataItemPersonObject.ListPracticeTeamInvitationsResponseDataItemPersonObjectSerializer)
)]
[Serializable]
public readonly record struct ListPracticeTeamInvitationsResponseDataItemPersonObject : IStringEnum
{
    public static readonly ListPracticeTeamInvitationsResponseDataItemPersonObject TeamPerson = new(
        Values.TeamPerson
    );

    public ListPracticeTeamInvitationsResponseDataItemPersonObject(string value)
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
    public static ListPracticeTeamInvitationsResponseDataItemPersonObject FromCustom(string value)
    {
        return new ListPracticeTeamInvitationsResponseDataItemPersonObject(value);
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
        ListPracticeTeamInvitationsResponseDataItemPersonObject value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPracticeTeamInvitationsResponseDataItemPersonObject value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListPracticeTeamInvitationsResponseDataItemPersonObject value
    ) => value.Value;

    public static explicit operator ListPracticeTeamInvitationsResponseDataItemPersonObject(
        string value
    ) => new(value);

    internal class ListPracticeTeamInvitationsResponseDataItemPersonObjectSerializer
        : JsonConverter<ListPracticeTeamInvitationsResponseDataItemPersonObject>
    {
        public override ListPracticeTeamInvitationsResponseDataItemPersonObject Read(
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
            return new ListPracticeTeamInvitationsResponseDataItemPersonObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPracticeTeamInvitationsResponseDataItemPersonObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPracticeTeamInvitationsResponseDataItemPersonObject ReadAsPropertyName(
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
            return new ListPracticeTeamInvitationsResponseDataItemPersonObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPracticeTeamInvitationsResponseDataItemPersonObject value,
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
        public const string TeamPerson = "team_person";
    }
}
