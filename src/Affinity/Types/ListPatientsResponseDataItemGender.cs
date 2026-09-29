using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPatientsResponseDataItemGender.ListPatientsResponseDataItemGenderSerializer)
)]
[Serializable]
public readonly record struct ListPatientsResponseDataItemGender : IStringEnum
{
    public static readonly ListPatientsResponseDataItemGender F = new(Values.F);

    public static readonly ListPatientsResponseDataItemGender M = new(Values.M);

    public static readonly ListPatientsResponseDataItemGender O = new(Values.O);

    public static readonly ListPatientsResponseDataItemGender U = new(Values.U);

    public ListPatientsResponseDataItemGender(string value)
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
    public static ListPatientsResponseDataItemGender FromCustom(string value)
    {
        return new ListPatientsResponseDataItemGender(value);
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

    public static bool operator ==(ListPatientsResponseDataItemGender value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPatientsResponseDataItemGender value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPatientsResponseDataItemGender value) => value.Value;

    public static explicit operator ListPatientsResponseDataItemGender(string value) => new(value);

    internal class ListPatientsResponseDataItemGenderSerializer
        : JsonConverter<ListPatientsResponseDataItemGender>
    {
        public override ListPatientsResponseDataItemGender Read(
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
            return new ListPatientsResponseDataItemGender(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPatientsResponseDataItemGender value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPatientsResponseDataItemGender ReadAsPropertyName(
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
            return new ListPatientsResponseDataItemGender(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPatientsResponseDataItemGender value,
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
