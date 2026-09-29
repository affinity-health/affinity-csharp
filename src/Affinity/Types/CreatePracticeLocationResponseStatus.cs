using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreatePracticeLocationResponseStatus.CreatePracticeLocationResponseStatusSerializer)
)]
[Serializable]
public readonly record struct CreatePracticeLocationResponseStatus : IStringEnum
{
    public static readonly CreatePracticeLocationResponseStatus Active = new(Values.Active);

    public static readonly CreatePracticeLocationResponseStatus Archived = new(Values.Archived);

    public CreatePracticeLocationResponseStatus(string value)
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
    public static CreatePracticeLocationResponseStatus FromCustom(string value)
    {
        return new CreatePracticeLocationResponseStatus(value);
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

    public static bool operator ==(CreatePracticeLocationResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreatePracticeLocationResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreatePracticeLocationResponseStatus value) =>
        value.Value;

    public static explicit operator CreatePracticeLocationResponseStatus(string value) =>
        new(value);

    internal class CreatePracticeLocationResponseStatusSerializer
        : JsonConverter<CreatePracticeLocationResponseStatus>
    {
        public override CreatePracticeLocationResponseStatus Read(
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
            return new CreatePracticeLocationResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePracticeLocationResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePracticeLocationResponseStatus ReadAsPropertyName(
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
            return new CreatePracticeLocationResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePracticeLocationResponseStatus value,
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
