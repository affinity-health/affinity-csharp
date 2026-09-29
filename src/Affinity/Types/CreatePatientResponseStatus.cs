using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(CreatePatientResponseStatus.CreatePatientResponseStatusSerializer))]
[Serializable]
public readonly record struct CreatePatientResponseStatus : IStringEnum
{
    public static readonly CreatePatientResponseStatus Active = new(Values.Active);

    public static readonly CreatePatientResponseStatus Inactive = new(Values.Inactive);

    public CreatePatientResponseStatus(string value)
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
    public static CreatePatientResponseStatus FromCustom(string value)
    {
        return new CreatePatientResponseStatus(value);
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

    public static bool operator ==(CreatePatientResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreatePatientResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreatePatientResponseStatus value) => value.Value;

    public static explicit operator CreatePatientResponseStatus(string value) => new(value);

    internal class CreatePatientResponseStatusSerializer
        : JsonConverter<CreatePatientResponseStatus>
    {
        public override CreatePatientResponseStatus Read(
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
            return new CreatePatientResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePatientResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePatientResponseStatus ReadAsPropertyName(
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
            return new CreatePatientResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePatientResponseStatus value,
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
