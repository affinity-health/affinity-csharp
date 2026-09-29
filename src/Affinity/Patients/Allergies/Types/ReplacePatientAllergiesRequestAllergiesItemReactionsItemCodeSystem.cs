using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Patients;

[JsonConverter(
    typeof(ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystem.ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystemSerializer)
)]
[Serializable]
public readonly record struct ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystem
    : IStringEnum
{
    public static readonly ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystem SnomedCt =
        new(Values.SnomedCt);

    public ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystem(string value)
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
    public static ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystem FromCustom(
        string value
    )
    {
        return new ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystem(value);
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
        ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystem value
    ) => value.Value;

    public static explicit operator ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystem(
        string value
    ) => new(value);

    internal class ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystemSerializer
        : JsonConverter<ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystem>
    {
        public override ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystem Read(
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
            return new ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystem(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystem ReadAsPropertyName(
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
            return new ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystem(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReplacePatientAllergiesRequestAllergiesItemReactionsItemCodeSystem value,
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
