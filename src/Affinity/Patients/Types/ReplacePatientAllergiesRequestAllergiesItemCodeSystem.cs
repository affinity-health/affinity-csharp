using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ReplacePatientAllergiesRequestAllergiesItemCodeSystem.ReplacePatientAllergiesRequestAllergiesItemCodeSystemSerializer)
)]
[Serializable]
public readonly record struct ReplacePatientAllergiesRequestAllergiesItemCodeSystem : IStringEnum
{
    public static readonly ReplacePatientAllergiesRequestAllergiesItemCodeSystem Rxnorm = new(
        Values.Rxnorm
    );

    public static readonly ReplacePatientAllergiesRequestAllergiesItemCodeSystem SnomedCt = new(
        Values.SnomedCt
    );

    public ReplacePatientAllergiesRequestAllergiesItemCodeSystem(string value)
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
    public static ReplacePatientAllergiesRequestAllergiesItemCodeSystem FromCustom(string value)
    {
        return new ReplacePatientAllergiesRequestAllergiesItemCodeSystem(value);
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
        ReplacePatientAllergiesRequestAllergiesItemCodeSystem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReplacePatientAllergiesRequestAllergiesItemCodeSystem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ReplacePatientAllergiesRequestAllergiesItemCodeSystem value
    ) => value.Value;

    public static explicit operator ReplacePatientAllergiesRequestAllergiesItemCodeSystem(
        string value
    ) => new(value);

    internal class ReplacePatientAllergiesRequestAllergiesItemCodeSystemSerializer
        : JsonConverter<ReplacePatientAllergiesRequestAllergiesItemCodeSystem>
    {
        public override ReplacePatientAllergiesRequestAllergiesItemCodeSystem Read(
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
            return new ReplacePatientAllergiesRequestAllergiesItemCodeSystem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesRequestAllergiesItemCodeSystem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReplacePatientAllergiesRequestAllergiesItemCodeSystem ReadAsPropertyName(
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
            return new ReplacePatientAllergiesRequestAllergiesItemCodeSystem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesRequestAllergiesItemCodeSystem value,
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
