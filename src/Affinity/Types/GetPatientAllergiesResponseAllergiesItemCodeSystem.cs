using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetPatientAllergiesResponseAllergiesItemCodeSystem.GetPatientAllergiesResponseAllergiesItemCodeSystemSerializer)
)]
[Serializable]
public readonly record struct GetPatientAllergiesResponseAllergiesItemCodeSystem : IStringEnum
{
    public static readonly GetPatientAllergiesResponseAllergiesItemCodeSystem Rxnorm = new(
        Values.Rxnorm
    );

    public static readonly GetPatientAllergiesResponseAllergiesItemCodeSystem SnomedCt = new(
        Values.SnomedCt
    );

    public GetPatientAllergiesResponseAllergiesItemCodeSystem(string value)
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
    public static GetPatientAllergiesResponseAllergiesItemCodeSystem FromCustom(string value)
    {
        return new GetPatientAllergiesResponseAllergiesItemCodeSystem(value);
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
        GetPatientAllergiesResponseAllergiesItemCodeSystem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetPatientAllergiesResponseAllergiesItemCodeSystem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetPatientAllergiesResponseAllergiesItemCodeSystem value
    ) => value.Value;

    public static explicit operator GetPatientAllergiesResponseAllergiesItemCodeSystem(
        string value
    ) => new(value);

    internal class GetPatientAllergiesResponseAllergiesItemCodeSystemSerializer
        : JsonConverter<GetPatientAllergiesResponseAllergiesItemCodeSystem>
    {
        public override GetPatientAllergiesResponseAllergiesItemCodeSystem Read(
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
            return new GetPatientAllergiesResponseAllergiesItemCodeSystem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPatientAllergiesResponseAllergiesItemCodeSystem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPatientAllergiesResponseAllergiesItemCodeSystem ReadAsPropertyName(
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
            return new GetPatientAllergiesResponseAllergiesItemCodeSystem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPatientAllergiesResponseAllergiesItemCodeSystem value,
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
