using Affinity.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Affinity;

[JsonConverter(
    typeof(PreviewOrderRequestShippingSelection.PreviewOrderRequestShippingSelectionSerializer)
)]
[Serializable]
public readonly record struct PreviewOrderRequestShippingSelection : IStringEnum
{
    public static readonly PreviewOrderRequestShippingSelection Manual = new(Values.Manual);

    public static readonly PreviewOrderRequestShippingSelection LowestCost = new(Values.LowestCost);

    public static readonly PreviewOrderRequestShippingSelection Fastest = new(Values.Fastest);

    public PreviewOrderRequestShippingSelection(string value)
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
    public static PreviewOrderRequestShippingSelection FromCustom(string value)
    {
        return new PreviewOrderRequestShippingSelection(value);
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

    public static bool operator ==(PreviewOrderRequestShippingSelection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PreviewOrderRequestShippingSelection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PreviewOrderRequestShippingSelection value) =>
        value.Value;

    public static explicit operator PreviewOrderRequestShippingSelection(string value) =>
        new(value);

    internal class PreviewOrderRequestShippingSelectionSerializer
        : JsonConverter<PreviewOrderRequestShippingSelection>
    {
        public override PreviewOrderRequestShippingSelection Read(
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
            return new PreviewOrderRequestShippingSelection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreviewOrderRequestShippingSelection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreviewOrderRequestShippingSelection ReadAsPropertyName(
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
            return new PreviewOrderRequestShippingSelection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreviewOrderRequestShippingSelection value,
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
        public const string Manual = "manual";

        public const string LowestCost = "lowest_cost";

        public const string Fastest = "fastest";
    }
}
