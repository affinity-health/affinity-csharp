using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ResendPracticeTeamInvitationResponseDelivery.ResendPracticeTeamInvitationResponseDeliverySerializer)
)]
[Serializable]
public readonly record struct ResendPracticeTeamInvitationResponseDelivery : IStringEnum
{
    public static readonly ResendPracticeTeamInvitationResponseDelivery Sent = new(Values.Sent);

    public ResendPracticeTeamInvitationResponseDelivery(string value)
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
    public static ResendPracticeTeamInvitationResponseDelivery FromCustom(string value)
    {
        return new ResendPracticeTeamInvitationResponseDelivery(value);
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
        ResendPracticeTeamInvitationResponseDelivery value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ResendPracticeTeamInvitationResponseDelivery value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ResendPracticeTeamInvitationResponseDelivery value) =>
        value.Value;

    public static explicit operator ResendPracticeTeamInvitationResponseDelivery(string value) =>
        new(value);

    internal class ResendPracticeTeamInvitationResponseDeliverySerializer
        : JsonConverter<ResendPracticeTeamInvitationResponseDelivery>
    {
        public override ResendPracticeTeamInvitationResponseDelivery Read(
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
            return new ResendPracticeTeamInvitationResponseDelivery(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResendPracticeTeamInvitationResponseDelivery value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResendPracticeTeamInvitationResponseDelivery ReadAsPropertyName(
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
            return new ResendPracticeTeamInvitationResponseDelivery(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResendPracticeTeamInvitationResponseDelivery value,
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
    }
}
