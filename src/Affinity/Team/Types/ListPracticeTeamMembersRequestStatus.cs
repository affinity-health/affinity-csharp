using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPracticeTeamMembersRequestStatus.ListPracticeTeamMembersRequestStatusSerializer)
)]
[Serializable]
public readonly record struct ListPracticeTeamMembersRequestStatus : IStringEnum
{
    public static readonly ListPracticeTeamMembersRequestStatus Active = new(Values.Active);

    public static readonly ListPracticeTeamMembersRequestStatus Disabled = new(Values.Disabled);

    public ListPracticeTeamMembersRequestStatus(string value)
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
    public static ListPracticeTeamMembersRequestStatus FromCustom(string value)
    {
        return new ListPracticeTeamMembersRequestStatus(value);
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

    public static bool operator ==(ListPracticeTeamMembersRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListPracticeTeamMembersRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListPracticeTeamMembersRequestStatus value) =>
        value.Value;

    public static explicit operator ListPracticeTeamMembersRequestStatus(string value) =>
        new(value);

    internal class ListPracticeTeamMembersRequestStatusSerializer
        : JsonConverter<ListPracticeTeamMembersRequestStatus>
    {
        public override ListPracticeTeamMembersRequestStatus Read(
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
            return new ListPracticeTeamMembersRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPracticeTeamMembersRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPracticeTeamMembersRequestStatus ReadAsPropertyName(
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
            return new ListPracticeTeamMembersRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPracticeTeamMembersRequestStatus value,
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
