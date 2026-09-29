using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystem.ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystemSerializer)
)]
[Serializable]
public readonly record struct ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystem
    : IStringEnum
{
    public static readonly ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystem SnomedCt =
        new(Values.SnomedCt);

    public ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystem(string value)
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
    public static ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystem FromCustom(
        string value
    )
    {
        return new ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystem(value);
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
        ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystem value
    ) => value.Value;

    public static explicit operator ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystem(
        string value
    ) => new(value);

    internal class ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystemSerializer
        : JsonConverter<ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystem>
    {
        public override ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystem Read(
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
            return new ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystem(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystem ReadAsPropertyName(
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
            return new ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystem(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesResponseAllergiesItemReactionsItemCodeSystem value,
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
        public const string SnomedCt = "snomed-ct";
    }
}
