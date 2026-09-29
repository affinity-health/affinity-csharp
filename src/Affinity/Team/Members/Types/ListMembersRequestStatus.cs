using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity.Team;

[JsonConverter(typeof(ListMembersRequestStatus.ListMembersRequestStatusSerializer))]
[Serializable]
public readonly record struct ListMembersRequestStatus : IStringEnum
{
    public static readonly ListMembersRequestStatus Active = new(Values.Active);

    public static readonly ListMembersRequestStatus Disabled = new(Values.Disabled);

    public ListMembersRequestStatus(string value)
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
    public static ListMembersRequestStatus FromCustom(string value)
    {
        return new ListMembersRequestStatus(value);
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

    public static bool operator ==(ListMembersRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListMembersRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListMembersRequestStatus value) => value.Value;

    public static explicit operator ListMembersRequestStatus(string value) => new(value);

    internal class ListMembersRequestStatusSerializer : JsonConverter<ListMembersRequestStatus>
    {
        public override ListMembersRequestStatus Read(
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
            return new ListMembersRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListMembersRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListMembersRequestStatus ReadAsPropertyName(
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
            return new ListMembersRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListMembersRequestStatus value,
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

        public const string Disabled = "disabled";
    }
}
