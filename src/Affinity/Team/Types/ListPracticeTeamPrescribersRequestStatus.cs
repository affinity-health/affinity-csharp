using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPracticeTeamPrescribersRequestStatus.ListPracticeTeamPrescribersRequestStatusSerializer)
)]
[Serializable]
public readonly record struct ListPracticeTeamPrescribersRequestStatus : IStringEnum
{
    public static readonly ListPracticeTeamPrescribersRequestStatus Active = new(Values.Active);

    public static readonly ListPracticeTeamPrescribersRequestStatus Inactive = new(Values.Inactive);

    public ListPracticeTeamPrescribersRequestStatus(string value)
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
    public static ListPracticeTeamPrescribersRequestStatus FromCustom(string value)
    {
        return new ListPracticeTeamPrescribersRequestStatus(value);
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
        ListPracticeTeamPrescribersRequestStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPracticeTeamPrescribersRequestStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListPracticeTeamPrescribersRequestStatus value) =>
        value.Value;

    public static explicit operator ListPracticeTeamPrescribersRequestStatus(string value) =>
        new(value);

    internal class ListPracticeTeamPrescribersRequestStatusSerializer
        : JsonConverter<ListPracticeTeamPrescribersRequestStatus>
    {
        public override ListPracticeTeamPrescribersRequestStatus Read(
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
            return new ListPracticeTeamPrescribersRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPracticeTeamPrescribersRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPracticeTeamPrescribersRequestStatus ReadAsPropertyName(
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
            return new ListPracticeTeamPrescribersRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPracticeTeamPrescribersRequestStatus value,
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
