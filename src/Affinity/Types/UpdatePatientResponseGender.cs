using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(UpdatePatientResponseGender.UpdatePatientResponseGenderSerializer))]
[Serializable]
public readonly record struct UpdatePatientResponseGender : IStringEnum
{
    public static readonly UpdatePatientResponseGender F = new(Values.F);

    public static readonly UpdatePatientResponseGender M = new(Values.M);

    public static readonly UpdatePatientResponseGender O = new(Values.O);

    public static readonly UpdatePatientResponseGender U = new(Values.U);

    public UpdatePatientResponseGender(string value)
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
    public static UpdatePatientResponseGender FromCustom(string value)
    {
        return new UpdatePatientResponseGender(value);
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

    public static bool operator ==(UpdatePatientResponseGender value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdatePatientResponseGender value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdatePatientResponseGender value) => value.Value;

    public static explicit operator UpdatePatientResponseGender(string value) => new(value);

    internal class UpdatePatientResponseGenderSerializer
        : JsonConverter<UpdatePatientResponseGender>
    {
        public override UpdatePatientResponseGender Read(
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
            return new UpdatePatientResponseGender(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdatePatientResponseGender value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdatePatientResponseGender ReadAsPropertyName(
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
            return new UpdatePatientResponseGender(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdatePatientResponseGender value,
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
        public const string F = "f";

        public const string M = "m";

        public const string O = "o";

        public const string U = "u";
    }
}
