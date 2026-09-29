using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RevokePracticeTeamInvitationResponsePersonObject.RevokePracticeTeamInvitationResponsePersonObjectSerializer)
)]
[Serializable]
public readonly record struct RevokePracticeTeamInvitationResponsePersonObject : IStringEnum
{
    public static readonly RevokePracticeTeamInvitationResponsePersonObject TeamPerson = new(
        Values.TeamPerson
    );

    public RevokePracticeTeamInvitationResponsePersonObject(string value)
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
    public static RevokePracticeTeamInvitationResponsePersonObject FromCustom(string value)
    {
        return new RevokePracticeTeamInvitationResponsePersonObject(value);
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
        RevokePracticeTeamInvitationResponsePersonObject value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RevokePracticeTeamInvitationResponsePersonObject value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RevokePracticeTeamInvitationResponsePersonObject value
    ) => value.Value;

    public static explicit operator RevokePracticeTeamInvitationResponsePersonObject(
        string value
    ) => new(value);

    internal class RevokePracticeTeamInvitationResponsePersonObjectSerializer
        : JsonConverter<RevokePracticeTeamInvitationResponsePersonObject>
    {
        public override RevokePracticeTeamInvitationResponsePersonObject Read(
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
            return new RevokePracticeTeamInvitationResponsePersonObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RevokePracticeTeamInvitationResponsePersonObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RevokePracticeTeamInvitationResponsePersonObject ReadAsPropertyName(
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
            return new RevokePracticeTeamInvitationResponsePersonObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RevokePracticeTeamInvitationResponsePersonObject value,
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
