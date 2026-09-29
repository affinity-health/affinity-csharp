using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(InvitePracticeTeamPersonRequestRole.InvitePracticeTeamPersonRequestRoleSerializer)
)]
[Serializable]
public readonly record struct InvitePracticeTeamPersonRequestRole : IStringEnum
{
    public static readonly InvitePracticeTeamPersonRequestRole Owner = new(Values.Owner);

    public static readonly InvitePracticeTeamPersonRequestRole Administrator = new(
        Values.Administrator
    );

    public static readonly InvitePracticeTeamPersonRequestRole Prescriber = new(Values.Prescriber);

    public static readonly InvitePracticeTeamPersonRequestRole ClinicalStaff = new(
        Values.ClinicalStaff
    );

    public static readonly InvitePracticeTeamPersonRequestRole Billing = new(Values.Billing);

    public static readonly InvitePracticeTeamPersonRequestRole Developer = new(Values.Developer);

    public InvitePracticeTeamPersonRequestRole(string value)
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
    public static InvitePracticeTeamPersonRequestRole FromCustom(string value)
    {
        return new InvitePracticeTeamPersonRequestRole(value);
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

    public static bool operator ==(InvitePracticeTeamPersonRequestRole value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InvitePracticeTeamPersonRequestRole value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InvitePracticeTeamPersonRequestRole value) =>
        value.Value;

    public static explicit operator InvitePracticeTeamPersonRequestRole(string value) => new(value);

    internal class InvitePracticeTeamPersonRequestRoleSerializer
        : JsonConverter<InvitePracticeTeamPersonRequestRole>
    {
        public override InvitePracticeTeamPersonRequestRole Read(
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
            return new InvitePracticeTeamPersonRequestRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InvitePracticeTeamPersonRequestRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InvitePracticeTeamPersonRequestRole ReadAsPropertyName(
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
            return new InvitePracticeTeamPersonRequestRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InvitePracticeTeamPersonRequestRole value,
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
        public const string Owner = "owner";

        public const string Administrator = "administrator";

        public const string Prescriber = "prescriber";

        public const string ClinicalStaff = "clinical_staff";

        public const string Billing = "billing";

        public const string Developer = "developer";
    }
}
