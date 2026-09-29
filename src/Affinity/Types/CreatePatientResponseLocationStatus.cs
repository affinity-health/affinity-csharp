using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreatePatientResponseLocationStatus.CreatePatientResponseLocationStatusSerializer)
)]
[Serializable]
public readonly record struct CreatePatientResponseLocationStatus : IStringEnum
{
    public static readonly CreatePatientResponseLocationStatus Active = new(Values.Active);

    public static readonly CreatePatientResponseLocationStatus Archived = new(Values.Archived);

    public CreatePatientResponseLocationStatus(string value)
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
    public static CreatePatientResponseLocationStatus FromCustom(string value)
    {
        return new CreatePatientResponseLocationStatus(value);
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

    public static bool operator ==(CreatePatientResponseLocationStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreatePatientResponseLocationStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreatePatientResponseLocationStatus value) =>
        value.Value;

    public static explicit operator CreatePatientResponseLocationStatus(string value) => new(value);

    internal class CreatePatientResponseLocationStatusSerializer
        : JsonConverter<CreatePatientResponseLocationStatus>
    {
        public override CreatePatientResponseLocationStatus Read(
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
            return new CreatePatientResponseLocationStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePatientResponseLocationStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePatientResponseLocationStatus ReadAsPropertyName(
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
            return new CreatePatientResponseLocationStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePatientResponseLocationStatus value,
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
