using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetPatientAllergiesResponseAllergiesItemCategory.GetPatientAllergiesResponseAllergiesItemCategorySerializer)
)]
[Serializable]
public readonly record struct GetPatientAllergiesResponseAllergiesItemCategory : IStringEnum
{
    public static readonly GetPatientAllergiesResponseAllergiesItemCategory Drug = new(Values.Drug);

    public static readonly GetPatientAllergiesResponseAllergiesItemCategory Food = new(Values.Food);

    public static readonly GetPatientAllergiesResponseAllergiesItemCategory Insect = new(
        Values.Insect
    );

    public static readonly GetPatientAllergiesResponseAllergiesItemCategory Latex = new(
        Values.Latex
    );

    public static readonly GetPatientAllergiesResponseAllergiesItemCategory Mold = new(Values.Mold);

    public static readonly GetPatientAllergiesResponseAllergiesItemCategory Pet = new(Values.Pet);

    public static readonly GetPatientAllergiesResponseAllergiesItemCategory Pollen = new(
        Values.Pollen
    );

    public static readonly GetPatientAllergiesResponseAllergiesItemCategory Environmental = new(
        Values.Environmental
    );

    public static readonly GetPatientAllergiesResponseAllergiesItemCategory Biologic = new(
        Values.Biologic
    );

    public static readonly GetPatientAllergiesResponseAllergiesItemCategory Other = new(
        Values.Other
    );

    public GetPatientAllergiesResponseAllergiesItemCategory(string value)
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
    public static GetPatientAllergiesResponseAllergiesItemCategory FromCustom(string value)
    {
        return new GetPatientAllergiesResponseAllergiesItemCategory(value);
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
        GetPatientAllergiesResponseAllergiesItemCategory value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetPatientAllergiesResponseAllergiesItemCategory value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetPatientAllergiesResponseAllergiesItemCategory value
    ) => value.Value;

    public static explicit operator GetPatientAllergiesResponseAllergiesItemCategory(
        string value
    ) => new(value);

    internal class GetPatientAllergiesResponseAllergiesItemCategorySerializer
        : JsonConverter<GetPatientAllergiesResponseAllergiesItemCategory>
    {
        public override GetPatientAllergiesResponseAllergiesItemCategory Read(
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
            return new GetPatientAllergiesResponseAllergiesItemCategory(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPatientAllergiesResponseAllergiesItemCategory value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPatientAllergiesResponseAllergiesItemCategory ReadAsPropertyName(
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
            return new GetPatientAllergiesResponseAllergiesItemCategory(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPatientAllergiesResponseAllergiesItemCategory value,
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
