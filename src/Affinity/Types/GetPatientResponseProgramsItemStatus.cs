using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetPatientResponseProgramsItemStatus.GetPatientResponseProgramsItemStatusSerializer)
)]
[Serializable]
public readonly record struct GetPatientResponseProgramsItemStatus : IStringEnum
{
    public static readonly GetPatientResponseProgramsItemStatus Active = new(Values.Active);

    public static readonly GetPatientResponseProgramsItemStatus Completed = new(Values.Completed);

    public static readonly GetPatientResponseProgramsItemStatus Paused = new(Values.Paused);

    public GetPatientResponseProgramsItemStatus(string value)
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
    public static GetPatientResponseProgramsItemStatus FromCustom(string value)
    {
        return new GetPatientResponseProgramsItemStatus(value);
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

    public static bool operator ==(GetPatientResponseProgramsItemStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetPatientResponseProgramsItemStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetPatientResponseProgramsItemStatus value) =>
        value.Value;

    public static explicit operator GetPatientResponseProgramsItemStatus(string value) =>
        new(value);

    internal class GetPatientResponseProgramsItemStatusSerializer
        : JsonConverter<GetPatientResponseProgramsItemStatus>
    {
        public override GetPatientResponseProgramsItemStatus Read(
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
            return new GetPatientResponseProgramsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPatientResponseProgramsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPatientResponseProgramsItemStatus ReadAsPropertyName(
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
            return new GetPatientResponseProgramsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPatientResponseProgramsItemStatus value,
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

        public const string Completed = "completed";

        public const string Paused = "paused";
    }
}
