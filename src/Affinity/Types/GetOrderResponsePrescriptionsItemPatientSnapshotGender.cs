using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(GetOrderResponsePrescriptionsItemPatientSnapshotGender.GetOrderResponsePrescriptionsItemPatientSnapshotGenderSerializer)
)]
[Serializable]
public readonly record struct GetOrderResponsePrescriptionsItemPatientSnapshotGender : IStringEnum
{
    public static readonly GetOrderResponsePrescriptionsItemPatientSnapshotGender F = new(Values.F);

    public static readonly GetOrderResponsePrescriptionsItemPatientSnapshotGender M = new(Values.M);

    public static readonly GetOrderResponsePrescriptionsItemPatientSnapshotGender O = new(Values.O);

    public static readonly GetOrderResponsePrescriptionsItemPatientSnapshotGender U = new(Values.U);

    public GetOrderResponsePrescriptionsItemPatientSnapshotGender(string value)
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
    public static GetOrderResponsePrescriptionsItemPatientSnapshotGender FromCustom(string value)
    {
        return new GetOrderResponsePrescriptionsItemPatientSnapshotGender(value);
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
        GetOrderResponsePrescriptionsItemPatientSnapshotGender value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetOrderResponsePrescriptionsItemPatientSnapshotGender value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetOrderResponsePrescriptionsItemPatientSnapshotGender value
    ) => value.Value;

    public static explicit operator GetOrderResponsePrescriptionsItemPatientSnapshotGender(
        string value
    ) => new(value);

    internal class GetOrderResponsePrescriptionsItemPatientSnapshotGenderSerializer
        : JsonConverter<GetOrderResponsePrescriptionsItemPatientSnapshotGender>
    {
        public override GetOrderResponsePrescriptionsItemPatientSnapshotGender Read(
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
            return new GetOrderResponsePrescriptionsItemPatientSnapshotGender(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrderResponsePrescriptionsItemPatientSnapshotGender value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetOrderResponsePrescriptionsItemPatientSnapshotGender ReadAsPropertyName(
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
            return new GetOrderResponsePrescriptionsItemPatientSnapshotGender(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrderResponsePrescriptionsItemPatientSnapshotGender value,
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
