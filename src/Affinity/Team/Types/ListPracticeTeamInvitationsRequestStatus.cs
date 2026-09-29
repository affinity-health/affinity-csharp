using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPracticeTeamInvitationsRequestStatus.ListPracticeTeamInvitationsRequestStatusSerializer)
)]
[Serializable]
public readonly record struct ListPracticeTeamInvitationsRequestStatus : IStringEnum
{
    public static readonly ListPracticeTeamInvitationsRequestStatus Accepted = new(Values.Accepted);

    public static readonly ListPracticeTeamInvitationsRequestStatus Declined = new(Values.Declined);

    public static readonly ListPracticeTeamInvitationsRequestStatus Pending = new(Values.Pending);

    public static readonly ListPracticeTeamInvitationsRequestStatus Expired = new(Values.Expired);

    public static readonly ListPracticeTeamInvitationsRequestStatus Revoked = new(Values.Revoked);

    public ListPracticeTeamInvitationsRequestStatus(string value)
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
    public static ListPracticeTeamInvitationsRequestStatus FromCustom(string value)
    {
        return new ListPracticeTeamInvitationsRequestStatus(value);
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
        ListPracticeTeamInvitationsRequestStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPracticeTeamInvitationsRequestStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListPracticeTeamInvitationsRequestStatus value) =>
        value.Value;

    public static explicit operator ListPracticeTeamInvitationsRequestStatus(string value) =>
        new(value);

    internal class ListPracticeTeamInvitationsRequestStatusSerializer
        : JsonConverter<ListPracticeTeamInvitationsRequestStatus>
    {
        public override ListPracticeTeamInvitationsRequestStatus Read(
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
            return new ListPracticeTeamInvitationsRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPracticeTeamInvitationsRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPracticeTeamInvitationsRequestStatus ReadAsPropertyName(
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
            return new ListPracticeTeamInvitationsRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPracticeTeamInvitationsRequestStatus value,
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
