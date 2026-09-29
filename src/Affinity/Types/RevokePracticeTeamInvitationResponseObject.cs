using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RevokePracticeTeamInvitationResponseObject.RevokePracticeTeamInvitationResponseObjectSerializer)
)]
[Serializable]
public readonly record struct RevokePracticeTeamInvitationResponseObject : IStringEnum
{
    public static readonly RevokePracticeTeamInvitationResponseObject TeamInvitation = new(
        Values.TeamInvitation
    );

    public RevokePracticeTeamInvitationResponseObject(string value)
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
    public static RevokePracticeTeamInvitationResponseObject FromCustom(string value)
    {
        return new RevokePracticeTeamInvitationResponseObject(value);
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
        RevokePracticeTeamInvitationResponseObject value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RevokePracticeTeamInvitationResponseObject value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(RevokePracticeTeamInvitationResponseObject value) =>
        value.Value;

    public static explicit operator RevokePracticeTeamInvitationResponseObject(string value) =>
        new(value);

    internal class RevokePracticeTeamInvitationResponseObjectSerializer
        : JsonConverter<RevokePracticeTeamInvitationResponseObject>
    {
        public override RevokePracticeTeamInvitationResponseObject Read(
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
            return new RevokePracticeTeamInvitationResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RevokePracticeTeamInvitationResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RevokePracticeTeamInvitationResponseObject ReadAsPropertyName(
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
            return new RevokePracticeTeamInvitationResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RevokePracticeTeamInvitationResponseObject value,
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
        public const string TeamInvitation = "team_invitation";
    }
}
