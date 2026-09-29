using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(UpdatePatientResponseObject.UpdatePatientResponseObjectSerializer))]
[Serializable]
public readonly record struct UpdatePatientResponseObject : IStringEnum
{
    public static readonly UpdatePatientResponseObject Patient = new(Values.Patient);

    public UpdatePatientResponseObject(string value)
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
    public static UpdatePatientResponseObject FromCustom(string value)
    {
        return new UpdatePatientResponseObject(value);
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

    public static bool operator ==(UpdatePatientResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdatePatientResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdatePatientResponseObject value) => value.Value;

    public static explicit operator UpdatePatientResponseObject(string value) => new(value);

    internal class UpdatePatientResponseObjectSerializer
        : JsonConverter<UpdatePatientResponseObject>
    {
        public override UpdatePatientResponseObject Read(
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
            return new UpdatePatientResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdatePatientResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdatePatientResponseObject ReadAsPropertyName(
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
            return new UpdatePatientResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdatePatientResponseObject value,
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
        public const string Patient = "patient";
    }
}
