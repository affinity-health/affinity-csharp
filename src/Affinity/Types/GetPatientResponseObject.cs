using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(GetPatientResponseObject.GetPatientResponseObjectSerializer))]
[Serializable]
public readonly record struct GetPatientResponseObject : IStringEnum
{
    public static readonly GetPatientResponseObject Patient = new(Values.Patient);

    public GetPatientResponseObject(string value)
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
    public static GetPatientResponseObject FromCustom(string value)
    {
        return new GetPatientResponseObject(value);
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

    public static bool operator ==(GetPatientResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetPatientResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetPatientResponseObject value) => value.Value;

    public static explicit operator GetPatientResponseObject(string value) => new(value);

    internal class GetPatientResponseObjectSerializer : JsonConverter<GetPatientResponseObject>
    {
        public override GetPatientResponseObject Read(
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
            return new GetPatientResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPatientResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPatientResponseObject ReadAsPropertyName(
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
            return new GetPatientResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPatientResponseObject value,
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
