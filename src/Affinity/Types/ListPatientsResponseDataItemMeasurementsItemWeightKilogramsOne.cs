using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne.ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOneSerializer)
)]
[Serializable]
public readonly record struct ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne
    : IStringEnum
{
    public static readonly ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne Infinity =
        new(Values.Infinity);

    public static readonly ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne NaN = new(
        Values.NaN
    );

    public ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne(string value)
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
    public static ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne FromCustom(
        string value
    )
    {
        return new ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne(value);
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
        ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne value
    ) => value.Value;

    public static explicit operator ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne(
        string value
    ) => new(value);

    internal class ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOneSerializer
        : JsonConverter<ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne>
    {
        public override ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne Read(
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
            return new ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne ReadAsPropertyName(
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
            return new ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPatientsResponseDataItemMeasurementsItemWeightKilogramsOne value,
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
