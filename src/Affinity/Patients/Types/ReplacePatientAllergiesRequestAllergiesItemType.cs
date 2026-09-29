using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ReplacePatientAllergiesRequestAllergiesItemType.ReplacePatientAllergiesRequestAllergiesItemTypeSerializer)
)]
[Serializable]
public readonly record struct ReplacePatientAllergiesRequestAllergiesItemType : IStringEnum
{
    public static readonly ReplacePatientAllergiesRequestAllergiesItemType Allergy = new(
        Values.Allergy
    );

    public static readonly ReplacePatientAllergiesRequestAllergiesItemType Intolerance = new(
        Values.Intolerance
    );

    public ReplacePatientAllergiesRequestAllergiesItemType(string value)
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
    public static ReplacePatientAllergiesRequestAllergiesItemType FromCustom(string value)
    {
        return new ReplacePatientAllergiesRequestAllergiesItemType(value);
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
        ReplacePatientAllergiesRequestAllergiesItemType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReplacePatientAllergiesRequestAllergiesItemType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ReplacePatientAllergiesRequestAllergiesItemType value) =>
        value.Value;

    public static explicit operator ReplacePatientAllergiesRequestAllergiesItemType(string value) =>
        new(value);

    internal class ReplacePatientAllergiesRequestAllergiesItemTypeSerializer
        : JsonConverter<ReplacePatientAllergiesRequestAllergiesItemType>
    {
        public override ReplacePatientAllergiesRequestAllergiesItemType Read(
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
            return new ReplacePatientAllergiesRequestAllergiesItemType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesRequestAllergiesItemType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReplacePatientAllergiesRequestAllergiesItemType ReadAsPropertyName(
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
            return new ReplacePatientAllergiesRequestAllergiesItemType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesRequestAllergiesItemType value,
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
