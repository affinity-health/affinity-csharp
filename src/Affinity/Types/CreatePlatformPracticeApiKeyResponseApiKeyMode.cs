using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreatePlatformPracticeApiKeyResponseApiKeyMode.CreatePlatformPracticeApiKeyResponseApiKeyModeSerializer)
)]
[Serializable]
public readonly record struct CreatePlatformPracticeApiKeyResponseApiKeyMode : IStringEnum
{
    public static readonly CreatePlatformPracticeApiKeyResponseApiKeyMode Live = new(Values.Live);

    public static readonly CreatePlatformPracticeApiKeyResponseApiKeyMode Test = new(Values.Test);

    public CreatePlatformPracticeApiKeyResponseApiKeyMode(string value)
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
    public static CreatePlatformPracticeApiKeyResponseApiKeyMode FromCustom(string value)
    {
        return new CreatePlatformPracticeApiKeyResponseApiKeyMode(value);
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
        CreatePlatformPracticeApiKeyResponseApiKeyMode value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreatePlatformPracticeApiKeyResponseApiKeyMode value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreatePlatformPracticeApiKeyResponseApiKeyMode value) =>
        value.Value;

    public static explicit operator CreatePlatformPracticeApiKeyResponseApiKeyMode(string value) =>
        new(value);

    internal class CreatePlatformPracticeApiKeyResponseApiKeyModeSerializer
        : JsonConverter<CreatePlatformPracticeApiKeyResponseApiKeyMode>
    {
        public override CreatePlatformPracticeApiKeyResponseApiKeyMode Read(
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
            return new CreatePlatformPracticeApiKeyResponseApiKeyMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePlatformPracticeApiKeyResponseApiKeyMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePlatformPracticeApiKeyResponseApiKeyMode ReadAsPropertyName(
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
            return new CreatePlatformPracticeApiKeyResponseApiKeyMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePlatformPracticeApiKeyResponseApiKeyMode value,
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
        public const string Live = "live";

        public const string Test = "test";
    }
}
