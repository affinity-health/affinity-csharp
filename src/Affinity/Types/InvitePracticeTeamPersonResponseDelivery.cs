using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(InvitePracticeTeamPersonResponseDelivery.InvitePracticeTeamPersonResponseDeliverySerializer)
)]
[Serializable]
public readonly record struct InvitePracticeTeamPersonResponseDelivery : IStringEnum
{
    public static readonly InvitePracticeTeamPersonResponseDelivery Sent = new(Values.Sent);

    public static readonly InvitePracticeTeamPersonResponseDelivery AlreadyAccepted = new(
        Values.AlreadyAccepted
    );

    public InvitePracticeTeamPersonResponseDelivery(string value)
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
    public static InvitePracticeTeamPersonResponseDelivery FromCustom(string value)
    {
        return new InvitePracticeTeamPersonResponseDelivery(value);
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
        InvitePracticeTeamPersonResponseDelivery value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        InvitePracticeTeamPersonResponseDelivery value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(InvitePracticeTeamPersonResponseDelivery value) =>
        value.Value;

    public static explicit operator InvitePracticeTeamPersonResponseDelivery(string value) =>
        new(value);

    internal class InvitePracticeTeamPersonResponseDeliverySerializer
        : JsonConverter<InvitePracticeTeamPersonResponseDelivery>
    {
        public override InvitePracticeTeamPersonResponseDelivery Read(
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
            return new InvitePracticeTeamPersonResponseDelivery(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InvitePracticeTeamPersonResponseDelivery value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InvitePracticeTeamPersonResponseDelivery ReadAsPropertyName(
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
            return new InvitePracticeTeamPersonResponseDelivery(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InvitePracticeTeamPersonResponseDelivery value,
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
        public const string Sent = "sent";

        public const string AlreadyAccepted = "already_accepted";
    }
}
