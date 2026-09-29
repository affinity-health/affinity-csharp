using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(CreatePracticeResponseObject.CreatePracticeResponseObjectSerializer))]
[Serializable]
public readonly record struct CreatePracticeResponseObject : IStringEnum
{
    public static readonly CreatePracticeResponseObject Practice = new(Values.Practice);

    public CreatePracticeResponseObject(string value)
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
    public static CreatePracticeResponseObject FromCustom(string value)
    {
        return new CreatePracticeResponseObject(value);
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

    public static bool operator ==(CreatePracticeResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreatePracticeResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreatePracticeResponseObject value) => value.Value;

    public static explicit operator CreatePracticeResponseObject(string value) => new(value);

    internal class CreatePracticeResponseObjectSerializer
        : JsonConverter<CreatePracticeResponseObject>
    {
        public override CreatePracticeResponseObject Read(
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
            return new CreatePracticeResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePracticeResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePracticeResponseObject ReadAsPropertyName(
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
            return new CreatePracticeResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePracticeResponseObject value,
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
        public const string Practice = "practice";
    }
}
