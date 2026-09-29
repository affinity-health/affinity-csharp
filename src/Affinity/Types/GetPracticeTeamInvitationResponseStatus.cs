using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetPracticeTeamInvitationResponseStatus.GetPracticeTeamInvitationResponseStatusSerializer)
)]
[Serializable]
public readonly record struct GetPracticeTeamInvitationResponseStatus : IStringEnum
{
    public static readonly GetPracticeTeamInvitationResponseStatus Accepted = new(Values.Accepted);

    public static readonly GetPracticeTeamInvitationResponseStatus Declined = new(Values.Declined);

    public static readonly GetPracticeTeamInvitationResponseStatus Pending = new(Values.Pending);

    public static readonly GetPracticeTeamInvitationResponseStatus Expired = new(Values.Expired);

    public static readonly GetPracticeTeamInvitationResponseStatus Revoked = new(Values.Revoked);

    public GetPracticeTeamInvitationResponseStatus(string value)
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
    public static GetPracticeTeamInvitationResponseStatus FromCustom(string value)
    {
        return new GetPracticeTeamInvitationResponseStatus(value);
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

    public static bool operator ==(GetPracticeTeamInvitationResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetPracticeTeamInvitationResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetPracticeTeamInvitationResponseStatus value) =>
        value.Value;

    public static explicit operator GetPracticeTeamInvitationResponseStatus(string value) =>
        new(value);

    internal class GetPracticeTeamInvitationResponseStatusSerializer
        : JsonConverter<GetPracticeTeamInvitationResponseStatus>
    {
        public override GetPracticeTeamInvitationResponseStatus Read(
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
            return new GetPracticeTeamInvitationResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPracticeTeamInvitationResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPracticeTeamInvitationResponseStatus ReadAsPropertyName(
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
            return new GetPracticeTeamInvitationResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPracticeTeamInvitationResponseStatus value,
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
