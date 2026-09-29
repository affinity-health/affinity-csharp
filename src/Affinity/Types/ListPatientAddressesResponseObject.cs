using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPatientAddressesResponseObject.ListPatientAddressesResponseObjectSerializer)
)]
[Serializable]
public readonly record struct ListPatientAddressesResponseObject : IStringEnum
{
    public static readonly ListPatientAddressesResponseObject List = new(Values.List);

    public ListPatientAddressesResponseObject(string value)
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
    public static ListPatientAddressesResponseObject FromCustom(string value)
    {
        return new ListPatientAddressesResponseObject(value);
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

    public static bool operator ==(ListPatientAddressesResponseObject value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPatientAddressesResponseObject value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPatientAddressesResponseObject value) => value.Value;

    public static explicit operator ListPatientAddressesResponseObject(string value) => new(value);

    internal class ListPatientAddressesResponseObjectSerializer
        : JsonConverter<ListPatientAddressesResponseObject>
    {
        public override ListPatientAddressesResponseObject Read(
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
            return new ListPatientAddressesResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPatientAddressesResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPatientAddressesResponseObject ReadAsPropertyName(
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
            return new ListPatientAddressesResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPatientAddressesResponseObject value,
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
        public const string List = "list";
    }
}
