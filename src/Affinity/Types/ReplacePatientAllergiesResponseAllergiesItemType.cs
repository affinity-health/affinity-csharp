using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ReplacePatientAllergiesResponseAllergiesItemType.ReplacePatientAllergiesResponseAllergiesItemTypeSerializer)
)]
[Serializable]
public readonly record struct ReplacePatientAllergiesResponseAllergiesItemType : IStringEnum
{
    public static readonly ReplacePatientAllergiesResponseAllergiesItemType Allergy = new(
        Values.Allergy
    );

    public static readonly ReplacePatientAllergiesResponseAllergiesItemType Intolerance = new(
        Values.Intolerance
    );

    public ReplacePatientAllergiesResponseAllergiesItemType(string value)
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
    public static ReplacePatientAllergiesResponseAllergiesItemType FromCustom(string value)
    {
        return new ReplacePatientAllergiesResponseAllergiesItemType(value);
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
        ReplacePatientAllergiesResponseAllergiesItemType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReplacePatientAllergiesResponseAllergiesItemType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ReplacePatientAllergiesResponseAllergiesItemType value
    ) => value.Value;

    public static explicit operator ReplacePatientAllergiesResponseAllergiesItemType(
        string value
    ) => new(value);

    internal class ReplacePatientAllergiesResponseAllergiesItemTypeSerializer
        : JsonConverter<ReplacePatientAllergiesResponseAllergiesItemType>
    {
        public override ReplacePatientAllergiesResponseAllergiesItemType Read(
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
            return new ReplacePatientAllergiesResponseAllergiesItemType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesResponseAllergiesItemType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReplacePatientAllergiesResponseAllergiesItemType ReadAsPropertyName(
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
            return new ReplacePatientAllergiesResponseAllergiesItemType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesResponseAllergiesItemType value,
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
        public const string Allergy = "allergy";

        public const string Intolerance = "intolerance";
    }
}
