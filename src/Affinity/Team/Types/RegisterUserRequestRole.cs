using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(RegisterUserRequestRole.RegisterUserRequestRoleSerializer))]
[Serializable]
public readonly record struct RegisterUserRequestRole : IStringEnum
{
    public static readonly RegisterUserRequestRole Administrator = new(Values.Administrator);

    public static readonly RegisterUserRequestRole Prescriber = new(Values.Prescriber);

    public static readonly RegisterUserRequestRole ClinicalStaff = new(Values.ClinicalStaff);

    public static readonly RegisterUserRequestRole Billing = new(Values.Billing);

    public static readonly RegisterUserRequestRole Developer = new(Values.Developer);

    public RegisterUserRequestRole(string value)
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
    public static RegisterUserRequestRole FromCustom(string value)
    {
        return new RegisterUserRequestRole(value);
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

    public static bool operator ==(RegisterUserRequestRole value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RegisterUserRequestRole value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RegisterUserRequestRole value) => value.Value;

    public static explicit operator RegisterUserRequestRole(string value) => new(value);

    internal class RegisterUserRequestRoleSerializer : JsonConverter<RegisterUserRequestRole>
    {
        public override RegisterUserRequestRole Read(
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
            return new RegisterUserRequestRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RegisterUserRequestRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RegisterUserRequestRole ReadAsPropertyName(
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
            return new RegisterUserRequestRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RegisterUserRequestRole value,
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
        public const string Administrator = "administrator";

        public const string Prescriber = "prescriber";

        public const string ClinicalStaff = "clinical_staff";

        public const string Billing = "billing";

        public const string Developer = "developer";
    }
}
