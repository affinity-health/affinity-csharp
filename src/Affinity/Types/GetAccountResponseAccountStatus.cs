using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(GetAccountResponseAccountStatus.GetAccountResponseAccountStatusSerializer))]
[Serializable]
public readonly record struct GetAccountResponseAccountStatus : IStringEnum
{
    public static readonly GetAccountResponseAccountStatus Active = new(Values.Active);

    public static readonly GetAccountResponseAccountStatus Pending = new(Values.Pending);

    public static readonly GetAccountResponseAccountStatus Suspended = new(Values.Suspended);

    public GetAccountResponseAccountStatus(string value)
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
    public static GetAccountResponseAccountStatus FromCustom(string value)
    {
        return new GetAccountResponseAccountStatus(value);
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

    public static bool operator ==(GetAccountResponseAccountStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetAccountResponseAccountStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetAccountResponseAccountStatus value) => value.Value;

    public static explicit operator GetAccountResponseAccountStatus(string value) => new(value);

    internal class GetAccountResponseAccountStatusSerializer
        : JsonConverter<GetAccountResponseAccountStatus>
    {
        public override GetAccountResponseAccountStatus Read(
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
            return new GetAccountResponseAccountStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetAccountResponseAccountStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetAccountResponseAccountStatus ReadAsPropertyName(
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
            return new GetAccountResponseAccountStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetAccountResponseAccountStatus value,
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

        public const string Pending = "pending";

        public const string Suspended = "suspended";
    }
}
