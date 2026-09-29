using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetPracticeTeamResponseMembersDisabledOne.GetPracticeTeamResponseMembersDisabledOneSerializer)
)]
[Serializable]
public readonly record struct GetPracticeTeamResponseMembersDisabledOne : IStringEnum
{
    public static readonly GetPracticeTeamResponseMembersDisabledOne Infinity = new(
        Values.Infinity
    );

    public static readonly GetPracticeTeamResponseMembersDisabledOne NaN = new(Values.NaN);

    public GetPracticeTeamResponseMembersDisabledOne(string value)
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
    public static GetPracticeTeamResponseMembersDisabledOne FromCustom(string value)
    {
        return new GetPracticeTeamResponseMembersDisabledOne(value);
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
        GetPracticeTeamResponseMembersDisabledOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetPracticeTeamResponseMembersDisabledOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GetPracticeTeamResponseMembersDisabledOne value) =>
        value.Value;

    public static explicit operator GetPracticeTeamResponseMembersDisabledOne(string value) =>
        new(value);

    internal class GetPracticeTeamResponseMembersDisabledOneSerializer
        : JsonConverter<GetPracticeTeamResponseMembersDisabledOne>
    {
        public override GetPracticeTeamResponseMembersDisabledOne Read(
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
            return new GetPracticeTeamResponseMembersDisabledOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPracticeTeamResponseMembersDisabledOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPracticeTeamResponseMembersDisabledOne ReadAsPropertyName(
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
            return new GetPracticeTeamResponseMembersDisabledOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPracticeTeamResponseMembersDisabledOne value,
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
