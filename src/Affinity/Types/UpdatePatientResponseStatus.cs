using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(UpdatePatientResponseStatus.UpdatePatientResponseStatusSerializer))]
[Serializable]
public readonly record struct UpdatePatientResponseStatus : IStringEnum
{
    public static readonly UpdatePatientResponseStatus Active = new(Values.Active);

    public static readonly UpdatePatientResponseStatus Inactive = new(Values.Inactive);

    public UpdatePatientResponseStatus(string value)
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
    public static UpdatePatientResponseStatus FromCustom(string value)
    {
        return new UpdatePatientResponseStatus(value);
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

    public static bool operator ==(UpdatePatientResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdatePatientResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdatePatientResponseStatus value) => value.Value;

    public static explicit operator UpdatePatientResponseStatus(string value) => new(value);

    internal class UpdatePatientResponseStatusSerializer
        : JsonConverter<UpdatePatientResponseStatus>
    {
        public override UpdatePatientResponseStatus Read(
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
            return new UpdatePatientResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdatePatientResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdatePatientResponseStatus ReadAsPropertyName(
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
            return new UpdatePatientResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdatePatientResponseStatus value,
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

        public const string Inactive = "inactive";
    }
}
