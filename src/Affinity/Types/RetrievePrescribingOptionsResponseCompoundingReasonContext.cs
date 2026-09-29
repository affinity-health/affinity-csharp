using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(RetrievePrescribingOptionsResponseCompoundingReasonContext.RetrievePrescribingOptionsResponseCompoundingReasonContextSerializer)
)]
[Serializable]
public readonly record struct RetrievePrescribingOptionsResponseCompoundingReasonContext
    : IStringEnum
{
    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonContext NotSupported =
        new(Values.NotSupported);

    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonContext Optional =
        new(Values.Optional);

    public static readonly RetrievePrescribingOptionsResponseCompoundingReasonContext Required =
        new(Values.Required);

    public RetrievePrescribingOptionsResponseCompoundingReasonContext(string value)
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
    public static RetrievePrescribingOptionsResponseCompoundingReasonContext FromCustom(
        string value
    )
    {
        return new RetrievePrescribingOptionsResponseCompoundingReasonContext(value);
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
        RetrievePrescribingOptionsResponseCompoundingReasonContext value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RetrievePrescribingOptionsResponseCompoundingReasonContext value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RetrievePrescribingOptionsResponseCompoundingReasonContext value
    ) => value.Value;

    public static explicit operator RetrievePrescribingOptionsResponseCompoundingReasonContext(
        string value
    ) => new(value);

    internal class RetrievePrescribingOptionsResponseCompoundingReasonContextSerializer
        : JsonConverter<RetrievePrescribingOptionsResponseCompoundingReasonContext>
    {
        public override RetrievePrescribingOptionsResponseCompoundingReasonContext Read(
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
            return new RetrievePrescribingOptionsResponseCompoundingReasonContext(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCompoundingReasonContext value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RetrievePrescribingOptionsResponseCompoundingReasonContext ReadAsPropertyName(
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
            return new RetrievePrescribingOptionsResponseCompoundingReasonContext(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RetrievePrescribingOptionsResponseCompoundingReasonContext value,
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
        public const string NotSupported = "not_supported";

        public const string Optional = "optional";

        public const string Required = "required";
    }
}
