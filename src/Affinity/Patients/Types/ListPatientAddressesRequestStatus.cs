using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPatientAddressesRequestStatus.ListPatientAddressesRequestStatusSerializer)
)]
[Serializable]
public readonly record struct ListPatientAddressesRequestStatus : IStringEnum
{
    public static readonly ListPatientAddressesRequestStatus Active = new(Values.Active);

    public static readonly ListPatientAddressesRequestStatus Archived = new(Values.Archived);

    public static readonly ListPatientAddressesRequestStatus All = new(Values.All);

    public ListPatientAddressesRequestStatus(string value)
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
    public static ListPatientAddressesRequestStatus FromCustom(string value)
    {
        return new ListPatientAddressesRequestStatus(value);
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

    public static bool operator ==(ListPatientAddressesRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPatientAddressesRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPatientAddressesRequestStatus value) => value.Value;

    public static explicit operator ListPatientAddressesRequestStatus(string value) => new(value);

    internal class ListPatientAddressesRequestStatusSerializer
        : JsonConverter<ListPatientAddressesRequestStatus>
    {
        public override ListPatientAddressesRequestStatus Read(
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
            return new ListPatientAddressesRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPatientAddressesRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPatientAddressesRequestStatus ReadAsPropertyName(
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
            return new ListPatientAddressesRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPatientAddressesRequestStatus value,
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
