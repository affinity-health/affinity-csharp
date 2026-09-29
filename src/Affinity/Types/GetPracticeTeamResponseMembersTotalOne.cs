using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetPracticeTeamResponseMembersTotalOne.GetPracticeTeamResponseMembersTotalOneSerializer)
)]
[Serializable]
public readonly record struct GetPracticeTeamResponseMembersTotalOne : IStringEnum
{
    public static readonly GetPracticeTeamResponseMembersTotalOne Infinity = new(Values.Infinity);

    public static readonly GetPracticeTeamResponseMembersTotalOne NaN = new(Values.NaN);

    public GetPracticeTeamResponseMembersTotalOne(string value)
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
    public static GetPracticeTeamResponseMembersTotalOne FromCustom(string value)
    {
        return new GetPracticeTeamResponseMembersTotalOne(value);
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

    public static bool operator ==(GetPracticeTeamResponseMembersTotalOne value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetPracticeTeamResponseMembersTotalOne value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetPracticeTeamResponseMembersTotalOne value) =>
        value.Value;

    public static explicit operator GetPracticeTeamResponseMembersTotalOne(string value) =>
        new(value);

    internal class GetPracticeTeamResponseMembersTotalOneSerializer
        : JsonConverter<GetPracticeTeamResponseMembersTotalOne>
    {
        public override GetPracticeTeamResponseMembersTotalOne Read(
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
            return new GetPracticeTeamResponseMembersTotalOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPracticeTeamResponseMembersTotalOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPracticeTeamResponseMembersTotalOne ReadAsPropertyName(
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
            return new GetPracticeTeamResponseMembersTotalOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPracticeTeamResponseMembersTotalOne value,
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
