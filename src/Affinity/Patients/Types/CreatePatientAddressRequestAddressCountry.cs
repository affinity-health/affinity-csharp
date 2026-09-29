using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreatePatientAddressRequestAddressCountry.CreatePatientAddressRequestAddressCountrySerializer)
)]
[Serializable]
public readonly record struct CreatePatientAddressRequestAddressCountry : IStringEnum
{
    public static readonly CreatePatientAddressRequestAddressCountry Us = new(Values.Us);

    public CreatePatientAddressRequestAddressCountry(string value)
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
    public static CreatePatientAddressRequestAddressCountry FromCustom(string value)
    {
        return new CreatePatientAddressRequestAddressCountry(value);
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

    public static bool operator ==(
        CreatePatientAddressRequestAddressCountry value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreatePatientAddressRequestAddressCountry value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreatePatientAddressRequestAddressCountry value) =>
        value.Value;

    public static explicit operator CreatePatientAddressRequestAddressCountry(string value) =>
        new(value);

    internal class CreatePatientAddressRequestAddressCountrySerializer
        : JsonConverter<CreatePatientAddressRequestAddressCountry>
    {
        public override CreatePatientAddressRequestAddressCountry Read(
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
            return new CreatePatientAddressRequestAddressCountry(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePatientAddressRequestAddressCountry value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePatientAddressRequestAddressCountry ReadAsPropertyName(
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
            return new CreatePatientAddressRequestAddressCountry(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePatientAddressRequestAddressCountry value,
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
