using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(UpdatePatientRequestStatus.UpdatePatientRequestStatusSerializer))]
[Serializable]
public readonly record struct UpdatePatientRequestStatus : IStringEnum
{
    public static readonly UpdatePatientRequestStatus Active = new(Values.Active);

    public static readonly UpdatePatientRequestStatus Inactive = new(Values.Inactive);

    public UpdatePatientRequestStatus(string value)
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
    public static UpdatePatientRequestStatus FromCustom(string value)
    {
        return new UpdatePatientRequestStatus(value);
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

    public static bool operator ==(UpdatePatientRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdatePatientRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdatePatientRequestStatus value) => value.Value;

    public static explicit operator UpdatePatientRequestStatus(string value) => new(value);

    internal class UpdatePatientRequestStatusSerializer : JsonConverter<UpdatePatientRequestStatus>
    {
        public override UpdatePatientRequestStatus Read(
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
            return new UpdatePatientRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdatePatientRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdatePatientRequestStatus ReadAsPropertyName(
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
            return new UpdatePatientRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdatePatientRequestStatus value,
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

        public const string Inactive = "inactive";
    }
}
