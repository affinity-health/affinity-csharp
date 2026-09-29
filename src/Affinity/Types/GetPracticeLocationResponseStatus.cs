using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetPracticeLocationResponseStatus.GetPracticeLocationResponseStatusSerializer)
)]
[Serializable]
public readonly record struct GetPracticeLocationResponseStatus : IStringEnum
{
    public static readonly GetPracticeLocationResponseStatus Active = new(Values.Active);

    public static readonly GetPracticeLocationResponseStatus Archived = new(Values.Archived);

    public GetPracticeLocationResponseStatus(string value)
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
    public static GetPracticeLocationResponseStatus FromCustom(string value)
    {
        return new GetPracticeLocationResponseStatus(value);
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

    public static bool operator ==(GetPracticeLocationResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetPracticeLocationResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetPracticeLocationResponseStatus value) => value.Value;

    public static explicit operator GetPracticeLocationResponseStatus(string value) => new(value);

    internal class GetPracticeLocationResponseStatusSerializer
        : JsonConverter<GetPracticeLocationResponseStatus>
    {
        public override GetPracticeLocationResponseStatus Read(
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
            return new GetPracticeLocationResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPracticeLocationResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPracticeLocationResponseStatus ReadAsPropertyName(
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
            return new GetPracticeLocationResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPracticeLocationResponseStatus value,
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
        public const string Active = "active";

        public const string Archived = "archived";
    }
}
