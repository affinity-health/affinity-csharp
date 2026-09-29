using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPatientsResponseDataItemClinicalProfileWeightPoundsOne.ListPatientsResponseDataItemClinicalProfileWeightPoundsOneSerializer)
)]
[Serializable]
public readonly record struct ListPatientsResponseDataItemClinicalProfileWeightPoundsOne
    : IStringEnum
{
    public static readonly ListPatientsResponseDataItemClinicalProfileWeightPoundsOne Infinity =
        new(Values.Infinity);

    public static readonly ListPatientsResponseDataItemClinicalProfileWeightPoundsOne NaN = new(
        Values.NaN
    );

    public ListPatientsResponseDataItemClinicalProfileWeightPoundsOne(string value)
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
    public static ListPatientsResponseDataItemClinicalProfileWeightPoundsOne FromCustom(
        string value
    )
    {
        return new ListPatientsResponseDataItemClinicalProfileWeightPoundsOne(value);
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
        ListPatientsResponseDataItemClinicalProfileWeightPoundsOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPatientsResponseDataItemClinicalProfileWeightPoundsOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListPatientsResponseDataItemClinicalProfileWeightPoundsOne value
    ) => value.Value;

    public static explicit operator ListPatientsResponseDataItemClinicalProfileWeightPoundsOne(
        string value
    ) => new(value);

    internal class ListPatientsResponseDataItemClinicalProfileWeightPoundsOneSerializer
        : JsonConverter<ListPatientsResponseDataItemClinicalProfileWeightPoundsOne>
    {
        public override ListPatientsResponseDataItemClinicalProfileWeightPoundsOne Read(
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
            return new ListPatientsResponseDataItemClinicalProfileWeightPoundsOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPatientsResponseDataItemClinicalProfileWeightPoundsOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPatientsResponseDataItemClinicalProfileWeightPoundsOne ReadAsPropertyName(
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
            return new ListPatientsResponseDataItemClinicalProfileWeightPoundsOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPatientsResponseDataItemClinicalProfileWeightPoundsOne value,
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
