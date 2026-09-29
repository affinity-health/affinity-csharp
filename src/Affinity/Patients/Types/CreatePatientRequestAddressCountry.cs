using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreatePatientRequestAddressCountry.CreatePatientRequestAddressCountrySerializer)
)]
[Serializable]
public readonly record struct CreatePatientRequestAddressCountry : IStringEnum
{
    public static readonly CreatePatientRequestAddressCountry Us = new(Values.Us);

    public CreatePatientRequestAddressCountry(string value)
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
    public static CreatePatientRequestAddressCountry FromCustom(string value)
    {
        return new CreatePatientRequestAddressCountry(value);
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

    public static bool operator ==(CreatePatientRequestAddressCountry value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreatePatientRequestAddressCountry value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreatePatientRequestAddressCountry value) => value.Value;

    public static explicit operator CreatePatientRequestAddressCountry(string value) => new(value);

    internal class CreatePatientRequestAddressCountrySerializer
        : JsonConverter<CreatePatientRequestAddressCountry>
    {
        public override CreatePatientRequestAddressCountry Read(
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
            return new CreatePatientRequestAddressCountry(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePatientRequestAddressCountry value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePatientRequestAddressCountry ReadAsPropertyName(
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
            return new CreatePatientRequestAddressCountry(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePatientRequestAddressCountry value,
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
        public const string Us = "US";
    }
}
