using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(AllergyCategory.AllergyCategorySerializer))]
[Serializable]
public readonly record struct AllergyCategory : IStringEnum
{
    public static readonly AllergyCategory Drug = new(Values.Drug);

    public static readonly AllergyCategory Food = new(Values.Food);

    public static readonly AllergyCategory Insect = new(Values.Insect);

    public static readonly AllergyCategory Latex = new(Values.Latex);

    public static readonly AllergyCategory Mold = new(Values.Mold);

    public static readonly AllergyCategory Pet = new(Values.Pet);

    public static readonly AllergyCategory Pollen = new(Values.Pollen);

    public AllergyCategory(string value)
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
    public static AllergyCategory FromCustom(string value)
    {
        return new AllergyCategory(value);
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

    public static bool operator ==(AllergyCategory value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AllergyCategory value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AllergyCategory value) => value.Value;

    public static explicit operator AllergyCategory(string value) => new(value);

    internal class AllergyCategorySerializer : JsonConverter<AllergyCategory>
    {
        public override AllergyCategory Read(
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
            return new AllergyCategory(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AllergyCategory value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AllergyCategory ReadAsPropertyName(
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
            return new AllergyCategory(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AllergyCategory value,
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
