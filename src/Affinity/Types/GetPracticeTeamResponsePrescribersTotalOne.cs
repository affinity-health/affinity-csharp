using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetPracticeTeamResponsePrescribersTotalOne.GetPracticeTeamResponsePrescribersTotalOneSerializer)
)]
[Serializable]
public readonly record struct GetPracticeTeamResponsePrescribersTotalOne : IStringEnum
{
    public static readonly GetPracticeTeamResponsePrescribersTotalOne Infinity = new(
        Values.Infinity
    );

    public static readonly GetPracticeTeamResponsePrescribersTotalOne NaN = new(Values.NaN);

    public GetPracticeTeamResponsePrescribersTotalOne(string value)
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
    public static GetPracticeTeamResponsePrescribersTotalOne FromCustom(string value)
    {
        return new GetPracticeTeamResponsePrescribersTotalOne(value);
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
        GetPracticeTeamResponsePrescribersTotalOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetPracticeTeamResponsePrescribersTotalOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GetPracticeTeamResponsePrescribersTotalOne value) =>
        value.Value;

    public static explicit operator GetPracticeTeamResponsePrescribersTotalOne(string value) =>
        new(value);

    internal class GetPracticeTeamResponsePrescribersTotalOneSerializer
        : JsonConverter<GetPracticeTeamResponsePrescribersTotalOne>
    {
        public override GetPracticeTeamResponsePrescribersTotalOne Read(
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
            return new GetPracticeTeamResponsePrescribersTotalOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPracticeTeamResponsePrescribersTotalOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPracticeTeamResponsePrescribersTotalOne ReadAsPropertyName(
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
            return new GetPracticeTeamResponsePrescribersTotalOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPracticeTeamResponsePrescribersTotalOne value,
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
