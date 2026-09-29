using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPharmaciesResponseDataItemAccess.ListPharmaciesResponseDataItemAccessSerializer)
)]
[Serializable]
public readonly record struct ListPharmaciesResponseDataItemAccess : IStringEnum
{
    public static readonly ListPharmaciesResponseDataItemAccess Invited = new(Values.Invited);

    public static readonly ListPharmaciesResponseDataItemAccess Network = new(Values.Network);

    public ListPharmaciesResponseDataItemAccess(string value)
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
    public static ListPharmaciesResponseDataItemAccess FromCustom(string value)
    {
        return new ListPharmaciesResponseDataItemAccess(value);
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

    public static bool operator ==(ListPharmaciesResponseDataItemAccess value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPharmaciesResponseDataItemAccess value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPharmaciesResponseDataItemAccess value) =>
        value.Value;

    public static explicit operator ListPharmaciesResponseDataItemAccess(string value) =>
        new(value);

    internal class ListPharmaciesResponseDataItemAccessSerializer
        : JsonConverter<ListPharmaciesResponseDataItemAccess>
    {
        public override ListPharmaciesResponseDataItemAccess Read(
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
            return new ListPharmaciesResponseDataItemAccess(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPharmaciesResponseDataItemAccess value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPharmaciesResponseDataItemAccess ReadAsPropertyName(
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
            return new ListPharmaciesResponseDataItemAccess(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPharmaciesResponseDataItemAccess value,
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
        public const string Invited = "invited";

        public const string Network = "network";
    }
}
