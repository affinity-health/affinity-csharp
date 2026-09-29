using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderRequestPatientAddressesItemAddressCountry.PreviewOrderRequestPatientAddressesItemAddressCountrySerializer)
)]
[Serializable]
public readonly record struct PreviewOrderRequestPatientAddressesItemAddressCountry : IStringEnum
{
    public static readonly PreviewOrderRequestPatientAddressesItemAddressCountry Us = new(
        Values.Us
    );

    public PreviewOrderRequestPatientAddressesItemAddressCountry(string value)
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
    public static PreviewOrderRequestPatientAddressesItemAddressCountry FromCustom(string value)
    {
        return new PreviewOrderRequestPatientAddressesItemAddressCountry(value);
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
        PreviewOrderRequestPatientAddressesItemAddressCountry value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderRequestPatientAddressesItemAddressCountry value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PreviewOrderRequestPatientAddressesItemAddressCountry value
    ) => value.Value;

    public static explicit operator PreviewOrderRequestPatientAddressesItemAddressCountry(
        string value
    ) => new(value);

    internal class PreviewOrderRequestPatientAddressesItemAddressCountrySerializer
        : JsonConverter<PreviewOrderRequestPatientAddressesItemAddressCountry>
    {
        public override PreviewOrderRequestPatientAddressesItemAddressCountry Read(
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
            return new PreviewOrderRequestPatientAddressesItemAddressCountry(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderRequestPatientAddressesItemAddressCountry value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderRequestPatientAddressesItemAddressCountry ReadAsPropertyName(
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
            return new PreviewOrderRequestPatientAddressesItemAddressCountry(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderRequestPatientAddressesItemAddressCountry value,
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
