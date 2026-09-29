using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(CreateOrderRequestPatientProgramsItemStatus.CreateOrderRequestPatientProgramsItemStatusSerializer)
)]
[Serializable]
public readonly record struct CreateOrderRequestPatientProgramsItemStatus : IStringEnum
{
    public static readonly CreateOrderRequestPatientProgramsItemStatus Active = new(Values.Active);

    public static readonly CreateOrderRequestPatientProgramsItemStatus Completed = new(
        Values.Completed
    );

    public static readonly CreateOrderRequestPatientProgramsItemStatus Paused = new(Values.Paused);

    public CreateOrderRequestPatientProgramsItemStatus(string value)
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
    public static CreateOrderRequestPatientProgramsItemStatus FromCustom(string value)
    {
        return new CreateOrderRequestPatientProgramsItemStatus(value);
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
        CreateOrderRequestPatientProgramsItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOrderRequestPatientProgramsItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateOrderRequestPatientProgramsItemStatus value) =>
        value.Value;

    public static explicit operator CreateOrderRequestPatientProgramsItemStatus(string value) =>
        new(value);

    internal class CreateOrderRequestPatientProgramsItemStatusSerializer
        : JsonConverter<CreateOrderRequestPatientProgramsItemStatus>
    {
        public override CreateOrderRequestPatientProgramsItemStatus Read(
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
            return new CreateOrderRequestPatientProgramsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOrderRequestPatientProgramsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOrderRequestPatientProgramsItemStatus ReadAsPropertyName(
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
            return new CreateOrderRequestPatientProgramsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOrderRequestPatientProgramsItemStatus value,
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

        public const string Completed = "completed";

        public const string Paused = "paused";
    }
}
