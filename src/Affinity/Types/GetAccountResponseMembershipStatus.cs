using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetAccountResponseMembershipStatus.GetAccountResponseMembershipStatusSerializer)
)]
[Serializable]
public readonly record struct GetAccountResponseMembershipStatus : IStringEnum
{
    public static readonly GetAccountResponseMembershipStatus Active = new(Values.Active);

    public static readonly GetAccountResponseMembershipStatus Disabled = new(Values.Disabled);

    public static readonly GetAccountResponseMembershipStatus Invited = new(Values.Invited);

    public GetAccountResponseMembershipStatus(string value)
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
    public static GetAccountResponseMembershipStatus FromCustom(string value)
    {
        return new GetAccountResponseMembershipStatus(value);
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

    public static bool operator ==(GetAccountResponseMembershipStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetAccountResponseMembershipStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetAccountResponseMembershipStatus value) => value.Value;

    public static explicit operator GetAccountResponseMembershipStatus(string value) => new(value);

    internal class GetAccountResponseMembershipStatusSerializer
        : JsonConverter<GetAccountResponseMembershipStatus>
    {
        public override GetAccountResponseMembershipStatus Read(
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
            return new GetAccountResponseMembershipStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetAccountResponseMembershipStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetAccountResponseMembershipStatus ReadAsPropertyName(
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
            return new GetAccountResponseMembershipStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetAccountResponseMembershipStatus value,
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

        public const string Invited = "invited";
    }
}
