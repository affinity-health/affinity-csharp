using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne.ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOneSerializer)
)]
[Serializable]
public readonly record struct ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne
    : IStringEnum
{
    public static readonly ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne Infinity =
        new(Values.Infinity);

    public static readonly ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne NaN =
        new(Values.NaN);

    public ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne(string value)
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
    public static ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne FromCustom(
        string value
    )
    {
        return new ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne(value);
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
        ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne value
    ) => value.Value;

    public static explicit operator ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne(
        string value
    ) => new(value);

    internal class ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOneSerializer
        : JsonConverter<ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne>
    {
        public override ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne Read(
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
            return new ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne ReadAsPropertyName(
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
            return new ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPatientsResponseDataItemMeasurementsItemHeightCentimetersOne value,
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
