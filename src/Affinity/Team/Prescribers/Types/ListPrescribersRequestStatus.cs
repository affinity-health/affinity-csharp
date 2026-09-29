using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Team;

[JsonConverter(typeof(ListPrescribersRequestStatus.ListPrescribersRequestStatusSerializer))]
[Serializable]
public readonly record struct ListPrescribersRequestStatus : IStringEnum
{
    public static readonly ListPrescribersRequestStatus Active = new(Values.Active);

    public static readonly ListPrescribersRequestStatus Inactive = new(Values.Inactive);

    public ListPrescribersRequestStatus(string value)
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
    public static ListPrescribersRequestStatus FromCustom(string value)
    {
        return new ListPrescribersRequestStatus(value);
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

    public static bool operator ==(ListPrescribersRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPrescribersRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPrescribersRequestStatus value) => value.Value;

    public static explicit operator ListPrescribersRequestStatus(string value) => new(value);

    internal class ListPrescribersRequestStatusSerializer
        : JsonConverter<ListPrescribersRequestStatus>
    {
        public override ListPrescribersRequestStatus Read(
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
            return new ListPrescribersRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPrescribersRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPrescribersRequestStatus ReadAsPropertyName(
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
            return new ListPrescribersRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPrescribersRequestStatus value,
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

        public const string Inactive = "inactive";
    }
}
