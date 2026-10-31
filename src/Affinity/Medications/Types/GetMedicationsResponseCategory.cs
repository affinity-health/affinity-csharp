using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(GetMedicationsResponseCategory.GetMedicationsResponseCategorySerializer))]
[Serializable]
public readonly record struct GetMedicationsResponseCategory : IStringEnum
{
    public static readonly GetMedicationsResponseCategory WeightLoss = new(Values.WeightLoss);

    public static readonly GetMedicationsResponseCategory Hormones = new(Values.Hormones);

    public static readonly GetMedicationsResponseCategory SexualHealth = new(Values.SexualHealth);

    public static readonly GetMedicationsResponseCategory Hair = new(Values.Hair);

    public static readonly GetMedicationsResponseCategory Skin = new(Values.Skin);

    public static readonly GetMedicationsResponseCategory Wellness = new(Values.Wellness);

    public static readonly GetMedicationsResponseCategory Peptides = new(Values.Peptides);

    public static readonly GetMedicationsResponseCategory Pain = new(Values.Pain);

    public static readonly GetMedicationsResponseCategory Other = new(Values.Other);

    public static readonly GetMedicationsResponseCategory Supplies = new(Values.Supplies);

    public GetMedicationsResponseCategory(string value)
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
    public static GetMedicationsResponseCategory FromCustom(string value)
    {
        return new GetMedicationsResponseCategory(value);
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

    public static bool operator ==(GetMedicationsResponseCategory value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetMedicationsResponseCategory value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetMedicationsResponseCategory value) => value.Value;

    public static explicit operator GetMedicationsResponseCategory(string value) => new(value);

    internal class GetMedicationsResponseCategorySerializer
        : JsonConverter<GetMedicationsResponseCategory>
    {
        public override GetMedicationsResponseCategory Read(
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
            return new GetMedicationsResponseCategory(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetMedicationsResponseCategory value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetMedicationsResponseCategory ReadAsPropertyName(
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
            return new GetMedicationsResponseCategory(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetMedicationsResponseCategory value,
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
