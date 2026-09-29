using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Patients;

[JsonConverter(typeof(ListAddressesRequestStatus.ListAddressesRequestStatusSerializer))]
[Serializable]
public readonly record struct ListAddressesRequestStatus : IStringEnum
{
    public static readonly ListAddressesRequestStatus Active = new(Values.Active);

    public static readonly ListAddressesRequestStatus Archived = new(Values.Archived);

    public static readonly ListAddressesRequestStatus All = new(Values.All);

    public ListAddressesRequestStatus(string value)
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
    public static ListAddressesRequestStatus FromCustom(string value)
    {
        return new ListAddressesRequestStatus(value);
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

    public static bool operator ==(ListAddressesRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListAddressesRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListAddressesRequestStatus value) => value.Value;

    public static explicit operator ListAddressesRequestStatus(string value) => new(value);

    internal class ListAddressesRequestStatusSerializer : JsonConverter<ListAddressesRequestStatus>
    {
        public override ListAddressesRequestStatus Read(
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
            return new ListAddressesRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListAddressesRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListAddressesRequestStatus ReadAsPropertyName(
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
            return new ListAddressesRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListAddressesRequestStatus value,
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
        public const string Active = "active";

        public const string Archived = "archived";

        public const string All = "all";
    }
}
