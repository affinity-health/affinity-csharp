using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(GetPracticeTeamResponseObject.GetPracticeTeamResponseObjectSerializer))]
[Serializable]
public readonly record struct GetPracticeTeamResponseObject : IStringEnum
{
    public static readonly GetPracticeTeamResponseObject Team = new(Values.Team);

    public GetPracticeTeamResponseObject(string value)
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
    public static GetPracticeTeamResponseObject FromCustom(string value)
    {
        return new GetPracticeTeamResponseObject(value);
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

    public static bool operator ==(GetPracticeTeamResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetPracticeTeamResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetPracticeTeamResponseObject value) => value.Value;

    public static explicit operator GetPracticeTeamResponseObject(string value) => new(value);

    internal class GetPracticeTeamResponseObjectSerializer
        : JsonConverter<GetPracticeTeamResponseObject>
    {
        public override GetPracticeTeamResponseObject Read(
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
            return new GetPracticeTeamResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPracticeTeamResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPracticeTeamResponseObject ReadAsPropertyName(
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
            return new GetPracticeTeamResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPracticeTeamResponseObject value,
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
        public const string Team = "team";
    }
}
