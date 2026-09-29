using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(UpdatePatientRequestProgramsItemStatus.UpdatePatientRequestProgramsItemStatusSerializer)
)]
[Serializable]
public readonly record struct UpdatePatientRequestProgramsItemStatus : IStringEnum
{
    public static readonly UpdatePatientRequestProgramsItemStatus Active = new(Values.Active);

    public static readonly UpdatePatientRequestProgramsItemStatus Completed = new(Values.Completed);

    public static readonly UpdatePatientRequestProgramsItemStatus Paused = new(Values.Paused);

    public UpdatePatientRequestProgramsItemStatus(string value)
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
    public static UpdatePatientRequestProgramsItemStatus FromCustom(string value)
    {
        return new UpdatePatientRequestProgramsItemStatus(value);
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

    public static bool operator ==(UpdatePatientRequestProgramsItemStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdatePatientRequestProgramsItemStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdatePatientRequestProgramsItemStatus value) =>
        value.Value;

    public static explicit operator UpdatePatientRequestProgramsItemStatus(string value) =>
        new(value);

    internal class UpdatePatientRequestProgramsItemStatusSerializer
        : JsonConverter<UpdatePatientRequestProgramsItemStatus>
    {
        public override UpdatePatientRequestProgramsItemStatus Read(
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
            return new UpdatePatientRequestProgramsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdatePatientRequestProgramsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdatePatientRequestProgramsItemStatus ReadAsPropertyName(
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
            return new UpdatePatientRequestProgramsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdatePatientRequestProgramsItemStatus value,
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
