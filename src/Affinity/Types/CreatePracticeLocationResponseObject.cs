using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreatePracticeLocationResponseObject.CreatePracticeLocationResponseObjectSerializer)
)]
[Serializable]
public readonly record struct CreatePracticeLocationResponseObject : IStringEnum
{
    public static readonly CreatePracticeLocationResponseObject Location = new(Values.Location);

    public CreatePracticeLocationResponseObject(string value)
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
    public static CreatePracticeLocationResponseObject FromCustom(string value)
    {
        return new CreatePracticeLocationResponseObject(value);
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

    public static bool operator ==(CreatePracticeLocationResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreatePracticeLocationResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreatePracticeLocationResponseObject value) =>
        value.Value;

    public static explicit operator CreatePracticeLocationResponseObject(string value) =>
        new(value);

    internal class CreatePracticeLocationResponseObjectSerializer
        : JsonConverter<CreatePracticeLocationResponseObject>
    {
        public override CreatePracticeLocationResponseObject Read(
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
            return new CreatePracticeLocationResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePracticeLocationResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePracticeLocationResponseObject ReadAsPropertyName(
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
            return new CreatePracticeLocationResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePracticeLocationResponseObject value,
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
        public const string Location = "location";
    }
}
