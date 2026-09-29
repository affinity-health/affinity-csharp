using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(DeletePatientResponseObject.DeletePatientResponseObjectSerializer))]
[Serializable]
public readonly record struct DeletePatientResponseObject : IStringEnum
{
    public static readonly DeletePatientResponseObject Patient = new(Values.Patient);

    public DeletePatientResponseObject(string value)
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
    public static DeletePatientResponseObject FromCustom(string value)
    {
        return new DeletePatientResponseObject(value);
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

    public static bool operator ==(DeletePatientResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DeletePatientResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DeletePatientResponseObject value) => value.Value;

    public static explicit operator DeletePatientResponseObject(string value) => new(value);

    internal class DeletePatientResponseObjectSerializer
        : JsonConverter<DeletePatientResponseObject>
    {
        public override DeletePatientResponseObject Read(
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
            return new DeletePatientResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DeletePatientResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DeletePatientResponseObject ReadAsPropertyName(
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
            return new DeletePatientResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DeletePatientResponseObject value,
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
