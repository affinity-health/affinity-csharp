using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(typeof(PrescriptionStatus.PrescriptionStatusSerializer))]
[Serializable]
public readonly record struct PrescriptionStatus : IStringEnum
{
    public static readonly PrescriptionStatus Submitted = new(Values.Submitted);

    public static readonly PrescriptionStatus Processing = new(Values.Processing);

    public static readonly PrescriptionStatus Shipped = new(Values.Shipped);

    public static readonly PrescriptionStatus Delivered = new(Values.Delivered);

    public static readonly PrescriptionStatus Cancelled = new(Values.Cancelled);

    public static readonly PrescriptionStatus Failed = new(Values.Failed);

    public PrescriptionStatus(string value)
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
    public static PrescriptionStatus FromCustom(string value)
    {
        return new PrescriptionStatus(value);
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

    public static bool operator ==(PrescriptionStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PrescriptionStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PrescriptionStatus value) => value.Value;

    public static explicit operator PrescriptionStatus(string value) => new(value);

    internal class PrescriptionStatusSerializer : JsonConverter<PrescriptionStatus>
    {
        public override PrescriptionStatus Read(
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
            return new PrescriptionStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PrescriptionStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PrescriptionStatus ReadAsPropertyName(
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
            return new PrescriptionStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PrescriptionStatus value,
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
        public const string Submitted = "submitted";

        public const string Processing = "processing";

        public const string Shipped = "shipped";

        public const string Delivered = "delivered";

        public const string Cancelled = "cancelled";

        public const string Failed = "failed";
    }
}
