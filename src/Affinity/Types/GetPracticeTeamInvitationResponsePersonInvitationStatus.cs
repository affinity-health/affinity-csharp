using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetPracticeTeamInvitationResponsePersonInvitationStatus.GetPracticeTeamInvitationResponsePersonInvitationStatusSerializer)
)]
[Serializable]
public readonly record struct GetPracticeTeamInvitationResponsePersonInvitationStatus : IStringEnum
{
    public static readonly GetPracticeTeamInvitationResponsePersonInvitationStatus Accepted = new(
        Values.Accepted
    );

    public static readonly GetPracticeTeamInvitationResponsePersonInvitationStatus Declined = new(
        Values.Declined
    );

    public static readonly GetPracticeTeamInvitationResponsePersonInvitationStatus Pending = new(
        Values.Pending
    );

    public static readonly GetPracticeTeamInvitationResponsePersonInvitationStatus Expired = new(
        Values.Expired
    );

    public static readonly GetPracticeTeamInvitationResponsePersonInvitationStatus Revoked = new(
        Values.Revoked
    );

    public GetPracticeTeamInvitationResponsePersonInvitationStatus(string value)
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
    public static GetPracticeTeamInvitationResponsePersonInvitationStatus FromCustom(string value)
    {
        return new GetPracticeTeamInvitationResponsePersonInvitationStatus(value);
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
        GetPracticeTeamInvitationResponsePersonInvitationStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetPracticeTeamInvitationResponsePersonInvitationStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetPracticeTeamInvitationResponsePersonInvitationStatus value
    ) => value.Value;

    public static explicit operator GetPracticeTeamInvitationResponsePersonInvitationStatus(
        string value
    ) => new(value);

    internal class GetPracticeTeamInvitationResponsePersonInvitationStatusSerializer
        : JsonConverter<GetPracticeTeamInvitationResponsePersonInvitationStatus>
    {
        public override GetPracticeTeamInvitationResponsePersonInvitationStatus Read(
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
            return new GetPracticeTeamInvitationResponsePersonInvitationStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPracticeTeamInvitationResponsePersonInvitationStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPracticeTeamInvitationResponsePersonInvitationStatus ReadAsPropertyName(
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
            return new GetPracticeTeamInvitationResponsePersonInvitationStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPracticeTeamInvitationResponsePersonInvitationStatus value,
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
