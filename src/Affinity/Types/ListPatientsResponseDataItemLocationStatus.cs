using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPatientsResponseDataItemLocationStatus.ListPatientsResponseDataItemLocationStatusSerializer)
)]
[Serializable]
public readonly record struct ListPatientsResponseDataItemLocationStatus : IStringEnum
{
    public static readonly ListPatientsResponseDataItemLocationStatus Active = new(Values.Active);

    public static readonly ListPatientsResponseDataItemLocationStatus Archived = new(
        Values.Archived
    );

    public ListPatientsResponseDataItemLocationStatus(string value)
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
    public static ListPatientsResponseDataItemLocationStatus FromCustom(string value)
    {
        return new ListPatientsResponseDataItemLocationStatus(value);
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
        ListPatientsResponseDataItemLocationStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPatientsResponseDataItemLocationStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListPatientsResponseDataItemLocationStatus value) =>
        value.Value;

    public static explicit operator ListPatientsResponseDataItemLocationStatus(string value) =>
        new(value);

    internal class ListPatientsResponseDataItemLocationStatusSerializer
        : JsonConverter<ListPatientsResponseDataItemLocationStatus>
    {
        public override ListPatientsResponseDataItemLocationStatus Read(
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
            return new ListPatientsResponseDataItemLocationStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPatientsResponseDataItemLocationStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPatientsResponseDataItemLocationStatus ReadAsPropertyName(
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
            return new ListPatientsResponseDataItemLocationStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPatientsResponseDataItemLocationStatus value,
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
    }
}
