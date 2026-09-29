using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType.CreatePlatformPracticeApiKeyResponseServiceAccountSubjectTypeSerializer)
)]
[Serializable]
public readonly record struct CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType
    : IStringEnum
{
    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType Practice =
        new(Values.Practice);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType InternalService =
        new(Values.InternalService);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType Pharmacy =
        new(Values.Pharmacy);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType Platform =
        new(Values.Platform);

    public static readonly CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType User = new(
        Values.User
    );

    public CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType(string value)
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
    public static CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType FromCustom(
        string value
    )
    {
        return new CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType(value);
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
        CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType value
    ) => value.Value;

    public static explicit operator CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType(
        string value
    ) => new(value);

    internal class CreatePlatformPracticeApiKeyResponseServiceAccountSubjectTypeSerializer
        : JsonConverter<CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType>
    {
        public override CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType Read(
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
            return new CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType ReadAsPropertyName(
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
            return new CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePlatformPracticeApiKeyResponseServiceAccountSubjectType value,
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

        public const string InternalService = "internal_service";

        public const string Pharmacy = "pharmacy";

        public const string Platform = "platform";

        public const string User = "user";
    }
}
