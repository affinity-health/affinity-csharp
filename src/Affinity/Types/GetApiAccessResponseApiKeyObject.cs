using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(GetApiAccessResponseApiKeyObject.GetApiAccessResponseApiKeyObjectSerializer))]
[Serializable]
public readonly record struct GetApiAccessResponseApiKeyObject : IStringEnum
{
    public static readonly GetApiAccessResponseApiKeyObject ApiKey = new(Values.ApiKey);

    public GetApiAccessResponseApiKeyObject(string value)
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
    public static GetApiAccessResponseApiKeyObject FromCustom(string value)
    {
        return new GetApiAccessResponseApiKeyObject(value);
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

    public static bool operator ==(GetApiAccessResponseApiKeyObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetApiAccessResponseApiKeyObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetApiAccessResponseApiKeyObject value) => value.Value;

    public static explicit operator GetApiAccessResponseApiKeyObject(string value) => new(value);

    internal class GetApiAccessResponseApiKeyObjectSerializer
        : JsonConverter<GetApiAccessResponseApiKeyObject>
    {
        public override GetApiAccessResponseApiKeyObject Read(
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
            return new GetApiAccessResponseApiKeyObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetApiAccessResponseApiKeyObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetApiAccessResponseApiKeyObject ReadAsPropertyName(
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
            return new GetApiAccessResponseApiKeyObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetApiAccessResponseApiKeyObject value,
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
        public const string ApiKey = "api_key";
    }
}
