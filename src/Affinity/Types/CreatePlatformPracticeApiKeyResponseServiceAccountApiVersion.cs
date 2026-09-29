using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion.CreatePlatformPracticeApiKeyResponseServiceAccountApiVersionSerializer)
)]
[Serializable]
public readonly record struct CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion
    : IStringEnum
{
    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion TwoThousandTwentySix0928 =
        new(Values.TwoThousandTwentySix0928);

    public CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion(string value)
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
    public static CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion FromCustom(
        string value
    )
    {
        return new CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion(value);
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
        CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion value
    ) => value.Value;

    public static explicit operator CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion(
        string value
    ) => new(value);

    internal class CreatePlatformPracticeApiKeyResponseServiceAccountApiVersionSerializer
        : JsonConverter<CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion>
    {
        public override CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion Read(
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
            return new CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion ReadAsPropertyName(
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
            return new CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePlatformPracticeApiKeyResponseServiceAccountApiVersion value,
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
        public const string TwoThousandTwentySix0928 = "2026-09-28";
    }
}
