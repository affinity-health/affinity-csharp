using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreatePatientResponseClinicalProfileWeightPoundsOne.CreatePatientResponseClinicalProfileWeightPoundsOneSerializer)
)]
[Serializable]
public readonly record struct CreatePatientResponseClinicalProfileWeightPoundsOne : IStringEnum
{
    public static readonly CreatePatientResponseClinicalProfileWeightPoundsOne Infinity = new(
        Values.Infinity
    );

    public static readonly CreatePatientResponseClinicalProfileWeightPoundsOne NaN = new(
        Values.NaN
    );

    public CreatePatientResponseClinicalProfileWeightPoundsOne(string value)
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
    public static CreatePatientResponseClinicalProfileWeightPoundsOne FromCustom(string value)
    {
        return new CreatePatientResponseClinicalProfileWeightPoundsOne(value);
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
        CreatePatientResponseClinicalProfileWeightPoundsOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreatePatientResponseClinicalProfileWeightPoundsOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreatePatientResponseClinicalProfileWeightPoundsOne value
    ) => value.Value;

    public static explicit operator CreatePatientResponseClinicalProfileWeightPoundsOne(
        string value
    ) => new(value);

    internal class CreatePatientResponseClinicalProfileWeightPoundsOneSerializer
        : JsonConverter<CreatePatientResponseClinicalProfileWeightPoundsOne>
    {
        public override CreatePatientResponseClinicalProfileWeightPoundsOne Read(
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
            return new CreatePatientResponseClinicalProfileWeightPoundsOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePatientResponseClinicalProfileWeightPoundsOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePatientResponseClinicalProfileWeightPoundsOne ReadAsPropertyName(
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
            return new CreatePatientResponseClinicalProfileWeightPoundsOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePatientResponseClinicalProfileWeightPoundsOne value,
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
