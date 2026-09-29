using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Patients;

[JsonConverter(
    typeof(ReplacePatientAllergiesRequestAllergiesItemCategory.ReplacePatientAllergiesRequestAllergiesItemCategorySerializer)
)]
[Serializable]
public readonly record struct ReplacePatientAllergiesRequestAllergiesItemCategory : IStringEnum
{
    public static readonly ReplacePatientAllergiesRequestAllergiesItemCategory Drug = new(
        Values.Drug
    );

    public static readonly ReplacePatientAllergiesRequestAllergiesItemCategory Food = new(
        Values.Food
    );

    public static readonly ReplacePatientAllergiesRequestAllergiesItemCategory Insect = new(
        Values.Insect
    );

    public static readonly ReplacePatientAllergiesRequestAllergiesItemCategory Latex = new(
        Values.Latex
    );

    public static readonly ReplacePatientAllergiesRequestAllergiesItemCategory Mold = new(
        Values.Mold
    );

    public static readonly ReplacePatientAllergiesRequestAllergiesItemCategory Pet = new(
        Values.Pet
    );

    public static readonly ReplacePatientAllergiesRequestAllergiesItemCategory Pollen = new(
        Values.Pollen
    );

    public static readonly ReplacePatientAllergiesRequestAllergiesItemCategory Environmental = new(
        Values.Environmental
    );

    public static readonly ReplacePatientAllergiesRequestAllergiesItemCategory Biologic = new(
        Values.Biologic
    );

    public static readonly ReplacePatientAllergiesRequestAllergiesItemCategory Other = new(
        Values.Other
    );

    public ReplacePatientAllergiesRequestAllergiesItemCategory(string value)
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
    public static ReplacePatientAllergiesRequestAllergiesItemCategory FromCustom(string value)
    {
        return new ReplacePatientAllergiesRequestAllergiesItemCategory(value);
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
        ReplacePatientAllergiesRequestAllergiesItemCategory value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReplacePatientAllergiesRequestAllergiesItemCategory value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ReplacePatientAllergiesRequestAllergiesItemCategory value
    ) => value.Value;

    public static explicit operator ReplacePatientAllergiesRequestAllergiesItemCategory(
        string value
    ) => new(value);

    internal class ReplacePatientAllergiesRequestAllergiesItemCategorySerializer
        : JsonConverter<ReplacePatientAllergiesRequestAllergiesItemCategory>
    {
        public override ReplacePatientAllergiesRequestAllergiesItemCategory Read(
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
            return new ReplacePatientAllergiesRequestAllergiesItemCategory(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesRequestAllergiesItemCategory value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReplacePatientAllergiesRequestAllergiesItemCategory ReadAsPropertyName(
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
            return new ReplacePatientAllergiesRequestAllergiesItemCategory(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesRequestAllergiesItemCategory value,
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
