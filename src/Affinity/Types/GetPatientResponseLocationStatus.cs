using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(GetPatientResponseLocationStatus.GetPatientResponseLocationStatusSerializer))]
[Serializable]
public readonly record struct GetPatientResponseLocationStatus : IStringEnum
{
    public static readonly GetPatientResponseLocationStatus Active = new(Values.Active);

    public static readonly GetPatientResponseLocationStatus Archived = new(Values.Archived);

    public GetPatientResponseLocationStatus(string value)
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
    public static GetPatientResponseLocationStatus FromCustom(string value)
    {
        return new GetPatientResponseLocationStatus(value);
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

    public static bool operator ==(GetPatientResponseLocationStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetPatientResponseLocationStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetPatientResponseLocationStatus value) => value.Value;

    public static explicit operator GetPatientResponseLocationStatus(string value) => new(value);

    internal class GetPatientResponseLocationStatusSerializer
        : JsonConverter<GetPatientResponseLocationStatus>
    {
        public override GetPatientResponseLocationStatus Read(
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
            return new GetPatientResponseLocationStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPatientResponseLocationStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPatientResponseLocationStatus ReadAsPropertyName(
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
            return new GetPatientResponseLocationStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPatientResponseLocationStatus value,
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

        public const string Archived = "archived";
    }
}
