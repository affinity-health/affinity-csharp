using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetPracticeTeamResponseInvitationsExpiredOne.GetPracticeTeamResponseInvitationsExpiredOneSerializer)
)]
[Serializable]
public readonly record struct GetPracticeTeamResponseInvitationsExpiredOne : IStringEnum
{
    public static readonly GetPracticeTeamResponseInvitationsExpiredOne Infinity = new(
        Values.Infinity
    );

    public static readonly GetPracticeTeamResponseInvitationsExpiredOne NaN = new(Values.NaN);

    public GetPracticeTeamResponseInvitationsExpiredOne(string value)
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
    public static GetPracticeTeamResponseInvitationsExpiredOne FromCustom(string value)
    {
        return new GetPracticeTeamResponseInvitationsExpiredOne(value);
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
        GetPracticeTeamResponseInvitationsExpiredOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetPracticeTeamResponseInvitationsExpiredOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GetPracticeTeamResponseInvitationsExpiredOne value) =>
        value.Value;

    public static explicit operator GetPracticeTeamResponseInvitationsExpiredOne(string value) =>
        new(value);

    internal class GetPracticeTeamResponseInvitationsExpiredOneSerializer
        : JsonConverter<GetPracticeTeamResponseInvitationsExpiredOne>
    {
        public override GetPracticeTeamResponseInvitationsExpiredOne Read(
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
            return new GetPracticeTeamResponseInvitationsExpiredOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPracticeTeamResponseInvitationsExpiredOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPracticeTeamResponseInvitationsExpiredOne ReadAsPropertyName(
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
            return new GetPracticeTeamResponseInvitationsExpiredOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPracticeTeamResponseInvitationsExpiredOne value,
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
        public const string Infinity = "Infinity";

        public const string NaN = "NaN";
    }
}
