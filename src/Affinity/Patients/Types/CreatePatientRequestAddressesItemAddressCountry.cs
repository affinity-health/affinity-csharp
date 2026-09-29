using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreatePatientRequestAddressesItemAddressCountry.CreatePatientRequestAddressesItemAddressCountrySerializer)
)]
[Serializable]
public readonly record struct CreatePatientRequestAddressesItemAddressCountry : IStringEnum
{
    public static readonly CreatePatientRequestAddressesItemAddressCountry Us = new(Values.Us);

    public CreatePatientRequestAddressesItemAddressCountry(string value)
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
    public static CreatePatientRequestAddressesItemAddressCountry FromCustom(string value)
    {
        return new CreatePatientRequestAddressesItemAddressCountry(value);
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
        CreatePatientRequestAddressesItemAddressCountry value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreatePatientRequestAddressesItemAddressCountry value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreatePatientRequestAddressesItemAddressCountry value) =>
        value.Value;

    public static explicit operator CreatePatientRequestAddressesItemAddressCountry(string value) =>
        new(value);

    internal class CreatePatientRequestAddressesItemAddressCountrySerializer
        : JsonConverter<CreatePatientRequestAddressesItemAddressCountry>
    {
        public override CreatePatientRequestAddressesItemAddressCountry Read(
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
            return new CreatePatientRequestAddressesItemAddressCountry(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePatientRequestAddressesItemAddressCountry value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePatientRequestAddressesItemAddressCountry ReadAsPropertyName(
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
            return new CreatePatientRequestAddressesItemAddressCountry(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePatientRequestAddressesItemAddressCountry value,
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
