using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPracticeTeamInvitationsResponseDataItemStatus.ListPracticeTeamInvitationsResponseDataItemStatusSerializer)
)]
[Serializable]
public readonly record struct ListPracticeTeamInvitationsResponseDataItemStatus : IStringEnum
{
    public static readonly ListPracticeTeamInvitationsResponseDataItemStatus Accepted = new(
        Values.Accepted
    );

    public static readonly ListPracticeTeamInvitationsResponseDataItemStatus Declined = new(
        Values.Declined
    );

    public static readonly ListPracticeTeamInvitationsResponseDataItemStatus Pending = new(
        Values.Pending
    );

    public static readonly ListPracticeTeamInvitationsResponseDataItemStatus Expired = new(
        Values.Expired
    );

    public static readonly ListPracticeTeamInvitationsResponseDataItemStatus Revoked = new(
        Values.Revoked
    );

    public ListPracticeTeamInvitationsResponseDataItemStatus(string value)
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
    public static ListPracticeTeamInvitationsResponseDataItemStatus FromCustom(string value)
    {
        return new ListPracticeTeamInvitationsResponseDataItemStatus(value);
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
        ListPracticeTeamInvitationsResponseDataItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPracticeTeamInvitationsResponseDataItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListPracticeTeamInvitationsResponseDataItemStatus value
    ) => value.Value;

    public static explicit operator ListPracticeTeamInvitationsResponseDataItemStatus(
        string value
    ) => new(value);

    internal class ListPracticeTeamInvitationsResponseDataItemStatusSerializer
        : JsonConverter<ListPracticeTeamInvitationsResponseDataItemStatus>
    {
        public override ListPracticeTeamInvitationsResponseDataItemStatus Read(
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
            return new ListPracticeTeamInvitationsResponseDataItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPracticeTeamInvitationsResponseDataItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPracticeTeamInvitationsResponseDataItemStatus ReadAsPropertyName(
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
            return new ListPracticeTeamInvitationsResponseDataItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPracticeTeamInvitationsResponseDataItemStatus value,
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
