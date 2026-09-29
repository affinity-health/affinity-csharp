using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderRequestPatientClinicalProfileWeightPoundsOne.PreviewOrderRequestPatientClinicalProfileWeightPoundsOneSerializer)
)]
[Serializable]
public readonly record struct PreviewOrderRequestPatientClinicalProfileWeightPoundsOne : IStringEnum
{
    public static readonly PreviewOrderRequestPatientClinicalProfileWeightPoundsOne Infinity = new(
        Values.Infinity
    );

    public static readonly PreviewOrderRequestPatientClinicalProfileWeightPoundsOne NaN = new(
        Values.NaN
    );

    public PreviewOrderRequestPatientClinicalProfileWeightPoundsOne(string value)
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
    public static PreviewOrderRequestPatientClinicalProfileWeightPoundsOne FromCustom(string value)
    {
        return new PreviewOrderRequestPatientClinicalProfileWeightPoundsOne(value);
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
        PreviewOrderRequestPatientClinicalProfileWeightPoundsOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderRequestPatientClinicalProfileWeightPoundsOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PreviewOrderRequestPatientClinicalProfileWeightPoundsOne value
    ) => value.Value;

    public static explicit operator PreviewOrderRequestPatientClinicalProfileWeightPoundsOne(
        string value
    ) => new(value);

    internal class PreviewOrderRequestPatientClinicalProfileWeightPoundsOneSerializer
        : JsonConverter<PreviewOrderRequestPatientClinicalProfileWeightPoundsOne>
    {
        public override PreviewOrderRequestPatientClinicalProfileWeightPoundsOne Read(
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
            return new PreviewOrderRequestPatientClinicalProfileWeightPoundsOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderRequestPatientClinicalProfileWeightPoundsOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderRequestPatientClinicalProfileWeightPoundsOne ReadAsPropertyName(
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
            return new PreviewOrderRequestPatientClinicalProfileWeightPoundsOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderRequestPatientClinicalProfileWeightPoundsOne value,
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
        public const string Infinity = "Infinity";

        public const string NaN = "NaN";
    }
}
