using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(UpdatePatientResponseLocationStatus.UpdatePatientResponseLocationStatusSerializer)
)]
[Serializable]
public readonly record struct UpdatePatientResponseLocationStatus : IStringEnum
{
    public static readonly UpdatePatientResponseLocationStatus Active = new(Values.Active);

    public static readonly UpdatePatientResponseLocationStatus Archived = new(Values.Archived);

    public UpdatePatientResponseLocationStatus(string value)
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
    public static UpdatePatientResponseLocationStatus FromCustom(string value)
    {
        return new UpdatePatientResponseLocationStatus(value);
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

    public static bool operator ==(UpdatePatientResponseLocationStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdatePatientResponseLocationStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdatePatientResponseLocationStatus value) =>
        value.Value;

    public static explicit operator UpdatePatientResponseLocationStatus(string value) => new(value);

    internal class UpdatePatientResponseLocationStatusSerializer
        : JsonConverter<UpdatePatientResponseLocationStatus>
    {
        public override UpdatePatientResponseLocationStatus Read(
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
            return new UpdatePatientResponseLocationStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdatePatientResponseLocationStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdatePatientResponseLocationStatus ReadAsPropertyName(
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
            return new UpdatePatientResponseLocationStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdatePatientResponseLocationStatus value,
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
