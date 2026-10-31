using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(AccountType.AccountTypeSerializer))]
[Serializable]
public readonly record struct AccountType : IStringEnum
{
    public static readonly AccountType Platform = new(Values.Platform);

    public static readonly AccountType Practice = new(Values.Practice);

    public static readonly AccountType Pharmacy = new(Values.Pharmacy);

    public AccountType(string value)
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
    public static AccountType FromCustom(string value)
    {
        return new AccountType(value);
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

    public static bool operator ==(AccountType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AccountType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AccountType value) => value.Value;

    public static explicit operator AccountType(string value) => new(value);

    internal class AccountTypeSerializer : JsonConverter<AccountType>
    {
        public override AccountType Read(
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
            return new AccountType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AccountType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AccountType ReadAsPropertyName(
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
            return new AccountType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AccountType value,
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
        public const string Platform = "platform";

        public const string Practice = "practice";

        public const string Pharmacy = "pharmacy";
    }
}
