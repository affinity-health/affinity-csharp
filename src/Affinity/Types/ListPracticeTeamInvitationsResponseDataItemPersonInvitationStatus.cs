using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus.ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatusSerializer)
)]
[Serializable]
public readonly record struct ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus
    : IStringEnum
{
    public static readonly ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus Accepted =
        new(Values.Accepted);

    public static readonly ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus Declined =
        new(Values.Declined);

    public static readonly ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus Pending =
        new(Values.Pending);

    public static readonly ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus Expired =
        new(Values.Expired);

    public static readonly ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus Revoked =
        new(Values.Revoked);

    public ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus(string value)
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
    public static ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus FromCustom(
        string value
    )
    {
        return new ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus(value);
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
        ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus value
    ) => value.Value;

    public static explicit operator ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus(
        string value
    ) => new(value);

    internal class ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatusSerializer
        : JsonConverter<ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus>
    {
        public override ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus Read(
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
            return new ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus ReadAsPropertyName(
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
            return new ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPracticeTeamInvitationsResponseDataItemPersonInvitationStatus value,
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
