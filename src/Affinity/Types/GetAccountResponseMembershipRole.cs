using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(GetAccountResponseMembershipRole.GetAccountResponseMembershipRoleSerializer))]
[Serializable]
public readonly record struct GetAccountResponseMembershipRole : IStringEnum
{
    public static readonly GetAccountResponseMembershipRole Administrator = new(
        Values.Administrator
    );

    public static readonly GetAccountResponseMembershipRole ClinicalReviewer = new(
        Values.ClinicalReviewer
    );

    public static readonly GetAccountResponseMembershipRole Developer = new(Values.Developer);

    public static readonly GetAccountResponseMembershipRole Operations = new(Values.Operations);

    public static readonly GetAccountResponseMembershipRole Owner = new(Values.Owner);

    public static readonly GetAccountResponseMembershipRole Viewer = new(Values.Viewer);

    public static readonly GetAccountResponseMembershipRole ServiceKey = new(Values.ServiceKey);

    public GetAccountResponseMembershipRole(string value)
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
    public static GetAccountResponseMembershipRole FromCustom(string value)
    {
        return new GetAccountResponseMembershipRole(value);
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

    public static bool operator ==(GetAccountResponseMembershipRole value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetAccountResponseMembershipRole value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetAccountResponseMembershipRole value) => value.Value;

    public static explicit operator GetAccountResponseMembershipRole(string value) => new(value);

    internal class GetAccountResponseMembershipRoleSerializer
        : JsonConverter<GetAccountResponseMembershipRole>
    {
        public override GetAccountResponseMembershipRole Read(
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
            return new GetAccountResponseMembershipRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetAccountResponseMembershipRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetAccountResponseMembershipRole ReadAsPropertyName(
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
            return new GetAccountResponseMembershipRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetAccountResponseMembershipRole value,
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

        public const string ClinicalReviewer = "clinical_reviewer";

        public const string Developer = "developer";

        public const string Operations = "operations";

        public const string Owner = "owner";

        public const string Viewer = "viewer";

        public const string ServiceKey = "service_key";
    }
}
