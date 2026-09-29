using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(InvitePracticeTeamPersonRequestRolesItem.InvitePracticeTeamPersonRequestRolesItemSerializer)
)]
[Serializable]
public readonly record struct InvitePracticeTeamPersonRequestRolesItem : IStringEnum
{
    public static readonly InvitePracticeTeamPersonRequestRolesItem Owner = new(Values.Owner);

    public static readonly InvitePracticeTeamPersonRequestRolesItem Administrator = new(
        Values.Administrator
    );

    public static readonly InvitePracticeTeamPersonRequestRolesItem Prescriber = new(
        Values.Prescriber
    );

    public static readonly InvitePracticeTeamPersonRequestRolesItem ClinicalStaff = new(
        Values.ClinicalStaff
    );

    public static readonly InvitePracticeTeamPersonRequestRolesItem Billing = new(Values.Billing);

    public static readonly InvitePracticeTeamPersonRequestRolesItem Developer = new(
        Values.Developer
    );

    public InvitePracticeTeamPersonRequestRolesItem(string value)
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
    public static InvitePracticeTeamPersonRequestRolesItem FromCustom(string value)
    {
        return new InvitePracticeTeamPersonRequestRolesItem(value);
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
        InvitePracticeTeamPersonRequestRolesItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        InvitePracticeTeamPersonRequestRolesItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(InvitePracticeTeamPersonRequestRolesItem value) =>
        value.Value;

    public static explicit operator InvitePracticeTeamPersonRequestRolesItem(string value) =>
        new(value);

    internal class InvitePracticeTeamPersonRequestRolesItemSerializer
        : JsonConverter<InvitePracticeTeamPersonRequestRolesItem>
    {
        public override InvitePracticeTeamPersonRequestRolesItem Read(
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
            return new InvitePracticeTeamPersonRequestRolesItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InvitePracticeTeamPersonRequestRolesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InvitePracticeTeamPersonRequestRolesItem ReadAsPropertyName(
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
            return new InvitePracticeTeamPersonRequestRolesItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InvitePracticeTeamPersonRequestRolesItem value,
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
