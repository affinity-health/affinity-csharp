using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(UpdatePatientRequestAddressCountry.UpdatePatientRequestAddressCountrySerializer)
)]
[Serializable]
public readonly record struct UpdatePatientRequestAddressCountry : IStringEnum
{
    public static readonly UpdatePatientRequestAddressCountry Us = new(Values.Us);

    public UpdatePatientRequestAddressCountry(string value)
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
    public static UpdatePatientRequestAddressCountry FromCustom(string value)
    {
        return new UpdatePatientRequestAddressCountry(value);
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

    public static bool operator ==(UpdatePatientRequestAddressCountry value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdatePatientRequestAddressCountry value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdatePatientRequestAddressCountry value) => value.Value;

    public static explicit operator UpdatePatientRequestAddressCountry(string value) => new(value);

    internal class UpdatePatientRequestAddressCountrySerializer
        : JsonConverter<UpdatePatientRequestAddressCountry>
    {
        public override UpdatePatientRequestAddressCountry Read(
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
            return new UpdatePatientRequestAddressCountry(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdatePatientRequestAddressCountry value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdatePatientRequestAddressCountry ReadAsPropertyName(
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
            return new UpdatePatientRequestAddressCountry(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdatePatientRequestAddressCountry value,
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
