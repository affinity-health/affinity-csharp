using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetApiAccessResponseServiceAccountApiVersion.GetApiAccessResponseServiceAccountApiVersionSerializer)
)]
[Serializable]
public readonly record struct GetApiAccessResponseServiceAccountApiVersion : IStringEnum
{
    public static readonly GetApiAccessResponseServiceAccountApiVersion TwoThousandTwentySix0928 =
        new(Values.TwoThousandTwentySix0928);

    public GetApiAccessResponseServiceAccountApiVersion(string value)
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
    public static GetApiAccessResponseServiceAccountApiVersion FromCustom(string value)
    {
        return new GetApiAccessResponseServiceAccountApiVersion(value);
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
        GetApiAccessResponseServiceAccountApiVersion value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetApiAccessResponseServiceAccountApiVersion value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GetApiAccessResponseServiceAccountApiVersion value) =>
        value.Value;

    public static explicit operator GetApiAccessResponseServiceAccountApiVersion(string value) =>
        new(value);

    internal class GetApiAccessResponseServiceAccountApiVersionSerializer
        : JsonConverter<GetApiAccessResponseServiceAccountApiVersion>
    {
        public override GetApiAccessResponseServiceAccountApiVersion Read(
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
            return new GetApiAccessResponseServiceAccountApiVersion(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetApiAccessResponseServiceAccountApiVersion value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetApiAccessResponseServiceAccountApiVersion ReadAsPropertyName(
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
            return new GetApiAccessResponseServiceAccountApiVersion(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetApiAccessResponseServiceAccountApiVersion value,
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
