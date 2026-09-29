using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetApiAccessResponseServiceAccountObject.GetApiAccessResponseServiceAccountObjectSerializer)
)]
[Serializable]
public readonly record struct GetApiAccessResponseServiceAccountObject : IStringEnum
{
    public static readonly GetApiAccessResponseServiceAccountObject ServiceAccount = new(
        Values.ServiceAccount
    );

    public GetApiAccessResponseServiceAccountObject(string value)
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
    public static GetApiAccessResponseServiceAccountObject FromCustom(string value)
    {
        return new GetApiAccessResponseServiceAccountObject(value);
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
        GetApiAccessResponseServiceAccountObject value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetApiAccessResponseServiceAccountObject value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GetApiAccessResponseServiceAccountObject value) =>
        value.Value;

    public static explicit operator GetApiAccessResponseServiceAccountObject(string value) =>
        new(value);

    internal class GetApiAccessResponseServiceAccountObjectSerializer
        : JsonConverter<GetApiAccessResponseServiceAccountObject>
    {
        public override GetApiAccessResponseServiceAccountObject Read(
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
            return new GetApiAccessResponseServiceAccountObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetApiAccessResponseServiceAccountObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetApiAccessResponseServiceAccountObject ReadAsPropertyName(
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
            return new GetApiAccessResponseServiceAccountObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetApiAccessResponseServiceAccountObject value,
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
        public const string ServiceAccount = "service_account";
    }
}
