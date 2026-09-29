using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(RegisterUserRequestRolesItem.RegisterUserRequestRolesItemSerializer))]
[Serializable]
public readonly record struct RegisterUserRequestRolesItem : IStringEnum
{
    public static readonly RegisterUserRequestRolesItem Owner = new(Values.Owner);

    public static readonly RegisterUserRequestRolesItem Administrator = new(Values.Administrator);

    public static readonly RegisterUserRequestRolesItem Prescriber = new(Values.Prescriber);

    public static readonly RegisterUserRequestRolesItem ClinicalStaff = new(Values.ClinicalStaff);

    public static readonly RegisterUserRequestRolesItem Billing = new(Values.Billing);

    public static readonly RegisterUserRequestRolesItem Developer = new(Values.Developer);

    public RegisterUserRequestRolesItem(string value)
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
    public static RegisterUserRequestRolesItem FromCustom(string value)
    {
        return new RegisterUserRequestRolesItem(value);
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

    public static bool operator ==(RegisterUserRequestRolesItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RegisterUserRequestRolesItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RegisterUserRequestRolesItem value) => value.Value;

    public static explicit operator RegisterUserRequestRolesItem(string value) => new(value);

    internal class RegisterUserRequestRolesItemSerializer
        : JsonConverter<RegisterUserRequestRolesItem>
    {
        public override RegisterUserRequestRolesItem Read(
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
            return new RegisterUserRequestRolesItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RegisterUserRequestRolesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RegisterUserRequestRolesItem ReadAsPropertyName(
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
            return new RegisterUserRequestRolesItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RegisterUserRequestRolesItem value,
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
