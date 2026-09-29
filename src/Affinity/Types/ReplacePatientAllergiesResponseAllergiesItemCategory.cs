using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ReplacePatientAllergiesResponseAllergiesItemCategory.ReplacePatientAllergiesResponseAllergiesItemCategorySerializer)
)]
[Serializable]
public readonly record struct ReplacePatientAllergiesResponseAllergiesItemCategory : IStringEnum
{
    public static readonly ReplacePatientAllergiesResponseAllergiesItemCategory Drug = new(
        Values.Drug
    );

    public static readonly ReplacePatientAllergiesResponseAllergiesItemCategory Food = new(
        Values.Food
    );

    public static readonly ReplacePatientAllergiesResponseAllergiesItemCategory Insect = new(
        Values.Insect
    );

    public static readonly ReplacePatientAllergiesResponseAllergiesItemCategory Latex = new(
        Values.Latex
    );

    public static readonly ReplacePatientAllergiesResponseAllergiesItemCategory Mold = new(
        Values.Mold
    );

    public static readonly ReplacePatientAllergiesResponseAllergiesItemCategory Pet = new(
        Values.Pet
    );

    public static readonly ReplacePatientAllergiesResponseAllergiesItemCategory Pollen = new(
        Values.Pollen
    );

    public static readonly ReplacePatientAllergiesResponseAllergiesItemCategory Environmental = new(
        Values.Environmental
    );

    public static readonly ReplacePatientAllergiesResponseAllergiesItemCategory Biologic = new(
        Values.Biologic
    );

    public static readonly ReplacePatientAllergiesResponseAllergiesItemCategory Other = new(
        Values.Other
    );

    public ReplacePatientAllergiesResponseAllergiesItemCategory(string value)
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
    public static ReplacePatientAllergiesResponseAllergiesItemCategory FromCustom(string value)
    {
        return new ReplacePatientAllergiesResponseAllergiesItemCategory(value);
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
        ReplacePatientAllergiesResponseAllergiesItemCategory value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReplacePatientAllergiesResponseAllergiesItemCategory value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ReplacePatientAllergiesResponseAllergiesItemCategory value
    ) => value.Value;

    public static explicit operator ReplacePatientAllergiesResponseAllergiesItemCategory(
        string value
    ) => new(value);

    internal class ReplacePatientAllergiesResponseAllergiesItemCategorySerializer
        : JsonConverter<ReplacePatientAllergiesResponseAllergiesItemCategory>
    {
        public override ReplacePatientAllergiesResponseAllergiesItemCategory Read(
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
            return new ReplacePatientAllergiesResponseAllergiesItemCategory(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesResponseAllergiesItemCategory value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReplacePatientAllergiesResponseAllergiesItemCategory ReadAsPropertyName(
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
            return new ReplacePatientAllergiesResponseAllergiesItemCategory(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesResponseAllergiesItemCategory value,
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

        public const string Environmental = "environmental";

        public const string Biologic = "biologic";

        public const string Other = "other";
    }
}
