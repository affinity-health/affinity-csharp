using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ArchivePracticeLocationResponseStatus.ArchivePracticeLocationResponseStatusSerializer)
)]
[Serializable]
public readonly record struct ArchivePracticeLocationResponseStatus : IStringEnum
{
    public static readonly ArchivePracticeLocationResponseStatus Active = new(Values.Active);

    public static readonly ArchivePracticeLocationResponseStatus Archived = new(Values.Archived);

    public ArchivePracticeLocationResponseStatus(string value)
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
    public static ArchivePracticeLocationResponseStatus FromCustom(string value)
    {
        return new ArchivePracticeLocationResponseStatus(value);
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

    public static bool operator ==(ArchivePracticeLocationResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ArchivePracticeLocationResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ArchivePracticeLocationResponseStatus value) =>
        value.Value;

    public static explicit operator ArchivePracticeLocationResponseStatus(string value) =>
        new(value);

    internal class ArchivePracticeLocationResponseStatusSerializer
        : JsonConverter<ArchivePracticeLocationResponseStatus>
    {
        public override ArchivePracticeLocationResponseStatus Read(
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
            return new ArchivePracticeLocationResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ArchivePracticeLocationResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ArchivePracticeLocationResponseStatus ReadAsPropertyName(
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
            return new ArchivePracticeLocationResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ArchivePracticeLocationResponseStatus value,
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
