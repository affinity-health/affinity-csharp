using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreatePlatformPracticeApiKeyResponseApiKeyStatus.CreatePlatformPracticeApiKeyResponseApiKeyStatusSerializer)
)]
[Serializable]
public readonly record struct CreatePlatformPracticeApiKeyResponseApiKeyStatus : IStringEnum
{
    public static readonly CreatePlatformPracticeApiKeyResponseApiKeyStatus Active = new(
        Values.Active
    );

    public static readonly CreatePlatformPracticeApiKeyResponseApiKeyStatus Expired = new(
        Values.Expired
    );

    public static readonly CreatePlatformPracticeApiKeyResponseApiKeyStatus Revoked = new(
        Values.Revoked
    );

    public CreatePlatformPracticeApiKeyResponseApiKeyStatus(string value)
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
    public static CreatePlatformPracticeApiKeyResponseApiKeyStatus FromCustom(string value)
    {
        return new CreatePlatformPracticeApiKeyResponseApiKeyStatus(value);
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
        CreatePlatformPracticeApiKeyResponseApiKeyStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreatePlatformPracticeApiKeyResponseApiKeyStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreatePlatformPracticeApiKeyResponseApiKeyStatus value
    ) => value.Value;

    public static explicit operator CreatePlatformPracticeApiKeyResponseApiKeyStatus(
        string value
    ) => new(value);

    internal class CreatePlatformPracticeApiKeyResponseApiKeyStatusSerializer
        : JsonConverter<CreatePlatformPracticeApiKeyResponseApiKeyStatus>
    {
        public override CreatePlatformPracticeApiKeyResponseApiKeyStatus Read(
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
            return new CreatePlatformPracticeApiKeyResponseApiKeyStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePlatformPracticeApiKeyResponseApiKeyStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePlatformPracticeApiKeyResponseApiKeyStatus ReadAsPropertyName(
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
            return new CreatePlatformPracticeApiKeyResponseApiKeyStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePlatformPracticeApiKeyResponseApiKeyStatus value,
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

        public const string Expired = "expired";

        public const string Revoked = "revoked";
    }
}
