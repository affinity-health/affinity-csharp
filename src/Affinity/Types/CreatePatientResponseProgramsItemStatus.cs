using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreatePatientResponseProgramsItemStatus.CreatePatientResponseProgramsItemStatusSerializer)
)]
[Serializable]
public readonly record struct CreatePatientResponseProgramsItemStatus : IStringEnum
{
    public static readonly CreatePatientResponseProgramsItemStatus Active = new(Values.Active);

    public static readonly CreatePatientResponseProgramsItemStatus Completed = new(
        Values.Completed
    );

    public static readonly CreatePatientResponseProgramsItemStatus Paused = new(Values.Paused);

    public CreatePatientResponseProgramsItemStatus(string value)
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
    public static CreatePatientResponseProgramsItemStatus FromCustom(string value)
    {
        return new CreatePatientResponseProgramsItemStatus(value);
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

    public static bool operator ==(CreatePatientResponseProgramsItemStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreatePatientResponseProgramsItemStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreatePatientResponseProgramsItemStatus value) =>
        value.Value;

    public static explicit operator CreatePatientResponseProgramsItemStatus(string value) =>
        new(value);

    internal class CreatePatientResponseProgramsItemStatusSerializer
        : JsonConverter<CreatePatientResponseProgramsItemStatus>
    {
        public override CreatePatientResponseProgramsItemStatus Read(
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
            return new CreatePatientResponseProgramsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePatientResponseProgramsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePatientResponseProgramsItemStatus ReadAsPropertyName(
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
            return new CreatePatientResponseProgramsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePatientResponseProgramsItemStatus value,
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
