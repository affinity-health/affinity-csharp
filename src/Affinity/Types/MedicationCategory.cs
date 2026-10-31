using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(MedicationCategory.MedicationCategorySerializer))]
[Serializable]
public readonly record struct MedicationCategory : IStringEnum
{
    public static readonly MedicationCategory WeightLoss = new(Values.WeightLoss);

    public static readonly MedicationCategory Hormones = new(Values.Hormones);

    public static readonly MedicationCategory SexualHealth = new(Values.SexualHealth);

    public static readonly MedicationCategory Hair = new(Values.Hair);

    public static readonly MedicationCategory Skin = new(Values.Skin);

    public static readonly MedicationCategory Wellness = new(Values.Wellness);

    public static readonly MedicationCategory Peptides = new(Values.Peptides);

    public static readonly MedicationCategory Pain = new(Values.Pain);

    public static readonly MedicationCategory Other = new(Values.Other);

    public static readonly MedicationCategory Supplies = new(Values.Supplies);

    public MedicationCategory(string value)
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
    public static MedicationCategory FromCustom(string value)
    {
        return new MedicationCategory(value);
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

    public static bool operator ==(MedicationCategory value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MedicationCategory value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MedicationCategory value) => value.Value;

    public static explicit operator MedicationCategory(string value) => new(value);

    internal class MedicationCategorySerializer : JsonConverter<MedicationCategory>
    {
        public override MedicationCategory Read(
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
            return new MedicationCategory(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MedicationCategory value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MedicationCategory ReadAsPropertyName(
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
            return new MedicationCategory(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MedicationCategory value,
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
        public const string WeightLoss = "weight_loss";

        public const string Hormones = "hormones";

        public const string SexualHealth = "sexual_health";

        public const string Hair = "hair";

        public const string Skin = "skin";

        public const string Wellness = "wellness";

        public const string Peptides = "peptides";

        public const string Pain = "pain";

        public const string Other = "other";

        public const string Supplies = "supplies";
    }
}
