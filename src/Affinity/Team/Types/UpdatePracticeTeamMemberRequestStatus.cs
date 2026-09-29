using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(UpdatePracticeTeamMemberRequestStatus.UpdatePracticeTeamMemberRequestStatusSerializer)
)]
[Serializable]
public readonly record struct UpdatePracticeTeamMemberRequestStatus : IStringEnum
{
    public static readonly UpdatePracticeTeamMemberRequestStatus Active = new(Values.Active);

    public static readonly UpdatePracticeTeamMemberRequestStatus Disabled = new(Values.Disabled);

    public UpdatePracticeTeamMemberRequestStatus(string value)
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
    public static UpdatePracticeTeamMemberRequestStatus FromCustom(string value)
    {
        return new UpdatePracticeTeamMemberRequestStatus(value);
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

    public static bool operator ==(UpdatePracticeTeamMemberRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdatePracticeTeamMemberRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdatePracticeTeamMemberRequestStatus value) =>
        value.Value;

    public static explicit operator UpdatePracticeTeamMemberRequestStatus(string value) =>
        new(value);

    internal class UpdatePracticeTeamMemberRequestStatusSerializer
        : JsonConverter<UpdatePracticeTeamMemberRequestStatus>
    {
        public override UpdatePracticeTeamMemberRequestStatus Read(
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
            return new UpdatePracticeTeamMemberRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdatePracticeTeamMemberRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdatePracticeTeamMemberRequestStatus ReadAsPropertyName(
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
            return new UpdatePracticeTeamMemberRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdatePracticeTeamMemberRequestStatus value,
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
