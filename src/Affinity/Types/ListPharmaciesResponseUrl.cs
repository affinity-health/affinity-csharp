using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(ListPharmaciesResponseUrl.ListPharmaciesResponseUrlSerializer))]
[Serializable]
public readonly record struct ListPharmaciesResponseUrl : IStringEnum
{
    public static readonly ListPharmaciesResponseUrl V1Pharmacies = new(Values.V1Pharmacies);

    public ListPharmaciesResponseUrl(string value)
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
    public static ListPharmaciesResponseUrl FromCustom(string value)
    {
        return new ListPharmaciesResponseUrl(value);
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

    public static bool operator ==(ListPharmaciesResponseUrl value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPharmaciesResponseUrl value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPharmaciesResponseUrl value) => value.Value;

    public static explicit operator ListPharmaciesResponseUrl(string value) => new(value);

    internal class ListPharmaciesResponseUrlSerializer : JsonConverter<ListPharmaciesResponseUrl>
    {
        public override ListPharmaciesResponseUrl Read(
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
            return new ListPharmaciesResponseUrl(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPharmaciesResponseUrl value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPharmaciesResponseUrl ReadAsPropertyName(
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
            return new ListPharmaciesResponseUrl(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPharmaciesResponseUrl value,
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
        public const string V1Pharmacies = "/v1/pharmacies";
    }
}
