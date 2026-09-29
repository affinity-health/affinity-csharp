using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListPracticeTeamPrescribersResponseObject.ListPracticeTeamPrescribersResponseObjectSerializer)
)]
[Serializable]
public readonly record struct ListPracticeTeamPrescribersResponseObject : IStringEnum
{
    public static readonly ListPracticeTeamPrescribersResponseObject List = new(Values.List);

    public ListPracticeTeamPrescribersResponseObject(string value)
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
    public static ListPracticeTeamPrescribersResponseObject FromCustom(string value)
    {
        return new ListPracticeTeamPrescribersResponseObject(value);
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
        ListPracticeTeamPrescribersResponseObject value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPracticeTeamPrescribersResponseObject value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListPracticeTeamPrescribersResponseObject value) =>
        value.Value;

    public static explicit operator ListPracticeTeamPrescribersResponseObject(string value) =>
        new(value);

    internal class ListPracticeTeamPrescribersResponseObjectSerializer
        : JsonConverter<ListPracticeTeamPrescribersResponseObject>
    {
        public override ListPracticeTeamPrescribersResponseObject Read(
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
            return new ListPracticeTeamPrescribersResponseObject(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPracticeTeamPrescribersResponseObject value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPracticeTeamPrescribersResponseObject ReadAsPropertyName(
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
            return new ListPracticeTeamPrescribersResponseObject(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPracticeTeamPrescribersResponseObject value,
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
        public const string List = "list";
    }
}
