using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPatientsResponseDataItemClinicalProfileHeightInchesOne.ListPatientsResponseDataItemClinicalProfileHeightInchesOneSerializer)
)]
[Serializable]
public readonly record struct ListPatientsResponseDataItemClinicalProfileHeightInchesOne
    : IStringEnum
{
    public static readonly ListPatientsResponseDataItemClinicalProfileHeightInchesOne Infinity =
        new(Values.Infinity);

    public static readonly ListPatientsResponseDataItemClinicalProfileHeightInchesOne NaN = new(
        Values.NaN
    );

    public ListPatientsResponseDataItemClinicalProfileHeightInchesOne(string value)
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
    public static ListPatientsResponseDataItemClinicalProfileHeightInchesOne FromCustom(
        string value
    )
    {
        return new ListPatientsResponseDataItemClinicalProfileHeightInchesOne(value);
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
        ListPatientsResponseDataItemClinicalProfileHeightInchesOne value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPatientsResponseDataItemClinicalProfileHeightInchesOne value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListPatientsResponseDataItemClinicalProfileHeightInchesOne value
    ) => value.Value;

    public static explicit operator ListPatientsResponseDataItemClinicalProfileHeightInchesOne(
        string value
    ) => new(value);

    internal class ListPatientsResponseDataItemClinicalProfileHeightInchesOneSerializer
        : JsonConverter<ListPatientsResponseDataItemClinicalProfileHeightInchesOne>
    {
        public override ListPatientsResponseDataItemClinicalProfileHeightInchesOne Read(
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
            return new ListPatientsResponseDataItemClinicalProfileHeightInchesOne(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPatientsResponseDataItemClinicalProfileHeightInchesOne value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPatientsResponseDataItemClinicalProfileHeightInchesOne ReadAsPropertyName(
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
            return new ListPatientsResponseDataItemClinicalProfileHeightInchesOne(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPatientsResponseDataItemClinicalProfileHeightInchesOne value,
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
