using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListPatientsRequestGender.ListPatientsRequestGenderSerializer))]
[Serializable]
public readonly record struct ListPatientsRequestGender : IStringEnum
{
    public static readonly ListPatientsRequestGender F = new(Values.F);

    public static readonly ListPatientsRequestGender M = new(Values.M);

    public static readonly ListPatientsRequestGender O = new(Values.O);

    public static readonly ListPatientsRequestGender U = new(Values.U);

    public ListPatientsRequestGender(string value)
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
    public static ListPatientsRequestGender FromCustom(string value)
    {
        return new ListPatientsRequestGender(value);
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

    public static bool operator ==(ListPatientsRequestGender value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPatientsRequestGender value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPatientsRequestGender value) => value.Value;

    public static explicit operator ListPatientsRequestGender(string value) => new(value);

    internal class ListPatientsRequestGenderSerializer : JsonConverter<ListPatientsRequestGender>
    {
        public override ListPatientsRequestGender Read(
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
            return new ListPatientsRequestGender(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPatientsRequestGender value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPatientsRequestGender ReadAsPropertyName(
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
            return new ListPatientsRequestGender(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPatientsRequestGender value,
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
        public const string F = "f";

        public const string M = "m";

        public const string O = "o";

        public const string U = "u";
    }
}
