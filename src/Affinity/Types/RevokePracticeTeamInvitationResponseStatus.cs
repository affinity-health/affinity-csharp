using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RevokePracticeTeamInvitationResponseStatus.RevokePracticeTeamInvitationResponseStatusSerializer)
)]
[Serializable]
public readonly record struct RevokePracticeTeamInvitationResponseStatus : IStringEnum
{
    public static readonly RevokePracticeTeamInvitationResponseStatus Accepted = new(
        Values.Accepted
    );

    public static readonly RevokePracticeTeamInvitationResponseStatus Declined = new(
        Values.Declined
    );

    public static readonly RevokePracticeTeamInvitationResponseStatus Pending = new(Values.Pending);

    public static readonly RevokePracticeTeamInvitationResponseStatus Expired = new(Values.Expired);

    public static readonly RevokePracticeTeamInvitationResponseStatus Revoked = new(Values.Revoked);

    public RevokePracticeTeamInvitationResponseStatus(string value)
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
    public static RevokePracticeTeamInvitationResponseStatus FromCustom(string value)
    {
        return new RevokePracticeTeamInvitationResponseStatus(value);
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
        RevokePracticeTeamInvitationResponseStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RevokePracticeTeamInvitationResponseStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(RevokePracticeTeamInvitationResponseStatus value) =>
        value.Value;

    public static explicit operator RevokePracticeTeamInvitationResponseStatus(string value) =>
        new(value);

    internal class RevokePracticeTeamInvitationResponseStatusSerializer
        : JsonConverter<RevokePracticeTeamInvitationResponseStatus>
    {
        public override RevokePracticeTeamInvitationResponseStatus Read(
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
            return new RevokePracticeTeamInvitationResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RevokePracticeTeamInvitationResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RevokePracticeTeamInvitationResponseStatus ReadAsPropertyName(
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
            return new RevokePracticeTeamInvitationResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RevokePracticeTeamInvitationResponseStatus value,
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
        public const string Accepted = "accepted";

        public const string Declined = "declined";

        public const string Pending = "pending";

        public const string Expired = "expired";

        public const string Revoked = "revoked";
    }
}
