using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Patients;

[JsonConverter(
    typeof(UpdatePatientAddressRequestAddressCountry.UpdatePatientAddressRequestAddressCountrySerializer)
)]
[Serializable]
public readonly record struct UpdatePatientAddressRequestAddressCountry : IStringEnum
{
    public static readonly UpdatePatientAddressRequestAddressCountry Us = new(Values.Us);

    public UpdatePatientAddressRequestAddressCountry(string value)
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
    public static UpdatePatientAddressRequestAddressCountry FromCustom(string value)
    {
        return new UpdatePatientAddressRequestAddressCountry(value);
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
        UpdatePatientAddressRequestAddressCountry value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdatePatientAddressRequestAddressCountry value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UpdatePatientAddressRequestAddressCountry value) =>
        value.Value;

    public static explicit operator UpdatePatientAddressRequestAddressCountry(string value) =>
        new(value);

    internal class UpdatePatientAddressRequestAddressCountrySerializer
        : JsonConverter<UpdatePatientAddressRequestAddressCountry>
    {
        public override UpdatePatientAddressRequestAddressCountry Read(
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
            return new UpdatePatientAddressRequestAddressCountry(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdatePatientAddressRequestAddressCountry value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdatePatientAddressRequestAddressCountry ReadAsPropertyName(
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
            return new UpdatePatientAddressRequestAddressCountry(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdatePatientAddressRequestAddressCountry value,
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
