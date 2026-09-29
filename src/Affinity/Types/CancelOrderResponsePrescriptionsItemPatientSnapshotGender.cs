using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CancelOrderResponsePrescriptionsItemPatientSnapshotGender.CancelOrderResponsePrescriptionsItemPatientSnapshotGenderSerializer)
)]
[Serializable]
public readonly record struct CancelOrderResponsePrescriptionsItemPatientSnapshotGender
    : IStringEnum
{
    public static readonly CancelOrderResponsePrescriptionsItemPatientSnapshotGender F = new(
        Values.F
    );

    public static readonly CancelOrderResponsePrescriptionsItemPatientSnapshotGender M = new(
        Values.M
    );

    public static readonly CancelOrderResponsePrescriptionsItemPatientSnapshotGender O = new(
        Values.O
    );

    public static readonly CancelOrderResponsePrescriptionsItemPatientSnapshotGender U = new(
        Values.U
    );

    public CancelOrderResponsePrescriptionsItemPatientSnapshotGender(string value)
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
    public static CancelOrderResponsePrescriptionsItemPatientSnapshotGender FromCustom(string value)
    {
        return new CancelOrderResponsePrescriptionsItemPatientSnapshotGender(value);
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

    public static bool operator ==(
        CancelOrderResponsePrescriptionsItemPatientSnapshotGender value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CancelOrderResponsePrescriptionsItemPatientSnapshotGender value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CancelOrderResponsePrescriptionsItemPatientSnapshotGender value
    ) => value.Value;

    public static explicit operator CancelOrderResponsePrescriptionsItemPatientSnapshotGender(
        string value
    ) => new(value);

    internal class CancelOrderResponsePrescriptionsItemPatientSnapshotGenderSerializer
        : JsonConverter<CancelOrderResponsePrescriptionsItemPatientSnapshotGender>
    {
        public override CancelOrderResponsePrescriptionsItemPatientSnapshotGender Read(
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
            return new CancelOrderResponsePrescriptionsItemPatientSnapshotGender(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelOrderResponsePrescriptionsItemPatientSnapshotGender value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelOrderResponsePrescriptionsItemPatientSnapshotGender ReadAsPropertyName(
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
            return new CancelOrderResponsePrescriptionsItemPatientSnapshotGender(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelOrderResponsePrescriptionsItemPatientSnapshotGender value,
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
        public const string F = "f";

        public const string M = "m";

        public const string O = "o";

        public const string U = "u";
    }
}
