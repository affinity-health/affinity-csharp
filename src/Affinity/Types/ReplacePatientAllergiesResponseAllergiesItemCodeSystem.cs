using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ReplacePatientAllergiesResponseAllergiesItemCodeSystem.ReplacePatientAllergiesResponseAllergiesItemCodeSystemSerializer)
)]
[Serializable]
public readonly record struct ReplacePatientAllergiesResponseAllergiesItemCodeSystem : IStringEnum
{
    public static readonly ReplacePatientAllergiesResponseAllergiesItemCodeSystem Rxnorm = new(
        Values.Rxnorm
    );

    public static readonly ReplacePatientAllergiesResponseAllergiesItemCodeSystem SnomedCt = new(
        Values.SnomedCt
    );

    public ReplacePatientAllergiesResponseAllergiesItemCodeSystem(string value)
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
    public static ReplacePatientAllergiesResponseAllergiesItemCodeSystem FromCustom(string value)
    {
        return new ReplacePatientAllergiesResponseAllergiesItemCodeSystem(value);
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
        ReplacePatientAllergiesResponseAllergiesItemCodeSystem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReplacePatientAllergiesResponseAllergiesItemCodeSystem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ReplacePatientAllergiesResponseAllergiesItemCodeSystem value
    ) => value.Value;

    public static explicit operator ReplacePatientAllergiesResponseAllergiesItemCodeSystem(
        string value
    ) => new(value);

    internal class ReplacePatientAllergiesResponseAllergiesItemCodeSystemSerializer
        : JsonConverter<ReplacePatientAllergiesResponseAllergiesItemCodeSystem>
    {
        public override ReplacePatientAllergiesResponseAllergiesItemCodeSystem Read(
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
            return new ReplacePatientAllergiesResponseAllergiesItemCodeSystem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesResponseAllergiesItemCodeSystem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReplacePatientAllergiesResponseAllergiesItemCodeSystem ReadAsPropertyName(
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
            return new ReplacePatientAllergiesResponseAllergiesItemCodeSystem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesResponseAllergiesItemCodeSystem value,
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
        public const string Rxnorm = "rxnorm";

        public const string SnomedCt = "snomed-ct";
    }
}
