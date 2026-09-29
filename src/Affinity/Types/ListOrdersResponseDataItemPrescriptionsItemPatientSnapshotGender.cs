using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender.ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGenderSerializer)
)]
[Serializable]
public readonly record struct ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender
    : IStringEnum
{
    public static readonly ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender F = new(
        Values.F
    );

    public static readonly ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender M = new(
        Values.M
    );

    public static readonly ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender O = new(
        Values.O
    );

    public static readonly ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender U = new(
        Values.U
    );

    public ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender(string value)
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
    public static ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender FromCustom(
        string value
    )
    {
        return new ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender(value);
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
        ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender value
    ) => value.Value;

    public static explicit operator ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender(
        string value
    ) => new(value);

    internal class ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGenderSerializer
        : JsonConverter<ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender>
    {
        public override ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender Read(
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
            return new ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender ReadAsPropertyName(
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
            return new ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListOrdersResponseDataItemPrescriptionsItemPatientSnapshotGender value,
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
