using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Team;

[JsonConverter(typeof(ListInvitationsRequestStatus.ListInvitationsRequestStatusSerializer))]
[Serializable]
public readonly record struct ListInvitationsRequestStatus : IStringEnum
{
    public static readonly ListInvitationsRequestStatus Accepted = new(Values.Accepted);

    public static readonly ListInvitationsRequestStatus Declined = new(Values.Declined);

    public static readonly ListInvitationsRequestStatus Pending = new(Values.Pending);

    public static readonly ListInvitationsRequestStatus Expired = new(Values.Expired);

    public static readonly ListInvitationsRequestStatus Revoked = new(Values.Revoked);

    public ListInvitationsRequestStatus(string value)
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
    public static ListInvitationsRequestStatus FromCustom(string value)
    {
        return new ListInvitationsRequestStatus(value);
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

    public static bool operator ==(ListInvitationsRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListInvitationsRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListInvitationsRequestStatus value) => value.Value;

    public static explicit operator ListInvitationsRequestStatus(string value) => new(value);

    internal class ListInvitationsRequestStatusSerializer
        : JsonConverter<ListInvitationsRequestStatus>
    {
        public override ListInvitationsRequestStatus Read(
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
            return new ListInvitationsRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListInvitationsRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListInvitationsRequestStatus ReadAsPropertyName(
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
            return new ListInvitationsRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListInvitationsRequestStatus value,
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
