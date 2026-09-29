using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderResponseClinicalRequirementsItemStatus.PreviewOrderResponseClinicalRequirementsItemStatusSerializer)
)]
[Serializable]
public readonly record struct PreviewOrderResponseClinicalRequirementsItemStatus : IStringEnum
{
    public static readonly PreviewOrderResponseClinicalRequirementsItemStatus Missing = new(
        Values.Missing
    );

    public static readonly PreviewOrderResponseClinicalRequirementsItemStatus Satisfied = new(
        Values.Satisfied
    );

    public PreviewOrderResponseClinicalRequirementsItemStatus(string value)
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
    public static PreviewOrderResponseClinicalRequirementsItemStatus FromCustom(string value)
    {
        return new PreviewOrderResponseClinicalRequirementsItemStatus(value);
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
        PreviewOrderResponseClinicalRequirementsItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PreviewOrderResponseClinicalRequirementsItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PreviewOrderResponseClinicalRequirementsItemStatus value
    ) => value.Value;

    public static explicit operator PreviewOrderResponseClinicalRequirementsItemStatus(
        string value
    ) => new(value);

    internal class PreviewOrderResponseClinicalRequirementsItemStatusSerializer
        : JsonConverter<PreviewOrderResponseClinicalRequirementsItemStatus>
    {
        public override PreviewOrderResponseClinicalRequirementsItemStatus Read(
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
            return new PreviewOrderResponseClinicalRequirementsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderResponseClinicalRequirementsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderResponseClinicalRequirementsItemStatus ReadAsPropertyName(
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
            return new PreviewOrderResponseClinicalRequirementsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderResponseClinicalRequirementsItemStatus value,
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
        public const string Missing = "missing";

        public const string Satisfied = "satisfied";
    }
}
