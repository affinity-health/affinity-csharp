using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(UpdatePatientRequestAddressesItemAddressCountry.UpdatePatientRequestAddressesItemAddressCountrySerializer)
)]
[Serializable]
public readonly record struct UpdatePatientRequestAddressesItemAddressCountry : IStringEnum
{
    public static readonly UpdatePatientRequestAddressesItemAddressCountry Us = new(Values.Us);

    public UpdatePatientRequestAddressesItemAddressCountry(string value)
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
    public static UpdatePatientRequestAddressesItemAddressCountry FromCustom(string value)
    {
        return new UpdatePatientRequestAddressesItemAddressCountry(value);
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
        UpdatePatientRequestAddressesItemAddressCountry value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdatePatientRequestAddressesItemAddressCountry value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UpdatePatientRequestAddressesItemAddressCountry value) =>
        value.Value;

    public static explicit operator UpdatePatientRequestAddressesItemAddressCountry(string value) =>
        new(value);

    internal class UpdatePatientRequestAddressesItemAddressCountrySerializer
        : JsonConverter<UpdatePatientRequestAddressesItemAddressCountry>
    {
        public override UpdatePatientRequestAddressesItemAddressCountry Read(
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
            return new UpdatePatientRequestAddressesItemAddressCountry(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdatePatientRequestAddressesItemAddressCountry value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdatePatientRequestAddressesItemAddressCountry ReadAsPropertyName(
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
            return new UpdatePatientRequestAddressesItemAddressCountry(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdatePatientRequestAddressesItemAddressCountry value,
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
