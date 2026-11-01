using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(PrescriptionEventType.PrescriptionEventTypeSerializer))]
[Serializable]
public readonly record struct PrescriptionEventType : IStringEnum
{
    public static readonly PrescriptionEventType PrescriptionFailed = new(
        Values.PrescriptionFailed
    );

    public static readonly PrescriptionEventType PrescriptionCancelled = new(
        Values.PrescriptionCancelled
    );

    public PrescriptionEventType(string value)
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
    public static PrescriptionEventType FromCustom(string value)
    {
        return new PrescriptionEventType(value);
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

    public static bool operator ==(PrescriptionEventType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PrescriptionEventType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PrescriptionEventType value) => value.Value;

    public static explicit operator PrescriptionEventType(string value) => new(value);

    internal class PrescriptionEventTypeSerializer : JsonConverter<PrescriptionEventType>
    {
        public override PrescriptionEventType Read(
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
            return new PrescriptionEventType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PrescriptionEventType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PrescriptionEventType ReadAsPropertyName(
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
            return new PrescriptionEventType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PrescriptionEventType value,
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
        public const string PrescriptionFailed = "prescription.failed";

        public const string PrescriptionCancelled = "prescription.cancelled";
    }
}
