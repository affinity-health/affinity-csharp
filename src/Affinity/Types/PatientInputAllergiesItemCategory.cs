using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PatientInputAllergiesItemCategory.PatientInputAllergiesItemCategorySerializer)
)]
[Serializable]
public readonly record struct PatientInputAllergiesItemCategory : IStringEnum
{
    public static readonly PatientInputAllergiesItemCategory Drug = new(Values.Drug);

    public static readonly PatientInputAllergiesItemCategory Food = new(Values.Food);

    public static readonly PatientInputAllergiesItemCategory Insect = new(Values.Insect);

    public static readonly PatientInputAllergiesItemCategory Latex = new(Values.Latex);

    public static readonly PatientInputAllergiesItemCategory Mold = new(Values.Mold);

    public static readonly PatientInputAllergiesItemCategory Pet = new(Values.Pet);

    public static readonly PatientInputAllergiesItemCategory Pollen = new(Values.Pollen);

    public PatientInputAllergiesItemCategory(string value)
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
    public static PatientInputAllergiesItemCategory FromCustom(string value)
    {
        return new PatientInputAllergiesItemCategory(value);
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

    public static bool operator ==(PatientInputAllergiesItemCategory value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PatientInputAllergiesItemCategory value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PatientInputAllergiesItemCategory value) => value.Value;

    public static explicit operator PatientInputAllergiesItemCategory(string value) => new(value);

    internal class PatientInputAllergiesItemCategorySerializer
        : JsonConverter<PatientInputAllergiesItemCategory>
    {
        public override PatientInputAllergiesItemCategory Read(
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
            return new PatientInputAllergiesItemCategory(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PatientInputAllergiesItemCategory value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PatientInputAllergiesItemCategory ReadAsPropertyName(
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
            return new PatientInputAllergiesItemCategory(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PatientInputAllergiesItemCategory value,
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
        public const string Drug = "drug";

        public const string Food = "food";

        public const string Insect = "insect";

        public const string Latex = "latex";

        public const string Mold = "mold";

        public const string Pet = "pet";

        public const string Pollen = "pollen";
    }
}
